using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace AlgorithmTester.Models
{
    public class CodeTester
    {
        public List<string> Results { get; set; }
        public double Accuracy { get; set; }
        public FormModel Model { get; set; }
        public InputParser IP { get; set; }
        public List<IOData> DataSets { get; set; }
        public string UserMessage { get; set; }
        public CodeCompiler Compiler { get; set; }
        public List<string> Times { get; set; }
        public List<TestingData> TestArguments { get; set; }

        public CodeTester(FormModel model)
        {
            this.Model = model;
        }
        public void Run()
        {

            // Parse the user's code
            ParseCode();
            // make a method for compiling
            CompileUserCode();
            
            // calculate accuracy and speed asynchronously
            Task t1 = CalculateAccuracy();
            Task t2 = CalculateSpeed();

            // after both tasks are finished, delete the created files
            Task.WaitAll(t1, t2);

            // sleep breifly to make sure the executable is not being used
            //Thread.Sleep(2000);
            //Compiler.DeleteAllFiles();
        }

        public void ParseCode()
        {
            IP = new InputParser(Model.Code, Model.InputData, Model.OutputData);
            IP.ParseCode();
            DataSets = IP.FindDataSets();
        }

        public void CompileUserCode()
        {
            Compiler = new CodeCompiler(IP);
            Compiler.Compile();
        }

        public async Task CalculateAccuracy()
        {
            // find the results of the code using the given inputs
            List<string> calculatedOutput = await CalculateOutputs();

            // find the identifier (return type)
            string identifier = IP.Identifier;

            //IComparator comparator = AccuracyCalculatorFactory.Create(identifier, Model.OutputData, calculatedOutput);

            AccuracyCalculator comparator = new AccuracyCalculator(Model.OutputData, calculatedOutput, identifier);


            Results = comparator.FindResults();
            Accuracy = comparator.CalculateAccuracy(Results);
            Accuracy = Math.Round(Accuracy, 2);
        }

        public async Task<List<string>> CalculateOutputs()
        {
            // execute the user's code using each set of IOData inputs
            var codeOutput = new List<string>();
            var tasks = new List<Task<string>>();
            foreach (IOData dataSet in DataSets)
            {
                Task<string> executionTask = null;
                if (IP.CheckArguments(dataSet))
                {

                    // get arguments from the dataset
                    string argumentsString = dataSet.GetCommandLineArguments();
                    // run the executable with the correct arguments
                    executionTask = ExecuteAsync(argumentsString);
                }
                else
                {
                    executionTask = Task.FromResult("InvalidInput");
                }
                tasks.Add(executionTask);
            }

            foreach (var output in await Task.WhenAll(tasks))
            {
                // if the output is tagged as "timeout", then the process was killed before it could complete
                if (output is "timeout") codeOutput.Add("Timeout");
                // if the output is null, then the process resulted in an error
                if (output is null) codeOutput.Add("RuntimeError");
                else codeOutput.Add(output);
            }
            return codeOutput;
        }

        public async Task<string> ExecuteAsync(string arguments)
        {
            // run the executable with the given arguments
            Task<string> run = Compiler.RunExecutable(arguments);
            // check if the tasks completes before the max execution time
            Task first = await Task.WhenAny(run, Task.Delay(CodeCompiler.MaxExecutionTime));

            // if the delay finishes before the execution, mark as "timeout"
            if (first.Id != run.Id)
                return "timeout";
            
            // return the results of the executable
            return run.Result;
        }


        public async Task CalculateSpeed()
        {
            SpeedCalculator sc = new SpeedCalculator(Compiler);
            TestArguments = sc.TestData;
            Times = await sc.CalculateTimes();
        }

        public void PrintOutput(List<string> output)
        {
            for (int i=0; i<output.Count; i++)
            {
                Debug.Write("result: " + output[i]);
                Debug.Write(" expected result: " + Model.OutputData[i]);
                Debug.WriteLine(" final result: " + Results[i]);
            }
        }
    }
}
