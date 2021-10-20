using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    public class CodeTester
    {
        public FormModel Model { get; set; }
        public InputParser IP { get; set; }
        public FileHandler FH { get; set; }
        public CSCodeCompiler Compiler { get; set; }
        public List<IOData> DataSets { get; set; }

        public CodeTester(FormModel model)
        {
            this.Model = model;
            IP = new InputParser(model.Code, model.InputData, model.OutputData);
            FH = new FileHandler(IP);
            Compiler = new CSCodeCompiler(FH);
            DataSets = IP.FindDataSets();
        }
        public void Run()
        {

            // create the .cs file
            Compiler.CreateFile();

            // compile and execute the program passing in the data from the table
            List<string> output = Compiler.CMDRun(DataSets);

            PrintOutput(output);

            // calculate the accuracy of the output

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
