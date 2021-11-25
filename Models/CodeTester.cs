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
        public FormModel Model { get; set; }
        public InputParser IP { get; set; }
        public CodeCompiler Compiler { get; set; }

        public CodeTester(FormModel model)
        {
            this.Model = model;
            this.IP = new InputParser(model.Code, model.InputData, model.OutputData);
            this.Compiler = new CodeCompiler(IP.ArgumentTypes, IP.Code);
        }
        public void Run()
        {

            // Parse the user's code
            IP.ParseCode();
            // update argument names
            Model.ArgumentNames = IP.ArgumentNames;

            // compile the user's code
            Compiler.Compile();
            // set the compiler's max execution time (convert to milliseconds)
            Compiler.MaxExecutionTime = Model.Timeout * 1000;

            // attempt to calculate accuracy
            Task t1 = null;
            try 
            {
                t1 = CalculateAccuracy();
            }
            catch(InvalidDataException e)
            {
                Model.UserMessage = e.Message;
            }

            // calculate speed
            Task t2 = CalculateSpeed();

            // after both tasks are finished, delete the created files
            Task.WaitAll(t1, t2);

            // sleep breifly to make sure the executable is not being used
            Thread.Sleep(100);
            //Compiler.DeleteAllFiles();
        }

        public async Task CalculateAccuracy()
        {
            // find the results of the code using the given inputs
            List<string> calculatedOutput = await CalculateOutputs();

            // find the identifier (return type)
            string identifier = IP.Identifier;

            Comparator comparator = AccuracyCalculatorFactory.Create(Model.OutputData, calculatedOutput, identifier);

            // find results and accuracy and update model
            Model.Results = comparator.FindResults();
            double accuracy = comparator.CalculateAccuracy(Model.Results);
            Model.Accuracy = Math.Round(accuracy, 2).ToString() + "%";
        }

        public async Task<List<string>> CalculateOutputs()
        {
            // execute the user's code using each set of IOData inputs
            var codeOutput = new List<string>();
            var tasks = new List<Task<string>>();

            // loop through the datasets
            foreach (var dataSet in IP.DataSets)
            {
                Task<string> executionTask;
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
            // wait 500ms less than max execution time to account for discrepancies in timing
            Task first = await Task.WhenAny(run, Task.Delay(Compiler.MaxExecutionTime - 200));

            // if the delay finishes before the execution, mark as "timeout"
            if (first.Id != run.Id)
                return "timeout";
            
            // return the results of the executable
            return run.Result;
        }

        public async Task CalculateSpeed()
        {
            SpeedCalculator sc = new SpeedCalculator(Compiler, IP.ArgumentTypes, IP.ArgumentNames);
            Model.TestArguments = sc.TestData;
            Model.Times = await sc.CalculateTimes();
        }

        public void PrintOutput(List<string> output)
        {
            for (int i=0; i<output.Count; i++)
            {
                Debug.Write("result: " + output[i]);
                Debug.Write(" expected result: " + Model.OutputData[i]);
                Debug.WriteLine(" final result: " + Model.Results[i]);
            }
        }
    }
}
