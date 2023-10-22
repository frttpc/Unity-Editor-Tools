using static System.IO.Directory;
using static System.IO.Path;

namespace Frttpc.Tools
{
    public static class Folders
    {
        public static void CreateDirectories(string root, params string[] dirs)
        {
            foreach (var newDir in dirs)
            {
                CreateDirectory(Combine(root, newDir));
            }
        }
    }
}
