using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    public class CSCodeCompiler
    {
        public FormModel Model { get; set; }
        public string Identifier { get; set; }
        public List<string> ArgumentTypes { get; set; }
        public List<IOData> DataSets { get; set; }

        public CSCodeCompiler(FormModel model)
        {
            this.Model = model;
        }

        public void Compile()
        {
            // parse text to get identifer, argument types, and list of IOData objects
            InputParser ip = new InputParser(Model.Code, Model.InputData, Model.OutputData);
            Identifier = ip.FindIdentifier();
            ArgumentTypes = ip.FindArgumentTypes();
            DataSets = ip.FindDataSets();

            

            foreach (IOData dataSet in DataSets)
            {
                dataSet.CastInputs(ArgumentTypes);
                dataSet.CastOutput(Identifier);
            }

            foreach (IOData x in DataSets)
            {
                x.PrintDataTypes();
            }

            CMDRun();
        }


        private void CMDRun()
        {
            ProcessStartInfo ps = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                WindowStyle = ProcessWindowStyle.Normal,
                RedirectStandardOutput = true,
                Arguments = @"/k C:\Users\iainr\Documents\temp\testing.exe"
            };

            Process proc = Process.Start(ps);
            //proc.WaitForExit();
            string result = proc.StandardOutput.ReadToEnd();
            Debug.WriteLine(result);
        }
    }
}
