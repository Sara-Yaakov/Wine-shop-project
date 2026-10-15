# Wine-shop-project — System Summary

This document summarizes the solution structure, architecture, key components, runtime behavior, and known issues. It is intended to help maintainers and agents understand the project quickly.

---

## High-level architecture

- 3-tier architecture:
  - DO / DalApi (DalFacade) — domain objects and DAL interfaces plus config/factory.
  - DAL implementations — `DalList` (in-memory) and `DalXml` (XML-backed).
  - BL (Business Logic) — `BL` project implements `BlApi` and uses `DalApi.Factory.Get` to access DAL.
  - Test apps: `DalTest` (DAL-level interactive test) and `BlTest` (BL-level interactive + automated tests).

Data flow: Test UI -> BL Api -> BL Implementation -> DalApi.Factory -> DAL Implementation -> DO objects -> back via converters in BL Tools.

---

## Projects in solution

- `DalFacade` — contains DO types (`DO.*`) and DAL API interfaces (`DalApi.*`) and configuration factory.
  - Key files: `DalFacade/DalApi/Factory.cs`, `DalFacade/DalApi/Config.cs` (DalConfig loader), `DalFacade/DO/*` (Customer, Product, Sale, Enums).

- `DalList` — in-memory DAL implementation used for testing.
  - Key files: `DalList/DataSource.cs` (in-memory storage + seeding), `DalList/CustomerImplementation.cs`, `DalList/ProductImplementation.cs`, `DalList/SaleImplementation.cs`, `DalList/DalList.cs` (singleton instance).

- `DalXML` — XML-backed DAL implementation (singleton `DalXml.DalXml.Instance`), XML-specific implementations under `DalXML` project.

- `BL` — business logic layer.
  - Key files and folders:
    - `BL/BlApi` — public BL interfaces (`IBl`, `ICustomer`, `IProduct`, `ISale`, `IOrder`, `Factory`).
    - `BL/BlImplementation` — implementations of BL interfaces (`Bl.cs`, `CustomerImplementation.cs`, `ProductImplementation.cs`, `SaleImplementation.cs`, `OrderImplementation.cs`).
    - `BL/BO` — BL object models and helpers (`Product`, `Customer`, `Sale`, `Order`, `ProductInOrder`, `SaleInProduct`, `Enums`, `Tools`, `BlException`).
    - `BL/BO/Tools.cs` — conversion helpers between DO <-> BO and `ToString`-style printers.

- `BlTest` — interactive console test program for BL. Contains an `autotest` mode (`RunAutoTest`) used during development.

- `DalTest` — interactive console test program for DAL (uses DAL directly).

---

## Important runtime and bootstrap behavior

- DAL selection is driven by `xml/dal-config.xml`. The `DalFacade` `Factory.Get` loads DAL assembly based on `dal-config.xml`.
- The config loader now searches multiple candidate paths (output dir, current dir, assembly dir, and parents) and prints diagnostics at startup.
- The `DalFacade` project is configured to copy the `xml` folder contents to output (`Content` + `CopyToOutputDirectory=PreserveNewest`) so `dal-config.xml` is available at runtime.

---

## Key business logic details

- BL uses conversion helpers in `BL/BO/Tools.cs` to convert DO objects (from DAL) to BO objects (in BL). Converters are `convertDO*ToBO*` and vice versa.
- Order handling (`BL/BlImplementation/OrderImplementation.cs`):
  - `AddProductToOrder` adds or adjusts `ProductInOrder` entries and validates stock.
  - `SearchSaleForProduct` finds applicable sales from the DAL and maps them to `SaleInProduct` entries.
  - `CalcTotalPriceForProduct` now applies sales as per-unit discounted prices. It: 
    - sorts applicable sales by per-unit discount,
    - applies a greedy allocation of units to the best sales (units covered = floor(amount / requiredAmount) * requiredAmount),
    - charges remaining units at basic price,
    - sets `ProductInOrder.FinalPrice` and `SalesOfProduct` (with product id, units covered and total price for covered units).
  - `CalcTotalPrice` sets `Order.TotalPrice` from products' `FinalPrice`.
  - `DoOrder` validates stock again and updates DAL product `Amount` accordingly.

---

## Tests and helper entry points

- `BlTest` has interactive menus and an `autotest` mode (argument `autotest`) that exercises product creation, sale creation, and a typical order scenario verifying pricing and stock update.
- `DalTest` tests DAL CRUD operations interactively.

---

## Notable fixes and decisions made during recent modifications

- Robust `dal-config.xml` path resolution (search multiple candidate locations and copy xml to output) to avoid TypeInitializationException at runtime.
- BL now translates DAL exceptions into BL exceptions (`BO.BlException.*`) for Create/Update/Delete/GetById operations in Customer and Sale implementations.
- `Tools.ToStringProperty` was rewritten to avoid infinite recursion and handle value types and collections safely.
- `OrderImplementation` recalculation and sale application fixed so:
  - `ProductInOrder.Amount` respects requested amount,
  - `CalcTotalPriceForProduct` applies sales as per-unit discounts and calculates totals correctly,
  - `CalcTotalPrice` assigns `Order.TotalPrice`.
- Seed data added in `DalList/DataSource.cs` so interactive BL runs show customers/products/sales out-of-the-box. Seed sale date ranges were set relative to `DateTime.Now` so sales are active during interactive tests.
- Mappings for `SaleInProduct` in order summary now use the order line's `ProductId` to ensure correct display.

---

## Known issues and TODOs

- Several nullable warnings remain in the DAL and BL due to mixed nullability assumptions (e.g., DAL `Read(id)` throws when not found but BL sometimes treats as nullable). They do not break runtime but should be cleaned up:
  - Decide whether DAL `Read(id)` should return null or throw; make contracts explicit.
  - Align BL interface nullability with implementation (for `Get*ById`, `Get*ByParameter`).
- `Tools` conversions assume non-null DO values; if any DAL returns null entries in lists, BL guards were added but more thorough nullability annotations would reduce warnings.
- `DalFacade.csproj` has a `BaseOutputPath` pointing to a machine path — consider removing or making relative to repo to avoid CI issues.

---

## How to run locally

1. Build solution: `dotnet build` (root of solution).
2. Run BL tests (interactive): `dotnet run --project BlTest/BlTest.csproj`.
   - Use menus to run `Order flow` or other CRUD flows.
3. Run BL autotest: `dotnet run --project BlTest/BlTest.csproj autotest`.
4. Run DAL tests: `dotnet run --project DalTest/DalTest.csproj`.

Startup prints diagnostics from DalConfig showing attempted paths and the chosen `dal-config.xml` location. If config is not found, the exception contains helpful messages with attempted paths.

---

## Where to look for specific logic

- DAL selection & config: `DalFacade/DalApi/Config.cs` and `DalFacade/DalApi/Factory.cs`.
- In-memory DAL: `DalList/*` (DataSource, implementations).
- XML DAL: `DalXML/*` (DalXml singleton and implementations).
- BL interfaces: `BL/BlApi/*`.
- BL implementations: `BL/BlImplementation/*`.
- BO conversions & ToString helpers: `BL/BO/Tools.cs`.
- Order logic: `BL/BlImplementation/OrderImplementation.cs`.
- Test apps: `BlTest/Program.cs`, `DalTest/Program.cs`.

---

If you want, I can:
- Add a small `README.md` to `BlTest` describing interactive commands and autotest output.
- Convert the autotest into unit tests (xUnit) for CI.
- Tidy nullability annotations across BL and DAL to remove warnings and make contracts explicit.

