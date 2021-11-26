using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Management;

namespace AlgorithmTester.Models
{
    public class CodeCompiler
    {
        public FileHandler FH { get; set; }
        public int MaxExecutionTime { get; set; }

        public CodeCompiler(List<string> argumentTypes, string code)
        {
            this.FH = new FileHandler(argumentTypes, code);
        }

        public void Compile()
        {
            FH.CreateTempCSFile();

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

        public Task<string> RunExecutable(string arguments)
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

            // if the process has not finished within a certain time, abort the process
            Timer timer = new Timer(_ => KillAllProcesses(proc.Id), null, MaxExecutionTime, -1);

            return proc.StandardOutput.ReadLineAsync();
          
        }

        public void KillAllProcesses(int processId)
        {
            Debug.WriteLine("killing process");
            ManagementObjectSearcher processSearcher = new ManagementObjectSearcher
                ("Select * From Win32_Process Where ParentProcessID=" + processId);
            ManagementObjectCollection processCollection = processSearcher.Get();

            try
            {
                Process proc = Process.GetProcessById(processId);
                if (!proc.HasExited) proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }

            if (processCollection != null)
            {
                foreach (ManagementObject mo in processCollection)
                {
                    KillAllProcesses(Convert.ToInt32(mo["ProcessID"])); //kill child processes(also kills childrens of childrens etc.)
                }
                
            }
        }

        public void CheckCompilation(string compilationOutput)
        {
            // the compilation will have succeeded if a .exe file is created
            if (!File.Exists(FH.GetExecutable()))
            {
                string errorMessage = ExtractErrorMessage(compilationOutput);
                if (String.IsNullOrEmpty(errorMessage))
                    throw new CompilationErrorException("Do you have csc compiler installed?");
                else
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
            try
            {
                File.Delete(FH.GetExecutable());
                File.Delete(FH.FileName);
            }
            catch(Exception)
            {
                Debug.WriteLine("Files could not be deleted");
            }
            
        }

    }
    public class CompilationErrorException : Exception
    {
        public CompilationErrorException() { }

        public CompilationErrorException(string error)
            : base("Compilation error:\n" + error) { }
    }

    public class ExecutionErrorException : Exception
    {
        public ExecutionErrorException() { }

        public ExecutionErrorException(string error)
            : base("Execution error:\n" + error) { }
    }
}
