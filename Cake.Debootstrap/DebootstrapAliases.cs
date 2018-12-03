using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Debootstrap
{
    [CakeNamespaceImport("Cake.Debootstrap")]
    [CakeAliasCategory("Debootstrap")]
    public static class DebootstrapAliases
    {
        [CakeMethodAlias]
        public static void Debootstrap(this ICakeContext ctx, string suite, string target, string mirror = null,
            string script = null, DebootstrapSettings settings = null)
        {
            if (ctx.Environment.Platform.Family != PlatformFamily.Linux)
                throw new NotSupportedException("Debootstrap is only supported on linux");
            DebootstrapRunner runner = new DebootstrapRunner(ctx);
            runner.RunTool(suite, target, mirror, script, settings);
        }
    }
}