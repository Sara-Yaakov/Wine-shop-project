namespace DalApi;
using System.Xml.Linq;

static class DalConfig
{
    internal static string s_dalName;
    internal static Dictionary<string, string> s_dalPackages;

    static DalConfig()
    {
        // נתיב יחסי לתיקיית ה-EXE — עובד מכל פרויקט
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        string configPath = Path.Combine(baseDir, @"..\xml\dal-config.xml");
        configPath = Path.GetFullPath(configPath); // נרמול הנתיב

        XElement dalConfig = XElement.Load(configPath) ??
            throw new DalConfigException("dal-config.xml file is not found");

        s_dalName = dalConfig.Element("dal")?.Value
            ?? throw new DalConfigException("<dal> element is missing");

        var packages = dalConfig.Element("dal-packages")?.Elements()
            ?? throw new DalConfigException("<dal-packages> element is missing");

        s_dalPackages = packages.ToDictionary(p => "" + p.Name, p => p.Value);
    }
}

[Serializable]
public class DalConfigException : Exception
{
    public DalConfigException(string msg) : base(msg) { }
    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}