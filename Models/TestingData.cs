using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class TestingData : IOData
    {
        public List<string> Labels { get; set; }

        public List<string> ArgumentNames { get; set; }

        public TestingData(List<TestArgument> testArguments) : base(testArguments.Select(x => x.Value).ToList())
        {
            this.Labels = testArguments.Select(x => x.Label).ToList();
        }

        public void AddArgumentNames(List<string> argumentNames)
        {
            this.ArgumentNames = argumentNames;
        }


    }
}
