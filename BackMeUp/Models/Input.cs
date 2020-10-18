using CommandLine;

namespace BackMeUp.Models
{
    public class Input
    {
        [Option('i', "input", Required = true, HelpText = "Input directory.")]
        public string CopyFromDir { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output directory.")]
        public string CopyToDir { get; set; }

        [Option('p', "processName", Required = true, HelpText = "Process name to look for.")]
        public string ProcessName { get; set; }

        [Option('t', "timePeriod", Required = true, HelpText = "Copy period in seconds.")]
        public int CopyPeriod { get; set; }
    }
}
