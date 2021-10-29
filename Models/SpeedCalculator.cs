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
        public List<string> Times { get; set; }
        public const int TimeLimit = 10000;

        public SpeedCalculator(CodeCompiler c)
        {
            this.TestData = new List<IOData>();
            this.Times = new List<string>();
            this.Compiler = c;
            this.IP = c.IP;
            GenerateTestData();
        }

        public void AddCompiler(CodeCompiler c)
        {
            this.Compiler = c;
            this.IP = c.IP;
        }

        public async Task CalculateTimes()
        {
            var tasks = new List<Task<TimeSpan>>();

            // create a task for each set of testing data
            for (int i=0; i<TestData.Count(); i++)
            {
                Debug.WriteLine("creating task " + i);
                IOData arguments = TestData[i];
                Task<TimeSpan> executionTask = ExecuteAsync(arguments);
                tasks.Add(executionTask);                   
            }
            Debug.WriteLine("created tasks, now waiting...");
            // start each task asynchronously
            foreach (var time in await Task.WhenAll(tasks))
            {
                Debug.WriteLine("finished a task");
                Times.Add(String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    time.Hours, time.Minutes, time.Seconds, time.Milliseconds / 10));
            }
            Debug.WriteLine("calculated all times");
        }

        public Task<TimeSpan> ExecuteAsync(IOData arguments)
        {
            return Task.Run(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();


                Compiler.RunExecutable(arguments.GetCommandLineArguments());
                stopwatch.Stop();
                TimeSpan time = stopwatch.Elapsed;
                return time;
            });             
        }

        public void GenerateTestData()
        {
            for (int i=0; i<InputTestValues.TestValueSize; i++)
            {
                // find array of arguments
                IOData data = InputTestValues.GenerateData(IP.ArgumentTypes, i);
                data.AddArgumentNames(IP.ArgumentNames);
                TestData.Add(data);
            }
        }
    }
}
