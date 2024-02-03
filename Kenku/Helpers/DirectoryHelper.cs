using System.Reflection;

namespace Kenku.Helpers
{
    public static class DirectoryHelper
    {
        public static DirectoryInfo? GetWorkingDirectory()
        {
            var filePath = Assembly
                .GetExecutingAssembly()
                .FullName;
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return null;
            }
            var file = new FileInfo(filePath);
            var output = file
                ?.Directory;
            return output;
        }
    }
}