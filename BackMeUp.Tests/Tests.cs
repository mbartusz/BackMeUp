using System.IO;
using System.Linq;
using BackMeUp.Tests.Builders;
using BackMeUp.Tests.Helpers;
using BackMeUp.Tests.TestArtifacts.MockProcess;
using Microsoft.VisualBasic.FileIO;
using Xunit;

namespace BackMeUp.Tests
{
    public class Tests
    {
        private const string FileName = "Dummy";

        [Fact]
        public void Execute_GivenExistingProcessName_ShouldCopyAndDeleteDirectories()
        {
            //Given
            const string processName = "MockProcess";
            var args = new Builder()
                      .WithProcessName(processName)
                      .Build();
            FileCleaner.CleanTestArtifacts();
            MockProcess.Start();

            //When
            Program.Execute(args);

            //Then
            var dirs = Directory.GetDirectories(args.CopyToDir);
            var fileCounter = dirs.Count(dir => FileSystem.FileExists(Path.Combine(dir, FileName)));

            Assert.True(fileCounter > 0);

            FileCleaner.CleanTestArtifacts();
            MockProcess.Kill(processName);
        }

        [Fact]
        public void Execute_GivenNonExistingProcessName_ShouldNotCopyDirectoriesAndQuit()
        {
            //Given
            var args = new Builder()
               .Build();

            //When
            FileCleaner.CleanTestArtifacts();
            Program.Execute(args);

            //Then
            var doesFileExist = FileSystem.FileExists(Path.Combine(args.CopyToDir, FileName));
            Assert.Equal(doesFileExist, false);
        }
    }
}
