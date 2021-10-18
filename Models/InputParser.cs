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
        public string MethodHeader { get; set; }
        public List<string> Input { get; set; }
        public List<string> Output { get; set; }


        public InputParser(String code, List<string> input, List<string> output)
        {
  
            this.Input = input;
            this.Output = output;
            FindMethodHeader(code);
        }

        private string FindMethodHeader(string code)
        {
            using StringReader sr = new StringReader(code);
            string methodHeader = null;
            do
            {
                MethodHeader = sr.ReadLine();
            }
            while (!MethodHeader.Contains("static"));

            return methodHeader;
        }

        /*
         * This method extracts the return type from the user supplied code
         */
        public string FindIdentifier()
        {
            string[] methodHeaderWords = MethodHeader.Split(' ').Select(MethodHeaderWords => MethodHeaderWords.Trim()).ToArray();

            // loop through the method header until the identifer is found
            int methodHeaderWordNum = 0;
            string[] nonIdentifers = new string[] { "private", "public", "static" };
            string identifier = null;
            do
            {
                identifier = methodHeaderWords[methodHeaderWordNum++];
            }
            while (Array.IndexOf(nonIdentifers, identifier) > -1);

            return identifier;
        }

        /*
         * Finds the type of each argument required by the user supplied code and returns them in a list
         */
        public List<string> FindArgumentTypes()
        {
            List<string> ArgumentTypes = new List<string>() ;

            // extract the arguments from the method header by finding substring between brackets
            int argumentsStartIndex = MethodHeader.IndexOf('(');
            int argumentsEndIndex = MethodHeader.IndexOf(')');
            int length = argumentsEndIndex - (argumentsStartIndex + 1);
            string argumentsString = MethodHeader.Substring(argumentsStartIndex + 1, length);

            // split into comma seperated values and trim
            string[] arguments = argumentsString.Split(',').Select(arguments => arguments.Trim()).ToArray();
            int argumentsIndex = 0;
            foreach (string argument in arguments)
            {
                ArgumentTypes.Add(arguments[argumentsIndex++].Split(' ')[0]);
            }
            return ArgumentTypes;
        }

        /*
         * This method uses the input and output data to create a list of IOData objects representing the tabulated input/output data
         */
        public List<IOData> FindDataSets()
        {
            // loop through input or output
            // create IOData objects for each data set
            List<IOData> DataSets = new List<IOData>();

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
}
