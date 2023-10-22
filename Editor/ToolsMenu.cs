using UnityEditor;
using UnityEditor.PackageManager;
using static System.IO.Path;
using static UnityEditor.AssetDatabase;
using static UnityEngine.Application;

namespace Frttpc.Tools
{
    public static class ToolsMenu
    {
        [MenuItem("Tools/Setup/Create Default Folders")]
        public static void CreateDefaultFolders()
        {
            Folders.CreateDirectories(dataPath, "_Scripts", "Third Party", "Custom");

            Folders.CreateDirectories(Combine(dataPath, "Custom"), "Prefabs", "Animations", "Materials", "Sprites");

            Folders.CreateDirectories(Combine(dataPath, "_Scripts"), "Monobehaviors");
            Folders.CreateDirectories(Combine(Combine(dataPath, "_Scripts"), "Monobehaviors"), "Managers");

            Refresh();
        }

        #region Manifest

        [MenuItem("Tools/Setup/Manifest/3D")]
        public static async void LoadNew3DManifest() => await Packages.ReplacePackageFromGist("10652b99bf6fdd570ccf66358acc60c6");

        [MenuItem("Tools/Setup/Manifest/2D")]
        public static async void LoadNew2DManifest() => await Packages.ReplacePackageFromGist("7ca5d6820d302e3fb4f8bcb440c9ac9d");

        #endregion

        #region Packages

        [MenuItem("Tools/Setup/Packages/New Input System")]
        public static void AddNewInputSystem() => Packages.InstallUnityPackage("inputsystem");

        [MenuItem("Tools/Setup/Packages/Post Processing")]
        public static void AddPostProcessing() => Packages.InstallUnityPackage("postprocessing");

        [MenuItem("Tools/Setup/Packages/Frttpc 2D Scripts")]
        public static void AddFrttpc2DScripts() => ImportPackage("../../../Packages/2D/Frttpc2DScripts.unitypackage", false);

        [MenuItem("Tools/Setup/Packages/Cinemachine")]
        public static void AddCinemachine() => Packages.InstallUnityPackage("cinemachine");

        #region Multiplayer Packages

        [MenuItem("Tools/Setup/Packages/Multiplayer/Netcode")]
        public static void AddNetcodeForGameObjects() => Packages.InstallUnityPackage("netcode.gameobjects");

        [MenuItem("Tools/Setup/Packages/Multiplayer/Multiplayer Tools")]
        public static void AddMultiplayerTools() => Client.Add("https://github.com/Unity-Technologies/com.unity.multiplayer.samples.coop.git?path=/Packages/com.unity.multiplayer.samples.coop#main");

        [MenuItem("Tools/Setup/Packages/Multiplayer/ParrelSync")]
        public static void AddParrelSync() => Client.Add("https://github.com/VeriorPies/ParrelSync.git?path=/ParrelSync");

        #endregion
        #endregion
    }
}