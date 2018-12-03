using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Debootstrap
{
    public class DebootstrapSettings : ToolSettings
    {
        /// <summary>
        /// Set the target architecture (use if dpkg isn't installed).
        /// </summary>
        public string Architecture { get; set; }

        /// <summary>
        /// Comma separated list of packages which will be added to download and extract lists.
        /// </summary>
        public List<string> IncludePackages { get; set; } = new List<string>();

        /// <summary>
        /// Comma  separated  list  of packages which will be removed from download and extract
        /// lists.WARNING: you can and probably will exclude essential packages, be careful
        /// using this option.
        /// </summary>
        public List<string> ExcludePackages { get; set; } = new List<string>();

        /// <summary>
        /// By   default,  debootstrap  will  attempt  to  automatically  resolve  any  missing
        /// dependencies, warning if  any are  found.
        /// </summary>
        public bool NoDependencyResolve { get; set; }

        /// <summary>
        /// Name of the bootstrap script variant to use. 
        /// </summary>
        public string Variant { get; set; }

        /// <summary>
        /// Override the default keyring for  the  distribution  being  bootstrapped,  and
        /// use KEYRING to check signatures of retrieved Release files.
        /// </summary>
        public string KeyRing { get; set; }

        /// <summary>
        /// Disables checking gpg signatures of retrieved Release files.
        /// </summary>
        public bool NoGpgCheck { get; set; }

        /// <summary>
        /// Produce more info about downloading.
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// Print the packages to be installed, and exit. 
        /// </summary>
        public bool PrintDebs { get; set; }

        /// <summary>
        /// Download packages, but don't perform installation.
        /// </summary>
        public bool DownloadOnly { get; set; }

        /// <summary>
        /// Don't  delete  the  /debootstrap  directory  in  the  target  after  completing the
        /// installation.
        /// </summary>
        public bool KeepDebootstrapDir { get; set; }

        /// <summary>
        /// Applies the setting to the given argument builder.
        /// </summary>
        /// <param name="args">The args to modify</param>
        /// <returns>The args</returns>
        public ProcessArgumentBuilder BuildLinuxArguments(ProcessArgumentBuilder args)
        {
            if (!string.IsNullOrWhiteSpace(Architecture))
            {
                args.AppendSwitchQuoted("--arch", Architecture);
            }

            if (IncludePackages.Count > 0)
            {
                args.AppendSwitchQuoted("--include",
                    IncludePackages.Aggregate((a, b) => a + "," + b));
            }

            if (ExcludePackages.Count > 0)
            {
                args.AppendSwitchQuoted("--exclude",
                    ExcludePackages.Aggregate((a, b) => a + "," + b));
            }

            if (NoDependencyResolve)
            {
                args.Append("--no-resolve-deps");
            }

            if (!string.IsNullOrWhiteSpace(Variant))
            {
                args.AppendSwitchQuoted("--variant", Variant);
            }

            if (!string.IsNullOrWhiteSpace(KeyRing))
            {
                args.AppendSwitchQuoted("--keyring", KeyRing);
            }

            if (NoGpgCheck)
            {
                args.Append("--no-check-gpg");
            }

            if (Verbose)
            {
                args.Append("--verbose");
            }

            if (PrintDebs)
            {
                args.Append("--print-debs");
            }

            if (DownloadOnly)
            {
                args.Append("--download-only");
            }

            if (KeepDebootstrapDir)
            {
                args.Append("--keep-debootstrap-dir");
            }

            return args;
        }
    }
}