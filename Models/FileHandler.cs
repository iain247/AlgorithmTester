using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    /*
     * This class creates a temporary file to later be compiled and executed
     */
    public class FileHandler
    {
        public string FileName { get; set; }
        public string Code { get; set; }

        public FileHandler(string code)
        {
            this.Code = code;
            this.FileName = string.Empty;
        }

        /*
         * This method creates a temporary file in the user's temp folder
         */
        public void CreateTempFile()
        {
            try
            {
                string badFileName = Path.GetTempFileName();
                FileName = Path.ChangeExtension(badFileName, ".cs");
                Debug.WriteLine(FileName);

                // CHECK IF I NEED THESE LINES - IT THROWS FILENOTFOUNDEXCEPTION

                //FileInfo fileInfo = new FileInfo(FileName);
                //fileInfo.Attributes = FileAttributes.Temporary;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Cannot create file");
            }
        }

        /* This method writes the user supplied code to the new file.
         * It adds additional code to allow the user's code to be run
         */
        public void UpdateTempFile()
        {
            try
            {
                StreamWriter sw = File.AppendText(FileName);
                sw.WriteLine(Code);
                sw.WriteLine(
                @"public class CodeRunner
{
    public static void Main(string[] args)
    {
        object x = Solution.algorithm(" + 1 + @");
    }
}");
                sw.Flush();
                sw.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Cannot write to file");
            }
        }
        public string GetExecutable()
        {
            return Path.ChangeExtension(FileName, ".exe");
        }
    }
}
