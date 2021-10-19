using System;
using System.IO;
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

        public void TestCode()
        {
            // show the model values
            Model.PrintValues();

            // parse text to get identifer, argument types, and list of IOData objects
            InputParser ip = new InputParser(Model.Code, Model.InputData, Model.OutputData);
            string identifier = ip.FindIdentifier();
            List<string> argumentTypes = ip.FindArgumentTypes();
            DataSets = ip.FindDataSets();

            // cast data sets
            CastData(argumentTypes, identifier);

            // create a temporary file
            CreateFile();

            // compile and run the code using CMD
            CMDRun();
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


        private void CMDRun()
        {
            try
            {
                Compile();
                try
                {
                    string output = RunExecutable();
                    Debug.WriteLine("output: " + output);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("can't run ");
                }
            } 
            catch(Exception e)
            {
                Debug.WriteLine("can't compile");
            }

            // delete all the newly created files
            FH.DeleteAllFiles();
        }

        private void Compile()
        {
            ProcessStartInfo ps = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = @"/c cd " + Path.GetDirectoryName(FH.FileName) + " && csc " + FH.FileName
            };

            Process proc = Process.Start(ps);
            proc.WaitForExit();
        }

        private string RunExecutable()
        {
            ProcessStartInfo ps = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = @"/c " + FH.GetExecutable()
            };

            Process proc = Process.Start(ps);
            string output = proc.StandardOutput.ReadLine();
            //proc.WaitForExit();

            return output;
        }
    }
}
