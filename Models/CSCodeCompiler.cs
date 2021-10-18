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
        public List<IOData> DataSets { get; set; }
        public FileHandler FH { get; set; }

        public CSCodeCompiler(FormModel model)
        {
            this.Model = model;
            this.FH = new FileHandler(model.Code);
        }

        public void Compile()
        {
            // parse text to get identifer, argument types, and list of IOData objects
            InputParser ip = new InputParser(Model.Code, Model.InputData, Model.OutputData);
            string identifier = ip.FindIdentifier();
            List<string> argumentTypes = ip.FindArgumentTypes();
            DataSets = ip.FindDataSets();


            // cast data sets
            CastData(argumentTypes, identifier);

            // create a temporary file
            string fileName = CreateFile();

            // compile and run the code using CMD
            CMDRun(fileName);
        }

        private void CastData(List<string> argumentTypes, string identifier)
        {
            foreach (IOData dataSet in DataSets)
            {
                dataSet.CastInputs(argumentTypes);
                dataSet.CastOutput(identifier);
            }
        }

        private string CreateFile()
        {
            FH.CreateTempFile();
            FH.UpdateTempFile();

            return FH.FileName;
        }


        private void CMDRun(string fileName)
        {
            Debug.WriteLine("hi 1");
            ProcessStartInfo ps = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                //Arguments = @"/k C:\Users\iainr\Documents\temp\testing.exe"
                Arguments = @"/k csc " + fileName
            };

            Process proc = Process.Start(ps);

            Debug.WriteLine("hi 2");

            string result = proc.StandardOutput.ReadLine();
            

            //proc.WaitForExit();
            //
            Debug.WriteLine("hi 3");
            Debug.WriteLine(result);

            Debug.WriteLine(FH.GetExecutable());
            ProcessStartInfo ps2 = new ProcessStartInfo
            {
                FileName = FH.GetExecutable(),
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                //Arguments = @"/k C:\Users\iainr\Documents\temp\testing.exe"
            };

            Process proc2 = Process.Start(ps2);

            Debug.WriteLine("hi 4");

            string result2 = proc2.StandardOutput.ReadLine();
            Debug.WriteLine(result2);
        }
    }
}
