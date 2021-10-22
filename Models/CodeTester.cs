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
        public FormModel Model { get; set; }
        public InputParser IP { get; set; }
        public FileHandler FH { get; set; }
        public CSCodeCompiler Compiler { get; set; }
        public List<IOData> DataSets { get; set; }
        public AccuracyCalculator AC { get; set; }

        public CodeTester(FormModel model)
        {
            this.Model = model;
            this.IP = new InputParser(model.Code, model.InputData, model.OutputData);
            this.FH = new FileHandler(IP);
            this.Compiler = new CSCodeCompiler(FH);
            this.DataSets = IP.FindDataSets();
        }
        public void Run()
        {
            // make a method for compiling

            // make a separate method for finding accuracy

            // make a seperate method for finding speed

            // create the .cs file
            FH.CreateTempCSFile();

            // compile and execute the program passing in the data from the table
            List<string> output = Compiler.CMDRun(DataSets);

            PrintOutput(output);

            // calculate the accuracy of the output
            string identifier = IP.FindIdentifier();
            //AccuracyCalculator ac = new Accuracy
            Type type = TypeConverter.GetType(identifier);


            AC = new AccuracyCalculator(Model.OutputData, output, identifier);

        }

        public void PrintOutput(List<string> output)
        {
            foreach (string result in output)
            {
                Debug.WriteLine("result: " + result);
            }
        }
    }
}
