using System.Diagnostics;
using System.IO;

namespace BackMeUp.Tests.TestArtifacts.MockProcess
{
    public static class MockProcess
    {
        private static readonly string ProcessFileName = Path.Combine(
            Directory.GetCurrentDirectory(),
            @"TestArtifacts\MockProcess\ProcessFiles\MockProcess.exe"
        );

        public static void Start()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ProcessFileName,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
        }

        public static void Kill(string processName)
        {
            var mockProcess = Process.GetProcessesByName(processName);

            foreach (var process in mockProcess)
            {
                process.Kill();
            }
        }
    }
}
