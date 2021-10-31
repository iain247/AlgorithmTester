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
        public List<IOData> TestData { get; set; }
        public CodeCompiler Compiler { get; set; }
        public InputParser IP { get; set; }
        

        public SpeedCalculator(CodeCompiler c)
        {      
            this.Compiler = c;
            this.IP = c.IP;
            this.TestData = InputTestValues.GenerateData(IP.ArgumentTypes, IP.ArgumentNames);
        }

        public async Task<List<string>> CalculateTimes()
        {
            var tasks = new List<Task<double>>();
            var times = new List<string>();

            // create a task for each set of testing data
            foreach (IOData arguments in TestData)
            {
                Task<double> executionTask = ExecuteAsync(arguments);
                tasks.Add(executionTask);                   
            }

            foreach (var time in await Task.WhenAll(tasks))
            {
                if (time < 0) times.Add("Timeout");
                else times.Add(String.Format("{0}s", time / 1000.0));
            }
            
            return times;
        }


        public async Task<double> ExecuteAsync(IOData arguments)
        {
            // initalise elapsed time as infinite
            double elapsedTime = -1;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // run executable and obtain output
            string run = await Compiler.RunExecutable(arguments.GetCommandLineArguments());

            stopwatch.Stop();

            // executable returns null if it times out
            if (!(run is null)) elapsedTime = stopwatch.ElapsedMilliseconds;

            // return the total number of milliseconds rounded to nearest value
            return Math.Round(elapsedTime);
        }



        public void GenerateTestData()
        {
            for (int i = 0; i < InputTestValues.TestValueSize; i++)
            {
                // find array of arguments
                IOData data = InputTestValues.GenerateData(IP.ArgumentTypes, i);
                data.AddArgumentNames(IP.ArgumentNames);
                TestData.Add(data);
            }
        }
    }
}
