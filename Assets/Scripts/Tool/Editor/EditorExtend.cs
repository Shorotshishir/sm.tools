using System.IO;
using UnityEditor;

namespace Editor
{
    /*
     * To find all the priority of all the menu items enable the `MenuDisplayPriority`
     * From Preference>Diagnostics>Editor
     */
    public static class EditorExtend
    {
        [MenuItem("File/Reopen Project", priority = 193)]
        public static void Restart() => EditorApplication.OpenProject(Directory.GetCurrentDirectory());

        [MenuItem("File/Open Terminal", priority = 230)]
        public static void OpenTerminal()
        {
            var osNameAndVersion = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            UnityEngine.Debug.Log(osNameAndVersion);
            var filename = "wt.exe";
            System.Diagnostics.Process.Start(
                fileName: filename,
                arguments: $"-d \"{Directory.GetCurrentDirectory()}\"");
        }
    }
}
