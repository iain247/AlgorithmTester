using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    public class CodeCompiler
    {
        public FileHandler FH { get; set; }
        public InputParser IP { get; set; }

        public CodeCompiler(InputParser ip)
        {
            this.IP = ip;
            this.FH = new FileHandler(ip);
        }

        public List<string> CMDRun(List<IOData> DataSets)
        {
            FH.CreateTempCSFile();

            Compile();

            var codeOutput = new List<string>();
            foreach(IOData dataSet in DataSets)
            {
                string output;
                if (IP.CheckArguments(dataSet))
                {
                    string argumentsString = dataSet.GetCommandLineArguments();
                    output = RunExecutable(argumentsString);
                }
                else
                {
                    output = "InvalidInput";
                }
                
                codeOutput.Add(output);
            }
            
            // delete all the newly created files
            //FH.DeleteAllFiles();

            return codeOutput;
        }

        private void Compile()
        {
            ProcessStartInfo ps = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = @"/c cd " + Path.GetDirectoryName(FH.FileName) + " && csc " + FH.FileName
            };

            Debug.WriteLine(ps.Arguments);

            Process proc = Process.Start(ps);
            string output = proc.StandardOutput.ReadToEnd();
            CheckCompilation(output);
            proc.WaitForExit();
        }

        /*
         *  TRY THIS FOR THE SPEED CHECKS
         */
    
        public string RunExecutable(string arguments)
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
            string output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();
            Debug.WriteLine("output: " + output);

            return output;
        }


        public void CheckCompilation(string compilationOutput)
        {
            // the compilation will have succeeded if a .exe file is created
            if (!File.Exists(FH.GetExecutable()))
            {
                string errorMessage = ExtractErrorMessage(compilationOutput);
                throw new CompilationErrorException(errorMessage);
            }
        }

        public string ExtractErrorMessage(string compilationOutput)
        {

            string line = string.Empty;
            using StringReader sr = new StringReader(compilationOutput);

            // loop through the compilation output string to find the error message
            do
            {           
                line = sr.ReadLine();
                if (line is null) return compilationOutput;
            }
            while (!line.Contains("error"));

            // find the error message which occurs after the colon
            // this removes the file name and error line as this is irrelevant to the user
            int i = line.IndexOf(':');
            if (i == 0) return line;
            string errorMessage = line[(i + 1)..];

            return errorMessage.Trim();
        }

        public void DeleteAllFiles()
        {
            File.Delete(FH.GetExecutable());
            File.Delete(FH.FileName);
        }

    }
    public class CompilationErrorException : Exception
    {
        public CompilationErrorException() { }

        public CompilationErrorException(string error)
            : base("Compilation error:\n" + error) { }
    }
}
