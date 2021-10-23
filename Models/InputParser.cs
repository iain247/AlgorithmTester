using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Collections;

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
        public string Identifier { get; set; }
        public int NumOfArguments { get; set; }

        public static readonly string[] AllowedIdentifiers = new string[] { "bool", "byte", "sbyte", "char", "decimal", "double",
                "float", "int", "uint", "long", "ulong", "short", "ushort"};


        public InputParser(String code, List<string> input, List<string> output)
        {
            this.Code = code;
            this.Input = input;
            this.Output = output;
            this.ArgumentTypes = new List<string>();
        }

        public void ParseCode()
        {
            CheckClassHeader();
            FindMethodHeader();
            FindIdentifier();
            FindArgumentTypes();
        }

        public void CheckClassHeader()
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

        public void FindMethodHeader()
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
                throw new InvalidCodeException("No static method found");
            }
        }

        public bool CheckArguments(IOData dataSet)
        {
            if (!(dataSet.InputData.Count == NumOfArguments))
                return false;

            // try cast each input to the appropriate type, if it can't be done return false
            for (int i=0; i<NumOfArguments; i++)
            {
                try
                {
                    TypeConverter.Cast(dataSet.InputData[i], ArgumentTypes[i]);
                }
                catch(Exception e)
                {
                    return false;
                }            
            }
            return true;        
        }

        /*
         * This method extracts the return type from the user supplied code
         */
        public void FindIdentifier()
        {
            string[] methodHeaderWords = MethodHeader.Split(' ').Select(MethodHeaderWords => MethodHeaderWords.Trim()).ToArray();

            int identifierIndex = Array.IndexOf(methodHeaderWords, "static") + 1;

            Identifier = methodHeaderWords[identifierIndex];

            if (!AllowedIdentifiers.Contains(Identifier))
                throw new InvalidCodeException(Identifier + " is an invalid return type. Return type must follow the static keyword");
        }

        /*
         * Finds the type of each argument required by the user supplied code and returns them in a list
         */
        public void FindArgumentTypes()
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
                string argumentType = arguments[argumentsIndex++].Split(' ')[0];

                if (!AllowedIdentifiers.Contains(argumentType))
                    throw new InvalidCodeException(argumentType + " is an invalid argument type.");

                ArgumentTypes.Add(argumentType);
            }
        }

        /*
         * This method uses the input and output data to create a list of IOData objects representing the tabulated input/output data
         */
        public List<IOData> FindDataSets()
        {
            // loop through input or output
            // create IOData objects for each data set
            List<IOData> DataSets = new List<IOData>();

            if (Input==null) throw new InvalidDataException("No data supplied");

            for (int i=0; i<Input.Count; i++)
            {
                string inputSet = Input[i];
                string output = Output[i];
                // split into comma seperated values and trim
                // also convert to object list
                List<string> inputArguments = inputSet.Split(',').Select(inputArguments => inputArguments.Trim()).ToList();

                DataSets.Add(new Models.IOData(inputArguments, output));
            }

            return DataSets;
        }

    }

    public class InvalidCodeException : Exception
    {
        public InvalidCodeException(string message)
            : base("Error with code: " + message) { }
    }

    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message)
            : base("Error with data: " + message) { }
    }
}
