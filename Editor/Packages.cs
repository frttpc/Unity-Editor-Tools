using UnityEditor.PackageManager;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System;
using static System.IO.Path;
using static UnityEngine.Application;

namespace Frttpc.Tools
{
    public static class Packages
    {
        public static async Task ReplacePackageFromGist(string id, string user = "frttpc")
        {
            var url = GetGistUrl(id, user);
            var contents = await GetContents(url);
            ReplacePackageFile(contents);
        }

        public static string GetGistUrl(string id, string user) => $"https://gist.githubusercontent.com/{user}/{id}/raw";

        public static async Task<string> GetContents(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public static void ReplacePackageFile(string contents)
        {
            var existing = Combine(dataPath, "../Packages/manifest.json");
            File.WriteAllText(existing, contents);
            Client.Resolve();
        }

        public static void InstallUnityPackage(string packageName)
        {
            string package = $"com.unity.{packageName}";
            Client.Add(package);
            Console.WriteLine("Installed: " + package);
        }
    }
}
