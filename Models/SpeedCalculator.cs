using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace AlgorithmTester.Models
{
    public class SpeedCalculator
    {
        public List<TestingData> TestData { get; set; }
        public CodeCompiler Compiler { get; set; }


        public SpeedCalculator(CodeCompiler c, List<string> argumentTypes, List<string> argumentNames)
        {      
            this.Compiler = c;
            this.TestData = InputTestValues.GenerateData(argumentTypes, argumentNames);
        }

        public async Task<List<string>> CalculateTimes()
        {
            var tasks = new List<Task<double>>();
            var times = new List<string>();

            // create a task for each set of testing data
            foreach (TestingData arguments in TestData)
            {
                Task<double> executionTask = ExecuteAsync(arguments);
                tasks.Add(executionTask);                   
            }

            foreach (var time in await Task.WhenAll(tasks))
            {
                // if time exceeds max execution time, mark it as "timeout"
                // the process stops after the max execution time, so time will only slightly exceed
                if (time > Compiler.MaxExecutionTime) times.Add("Timeout");
                // time = -1 if there has been a runtime error
                else if (time == -1) times.Add("Runtime Error");
                // else add the time as normal
                else times.Add(String.Format("{0}s", time / 1000.0));
            }
            
            return times;
        }


        public async Task<double> ExecuteAsync(TestingData arguments)
        {
            // initalise elapsed time as infinite
            //double elapsedTime = -1;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            // run executable and obtain output
            string run = await Compiler.RunExecutable(arguments.GetCommandLineArguments());
            // get elapsed time from stopwatch
            stopwatch.Stop();
            double elapsedTime = stopwatch.ElapsedMilliseconds;

            // if return type is less than max execution time and is null, there was a runtime error
            if (String.IsNullOrEmpty(run) && elapsedTime < Compiler.MaxExecutionTime)
                elapsedTime = -1;

            // return the total number of milliseconds rounded to nearest value
            return Math.Round(elapsedTime);
        }
    }
}
