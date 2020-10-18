using System.IO;
using BackMeUp.Models;

namespace BackMeUp.Tests.Builders
{
    public class Builder
    {
        private string _processName;

        public Builder WithProcessName(string processName)
        {
            _processName = processName;
            return this;
        }

        public Input Build()
            => new Input
            {
                CopyFromDir = Path.Combine(Directory.GetCurrentDirectory(), @"TestArtifacts\Input"),
                CopyToDir = Path.Combine(Directory.GetCurrentDirectory(), @"TestArtifacts\Output"),
                CopyPeriod = 5,
                ProcessName = _processName
            };
    }
}
