using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.UnitTest.Integration.Resources
{
    public static class FileUtils
    {
        /// <summary>
        /// Get the content of the embedded resources as as MemoryStream
        /// </summary>
        /// <param name="assemblyName">Name of the assembly</param>
        /// <param name="resource">Filename of the resource. If the file is located in a subfolder, use dots instead of slashes</param>
        /// <returns></returns>
        public static MemoryStream LoadEmbeddedResourceAsStream(
            string assemblyName, string resource)
        {
            var ms = new MemoryStream();

            var assembly = Assembly.Load(new AssemblyName(assemblyName));

            var resources = assembly.GetManifestResourceNames();
            var embeddedResource = resources.SingleOrDefault(x => x.EndsWith(resource));

            if (embeddedResource == null)
                throw new Exception($"Can't find embedded resource {resource} in {assemblyName}. Resources found: {string.Join(", ", resources.ToList())}");

            using (var stream = assembly.GetManifestResourceStream(embeddedResource))
            {
                if (stream == null)
                    throw new InvalidOperationException();

                stream.CopyTo(ms);
            }
            return ms;
        }

        /// <summary>
        /// Get the content of the embedded resources as string
        /// </summary>
        /// <param name="assemblyName">Name of the assembly</param>
        /// <param name="resource">Filename of the resource. If the file is located in a subfolder, use dots instead of slashes</param>
        /// <returns></returns>
        public static async Task<string> LoadEmbeddedResourceAsString(
            string assemblyName, string resource)
        {
            string output;

            var ms = LoadEmbeddedResourceAsStream(assemblyName, resource);
            ms.Position = 0;

            using (var reader = new StreamReader(ms))
                output = await reader.ReadToEndAsync();


            return output;
        }
    }
}
