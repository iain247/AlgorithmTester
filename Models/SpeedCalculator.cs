using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    public class SpeedCalculator : ISpeedTester
    {
        public List<string> TestArguments { get; set; }
        //public List<T> TestData { get; set; }
        public CodeCompiler Compiler { get; set; }

        public SpeedCalculator()
        {
            this.TestArguments = new List<string>();
            GenerateTestData();
        }

        public void AddCompiler(CodeCompiler c)
        {
            this.Compiler = c;
        }

        public List<double> FindTimes()
        {
            var times = new List<double>();
            // put test data into compiler
            Stopwatch stopwatch = new Stopwatch();

            foreach (string arguments in TestArguments)
            {
                stopwatch.Start();
                Compiler.RunExecutable(arguments);

            }

            return times;
            
        }

        public void GenerateTestData()
        {
            // GOING TO MOVE THIS TO ITS OWN STATIC CLASS
            TestArguments.Add(CreateMultipleArguments("1"));
            TestArguments.Add(CreateMultipleArguments("10"));
            TestArguments.Add(CreateMultipleArguments("100"));
            TestArguments.Add(CreateMultipleArguments("1000"));
            TestArguments.Add(CreateMultipleArguments("10000"));
            TestArguments.Add(CreateMultipleArguments("100000"));
        }

        // THIS DOESNT ACCOUNT FOR DIFFERENT TYPES
        public string CreateMultipleArguments(string value)
        {
            int numOfArguments = Compiler.IP.NumOfArguments;
            string arguments = "";
            for (int i=0; i<numOfArguments-1; i++)
            {
                arguments += value + ",";
            }
            arguments += value;

            return arguments;
        }
    }
}
