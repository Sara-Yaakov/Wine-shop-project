namespace DalApi;
using System.Xml.Linq;
using System.IO;
using System.Linq;
using System.Reflection;

static class DalConfig
{
    internal static string s_dalName;
    internal static Dictionary<string, string> s_dalPackages;

    static DalConfig()
    {
        // Build candidate paths
        var candidates = new List<string?>();

        string baseDir = AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
        string cwd = Directory.GetCurrentDirectory();
        string assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? baseDir;

        // common direct locations
        candidates.Add(Path.Combine(baseDir, "xml", "dal-config.xml"));
        candidates.Add(Path.Combine(cwd, "xml", "dal-config.xml"));
        candidates.Add(Path.Combine(assemblyDir, "xml", "dal-config.xml"));

        candidates.Add(Path.Combine(baseDir, "dal-config.xml"));
        candidates.Add(Path.Combine(cwd, "dal-config.xml"));
        candidates.Add(Path.Combine(assemblyDir, "dal-config.xml"));

        // also try walking up from baseDir and cwd to find xml/dal-config.xml
        foreach (var start in new[] { baseDir, cwd, assemblyDir })
        {
            try
            {
                var dir = new DirectoryInfo(start);
                for (int i = 0; i < 6 && dir != null; i++)
                {
                    candidates.Add(Path.Combine(dir.FullName, "xml", "dal-config.xml"));
                    candidates.Add(Path.Combine(dir.FullName, "dal-config.xml"));
                    dir = dir.Parent;
                }
            }
            catch { }
        }

        // Make unique and absolute
        var attempted = candidates.Where(p => !string.IsNullOrEmpty(p)).Select(p => Path.GetFullPath(p!)).Distinct().ToList();

        // Diagnostic output
        try
        {
            Console.WriteLine("[DalConfig] Current working directory: " + cwd);
            Console.WriteLine("[DalConfig] AppContext.BaseDirectory: " + baseDir);
            Console.WriteLine("[DalConfig] Assembly directory: " + assemblyDir);
            Console.WriteLine("[DalConfig] Attempting to find dal-config.xml in these locations:");
            foreach (var p in attempted) Console.WriteLine("  " + p);
        }
        catch { }

        string found = attempted.FirstOrDefault(File.Exists);
        if (found == null)
        {
            throw new DalConfigException("dal-config.xml file was not found. Attempted locations: " + string.Join("; ", attempted));
        }

        // Print resolved path
        try { Console.WriteLine("[DalConfig] Using configuration file: " + found); } catch { }

        XElement dalConfig = XElement.Load(found) ??
            throw new DalConfigException("dal-config.xml file cannot be loaded: " + found);

        s_dalName =
           dalConfig.Element("dal")?.Value ?? throw new DalConfigException("<dal> element is missing in: " + found);

        var packages = dalConfig.Element("dal-packages")?.Elements() ??
            throw new DalConfigException("<dal-packages> element is missing in: " + found);
        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
    }
}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}