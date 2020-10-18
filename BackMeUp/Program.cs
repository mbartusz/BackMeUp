using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using BackMeUp.Models;
using CommandLine;

namespace BackMeUp
{
    public static class Program
    {
        public static void Main(string[] args) => ParseArguments(args);

        private static void ParseArguments(IEnumerable<string> args)
            => Parser.Default.ParseArguments<Input>(args)
                     .WithParsed(Execute)
                     .WithNotParsed(WriteErrorsToConsole);

        public static void Execute(Input args)
        {
            var initialDirectory = args.CopyFromDir;
            var destinationDirectory = args.CopyToDir;
            var processName = args.ProcessName;
            var copyPeriod = args.CopyPeriod;

            while (Process.GetProcessesByName(processName).Length > 0)
            {
                var currentTime = DateTime.UtcNow;
                var outputFolderName = $"{currentTime.Year}-{currentTime.Month}-{currentTime.Day}.{currentTime.Ticks}";

                CopyDirectory(
                    $"{initialDirectory}",
                    @$"{destinationDirectory}\{outputFolderName}"
                );

                Thread.Sleep(copyPeriod * 1000);
            }
        }

        private static void WriteErrorsToConsole(IEnumerable<Error> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }
        }

        private static void CopyDirectory(string initialDirName, string destinationDirName)
        {
            var dir = new DirectoryInfo(initialDirName);
            var dirs = dir.GetDirectories();

            if (!Directory.Exists(destinationDirName))
            {
                Directory.CreateDirectory(destinationDirName);
            }

            var files = dir.GetFiles();

            foreach (var file in files)
            {
                var destinationDirPath = Path.Combine(destinationDirName, file.Name);

                file.CopyTo(destinationDirPath, false);
            }

            foreach (var subDir in dirs)
            {
                var destinationSubPath = Path.Combine(destinationDirName, subDir.Name);

                CopyDirectory(subDir.FullName, destinationSubPath);
            }
        }
    }
}
