using System;
using System.IO;
using UnityEditor;

// Reference : https://www.youtube.com/watch?v=0_ZRHT2faQw
public static class ProjectSetup
{
    [MenuItem("Tools/Setup/Import Essentials")]
    private static void ImportEssentials()
    {
        Asset.ImportAsset("Ultimate Editor Enhancer.unitypackage", "Infinity Code/Editor ExtensionsUtilities");
        Asset.ImportAsset("PrimeTween High-Performance Animations and Sequences.unitypackage", "Kyrylo Kuzyk/Editor ExtensionsAnimation");
        Asset.ImportAsset("Odin Inspector and Serializer.unitypackage", "Sirenix/Editor ExtensionsSystem");
    }

    public static class Asset
    {
        public static void ImportAsset(string asset, string folder)
        {
            var basepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var assetsFolder = Path.Combine(basepath, "/Unity/Asset Store-5.x");
            AssetDatabase.ImportPackage(Path.Combine(assetsFolder, asset), interactive: false);
        }
    }
}
