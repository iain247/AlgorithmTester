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
        public string TempPath { get; set; }
        public InputParser IP { get; set; }
        public List<IOData> DataSets { get; set; }

        public FileHandler(InputParser ip)
        {
            this.IP = ip;
            this.Code = ip.Code;
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
                // delete the old file extension
                File.Delete(badFileName);

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
            List<string> argumentTypes = IP.FindArgumentTypes();
            char[] variableNames = GenerateVariableNames(argumentTypes.Count);
            try
            {
                StreamWriter sw = File.AppendText(FileName);
                sw.WriteLine(Code);
                sw.WriteLine(
                @"
public class CodeRunner
{
    public static void Main(string[] args)
    {
        " +
        GetCastingCode(variableNames, argumentTypes) + @"
        System.Console.Write(Solution.algorithm(" + GetArguments(variableNames) + @"));
    }
    public static T GetTypeFromString<T> (string typeString)
    {
        var foo = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
        return (T)(foo.ConvertFromInvariantString(typeString));
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


        public string GetCastingCode(char[] variables, List<string> argumentTypes)
        {
            string castingCode = string.Empty;
            
            

            for (int i=0; i<argumentTypes.Count; i++)
            {
                string type = argumentTypes[i];
                castingCode += type + " " + variables[i] + " = GetTypeFromString<" + type + ">(args[" + i + "]); ";
            }

            return castingCode;
        }

        public char[] GenerateVariableNames(int n)
        {
            var variables = new char[n];

            Random random = new Random();
            const string characters = "abcdefghjijklmnopqrstuvwxyz";

            try
            {
                for (int i = 0; i < n; i++)
                {
                    variables[i] = characters[i];
                }
            }
            catch(IndexOutOfRangeException e)
            {
                Debug.WriteLine("Too many input variables");
            }

            return variables;
        }

        public string GetArguments(char[] variableNames)
        {
            return string.Join(',', variableNames);
        }

        public string GetExecutable()
        {
            return Path.ChangeExtension(FileName, ".exe");
        }

        public void DeleteAllFiles()
        {
            try
            {
                File.Delete(GetExecutable());
            }
            catch (Exception e1)
            {
                Debug.WriteLine("Could not delete executable");
            }
            try
            {
                File.Delete(FileName);
            }
            catch (Exception e2)
            {
                Debug.WriteLine("Could not delete .cs file");
            }
        }
    }
}
