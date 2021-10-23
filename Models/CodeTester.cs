using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    public class CodeTester
    {
        // ALL VARIABLES NEEDED TO UPDATE THE VIEW SHOULD BE HELD HERE
        // PROBABLY DONT NEED ALL THE ATTRIBUTES HERE NOW
        // ALSO DONT NEED A ACCURACYCALCULATOR CLASS SINCE ALL IT DOES IS USE THE COMPARATOR
        // THIS CLASS CAN USE THE COMPARATOR DIRECTLY

        public List<string> Results { get; set; }
        public double Accuracy { get; set; }
        public FormModel Model { get; set; }
        public InputParser IP { get; set; }
        public List<IOData> DataSets { get; set; }
        public string UserMessage { get; set; }

        public CodeTester(FormModel model)
        {
            this.Model = model;
        }
        public void Run()
        {
            try
            {
                // Parse the user's code
                ParseCode();
                // make a method for compiling
                List<string> calculatedOutput = ExecuteCode();

                CalculateAccuracy(calculatedOutput);

                PrintOutput(calculatedOutput);

                UserMessage = "Code was compiled and executed correctly.";

            }
            catch (Exception e)
            {
                UserMessage = e.Message;
                Debug.WriteLine(e.Message);
            }

            // make a separate method for finding accuracy
            

        }

        public void ParseCode()
        {
            IP = new InputParser(Model.Code, Model.InputData, Model.OutputData);
            IP.ParseCode();
            DataSets = IP.FindDataSets();
        }

        public List<string> ExecuteCode()
        {
            //FileHandler fh = new FileHandler(IP);
            CodeCompiler compiler = new CodeCompiler(IP);

            // compile and execute the program passing in the data from the table
            var output = compiler.CMDRun(DataSets);

            return output;
        }

        public void CalculateAccuracy(List<string> calculatedOutput)
        {
            // find the identifier (return type)
            Debug.WriteLine("identifier: " + IP.Identifier);
            string identifier = IP.Identifier;

            IComparator comparator = AccuracyCalculatorFactory.Create(identifier);
            comparator.AddData(Model.OutputData, calculatedOutput);


            Results = comparator.FindResults();
            Accuracy = comparator.CalculateAccuracy(Results);
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
