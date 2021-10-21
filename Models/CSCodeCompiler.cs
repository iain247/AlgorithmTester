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
        public FileHandler FH { get; set; }

        public CSCodeCompiler(FileHandler fh)
        {
            this.FH = fh;
        }

        //public void CreateFile(List<)
        //{
        //    FH.CreateTempFile();
        //    FH.UpdateTempFile(List<string> argumentTypes);
        //}


        public List<string> CMDRun(List<IOData> DataSets)
        {
            Compile();

            var codeOutput = new List<string>();
            foreach(IOData dataSet in DataSets)
            {
                string arguments = dataSet.GetCommandLineArguments();
                string output = RunExecutable(arguments);
                codeOutput.Add(output);
            }
            
            // delete all the newly created files
            FH.DeleteAllFiles();

            return codeOutput;
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

            Debug.WriteLine(ps.Arguments);

            Process proc = Process.Start(ps);
            proc.WaitForExit();
        }

        private string RunExecutable(string arguments)
        {
            ProcessStartInfo ps = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = @"/c " + FH.GetExecutable() + " " + arguments
            };

            Debug.WriteLine(ps.Arguments);

            Process proc = Process.Start(ps);
            string output = proc.StandardOutput.ReadLine();
            proc.WaitForExit();

            return output;
        }
    }

}
