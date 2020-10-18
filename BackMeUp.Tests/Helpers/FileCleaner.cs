using System.IO;

namespace BackMeUp.Tests.Helpers
{
    public static class FileCleaner
    {
        private static readonly string OutputDirPath = Path.Combine(Directory.GetCurrentDirectory(), @"TestArtifacts\Output");

        public static void CleanTestArtifacts()
        {
            var dirs = Directory.GetDirectories(OutputDirPath);
            foreach (var dir in dirs)
            {
                Directory.Delete(dir, true);
            }
        }
    }
}
