using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    /*
     * This class represents a data structure for holding the input/output data used for testing the code
     */
    public class IOData
    {
        public List<string> InputData { get; set; }
        public string OutputData { get; set; }

        public IOData(List<string> input, string output)
        {
            this.InputData = input;
            this.OutputData = output;
        }

        public IOData(List<string> input)
        {
            this.InputData = input;
        }

        

        /*
         * Returns the input values separated by commas
         */
        public string GetCommandLineArguments()
        {
            return string.Join(' ', InputData);
        }

        public string ShowAllInputs()
        {
            return string.Join(',', InputData);
        }
    }
}
