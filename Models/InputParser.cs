using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Text.RegularExpressions;

namespace AlgorithmTester.Models
{
    /*
     * This class takes in the user inputted code, input, and output, and extracts the appropriate information
     */
    public class InputParser
    {
        public string Code { get; set; }
        public string MethodHeader { get; set; }
        public List<string> Input { get; set; }
        public List<string> Output { get; set; }
        public List<string> ArgumentTypes { get; set; }
        public List<string> ArgumentNames { get; set; }
        public List<IOData> DataSets { get; set; }
        public string Identifier { get; set; }
        public int NumOfArguments { get; set; }

        public static readonly string[] AllowedIdentifiers = new string[] { "bool", "byte", "sbyte", "char", "decimal", "double",
                "float", "int", "uint", "long", "ulong", "short", "ushort", "string", "bool[]", "byte[]", "sbyte[]", "char[]", "decimal[]", "double[]",
                "float[]", "int[]", "uint[]", "long[]", "ulong[]", "short[]", "ushort[]", "string[]" };


        public InputParser(String code, List<string> input, List<string> output)
        {
            this.Code = code;
            this.Input = input;
            this.Output = output;
            this.ArgumentTypes = new List<string>();
            this.ArgumentNames = new List<string>();
            this.DataSets = new List<IOData>();
        }

        public void ParseCode()
        {
            CheckClassHeader();
            FindMethodHeader();
            FindIdentifier();
            FindArguments();
            FindDataSets();
        }

        private void CheckClassHeader()
        {
            // check for the correct class header
            using StringReader sr = new StringReader(Code);
            string ClassHeader;
            do
            {
                ClassHeader = sr.ReadLine();
                if (ClassHeader is null)
                {
                    throw new InvalidCodeException("Invalid class header. Please use 'public class Solution'.");
                }
            }
            while (!ClassHeader.Contains("public class Solution"));
        }

        private void FindMethodHeader()
        {
            // check for the algorithm method
            using StringReader sr = new StringReader(Code);
            do
            {
                MethodHeader = sr.ReadLine();
                if (MethodHeader is null)
                {
                    throw new InvalidCodeException("A method named 'Algorithm' must be included");
                }
            }
            while (!MethodHeader.Contains("Algorithm"));

            // check that the method is static
            if (!MethodHeader.Contains("static"))
            {
                throw new InvalidCodeException("Algorithm method is not static");
            }
        }

        /*
         * This checks the IOData objects and returns true if the inputs are valid
         */
        public bool CheckArguments(IOData dataSet)
        {
            if (dataSet.InputData.Count != NumOfArguments)
                return false;

            // try cast each input to the appropriate type, if it can't be done return false
            for (int i = 0; i < NumOfArguments; i++)
            {
                if (!TypeConverter.CheckCast(dataSet.InputData[i], ArgumentTypes[i])) return false;
            }
            return true;
        }

        /*
         * This method extracts the return type from the user supplied code
         */
        private void FindIdentifier()
        {
            string[] methodHeaderWords = MethodHeader.Split(' ').Select(MethodHeaderWords => MethodHeaderWords.Trim()).ToArray();

            int identifierIndex = Array.IndexOf(methodHeaderWords, "static") + 1;

            Identifier = methodHeaderWords[identifierIndex];

            if (Identifier.Equals("void"))
                throw new InvalidCodeException("Algorithm must return a value");

            if (!AllowedIdentifiers.Contains(Identifier))
                throw new InvalidCodeException(Identifier + " is an invalid return type");
        }

        /*
         * Finds the type of each argument required by the user supplied code and returns them in a list
         */
        private void FindArguments()
        {
            // extract the arguments from the method header by finding substring between brackets
            int argumentsStartIndex = MethodHeader.IndexOf('(');
            int argumentsEndIndex = MethodHeader.IndexOf(')');
            int length = argumentsEndIndex - (argumentsStartIndex + 1);

            // split into comma seperated values and trim
            string argumentsString = MethodHeader.Substring(argumentsStartIndex + 1, length);  
            string[] arguments = argumentsString.Split(',').Select(arguments => arguments.Trim()).ToArray();

            // update number of arguments
            NumOfArguments = arguments.Length;
            
            // extract types and add to ArgumentTypes list
            int argumentsIndex = 0;
            foreach (string argument in arguments)
            {
                string[] foo = arguments[argumentsIndex++].Split(' ');
                string argumentType = foo[0];
                string argumentName = foo[1];

                if (!AllowedIdentifiers.Contains(argumentType))
                    throw new InvalidCodeException(argumentType + " is an invalid argument type.");

                ArgumentTypes.Add(argumentType);
                ArgumentNames.Add(argumentName);
            }
        }

        /*
         * This method uses the input and output data to create a list of IOData objects representing the tabulated input/output data
         */
        private void FindDataSets()
        {
            // loop through input and output
            for (int i=0; i<Input.Count; i++)
            {
                string inputSet = Input[i];
                string output = Output[i];

                // split input into separate arguments
                List<string> inputArguments = Regex.Split(inputSet, ",(?=[^\\]]*(?:\\[|$))").ToList<string>();


                DataSets.Add(new Models.IOData(inputArguments, output));
            }
        }

    }

    public class InvalidCodeException : Exception
    {
        public InvalidCodeException(string message)
            : base("Code Error: " + message) { }
    }

    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message)
            : base("Data Error: " + message) { }
    }
}
