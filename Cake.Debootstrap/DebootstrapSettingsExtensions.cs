namespace Cake.Debootstrap
{
    public static class DebootstrapSettingsExtensions
    {
        public static DebootstrapSettings SetArchitecture(this DebootstrapSettings settings, string arch)
        {
            settings.Architecture = arch;
            return settings;
        }

        public static DebootstrapSettings IncludePackage(this DebootstrapSettings settings, string package)
        {
            settings.IncludePackages.Add(package);
            settings.ExcludePackages.Remove(package);
            return settings;
        }

        public static DebootstrapSettings ExcludePackage(this DebootstrapSettings settings, string package)
        {
            settings.IncludePackages.Remove(package);
            settings.ExcludePackages.Add(package);
            return settings;
        }

        public static DebootstrapSettings SetNoDependencyResolve(this DebootstrapSettings settings, bool deps = true)
        {
            settings.NoDependencyResolve = deps;
            return settings;
        }

        public static DebootstrapSettings SetVariant(this DebootstrapSettings settings, string variant)
        {
            settings.Variant = variant;
            return settings;
        }

        public static DebootstrapSettings SetKeyRing(this DebootstrapSettings settings, string key)
        {
            settings.KeyRing = key;
            return settings;
        }

        public static DebootstrapSettings SetNoGpgCheck(this DebootstrapSettings settings, bool check = true)
        {
            settings.NoGpgCheck = check;
            return settings;
        }


        public static DebootstrapSettings SetVerbose(this DebootstrapSettings settings, bool verbose = true)
        {
            settings.Verbose = verbose;
            return settings;
        }

        public static DebootstrapSettings SetPrintDebs(this DebootstrapSettings settings, bool print = true)
        {
            settings.PrintDebs = print;
            return settings;
        }

        public static DebootstrapSettings SetDownloadOnly(this DebootstrapSettings settings, bool download = true)
        {
            settings.DownloadOnly = download;
            return settings;
        }

        public static DebootstrapSettings SetKeepDebootstrapDir(this DebootstrapSettings settings, bool keep = true)
        {
            settings.KeepDebootstrapDir = keep;
            return settings;
        }
    }
}