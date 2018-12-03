using Cake.Core;
using Cake.Core.IO;

namespace Cake.Debootstrap
{
    public static class Extensions
    {
        internal static ProcessArgumentBuilder BuildForLinux(this DebootstrapSettings settings, string suite,
            string target, string mirror, string script)
        {
            ProcessArgumentBuilder args = new ProcessArgumentBuilder();
            args = settings.BuildLinuxArguments(args);
            args.AppendQuoted(suite);
            args.AppendQuoted(target);

            if (!string.IsNullOrWhiteSpace(mirror))
            {
                args.AppendQuoted(mirror);
            }

            if (!string.IsNullOrWhiteSpace(script))
            {
                args.AppendQuoted(script);
            }

            return args;
        }
    }
}