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
        public InputParser IP { get; set; }


        public FileHandler(InputParser ip)
        {
            this.IP = ip;
            this.Code = ip.Code;
            this.FileName = string.Empty;
        }

        /*
         * This method creates a temporary file in the user's temp folder
         */
        public void CreateTempCSFile()
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

            UpdateTempFile();
        }

        /* This method writes the user supplied code to the new file.
         * It adds additional code to allow the user's code to be run
         */
        public void UpdateTempFile()
        {
            List<string> argumentTypes = IP.ArgumentTypes;
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
        Print(Solution.Algorithm(" + GetArguments(variableNames) + @"));
    }
    public static T GetTypeFromString<T> (string typeString)
    {
        var foo = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
        return (T)(foo.ConvertFromInvariantString(typeString));
    }
    public static string[] ConvertStringToArray(string arrayString)
    {
        string allElements = arrayString.Replace(" + "\"[\", \"\").Replace(\"]\", \"\");" + @"
        return allElements.Split(',');
    }
    public static T[] GetTypeFromArrayString<T>(string value)
    {
        if (value.Contains(" + "\"array_test-\"))" + @"
            return new T[System.Int32.Parse(value.Substring(11))];
        else
            return System.Array.ConvertAll(ConvertStringToArray(value), i => GetTypeFromString<T>(i));
    }
    public static void Print(object value)
    {
        if (value.GetType().IsArray)
        {
            var array = value as System.Array;
            string output = " + "\"[\";" + @"
            foreach(var foo in array)
                output += foo + " + "\",\";" + @"
            System.Console.WriteLine(output.Substring(0, output.Length -1) + " + "\"]\");" + @"
        }
        else System.Console.WriteLine(value);          
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
                if (CheckArray(type))
                {
                    //castingCode += type + " " + variables[i] + " = System.Array.ConvertAll(ConvertStringToArray(args[" + i + "]), foo => GetTypeFromString<" + GetElementType(type) + ">(foo));\n";
                    castingCode += type + " " + variables[i] + " = GetTypeFromArrayString<" + GetElementType(type) + ">(args[" + i + "]);\n";
                }
                else
                    castingCode += type + " " + variables[i] + " = GetTypeFromString<" + type + ">(args[" + i + "]);\n";
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

        /*
         * Checks if the argument is an array
         */
        private bool CheckArray(string argument)
        {
            return (argument.Contains('[') && argument.Contains(']'));
        }

        /*
         * Removes the square brackets from the type to get its element type
         */
        private string GetElementType(string argument)
        {
            return argument.Remove(argument.Length - 2);
        }
    }

}
