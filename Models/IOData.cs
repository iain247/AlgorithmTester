﻿using System;
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
        public List<object> Input { get; set; }
        public object Output { get; set; }

        public IOData(List<string> input, string output)
        {
            this.InputData = input;
            this.OutputData = output;
            Input = new List<object>();
        }

        /*
         * Returns the input values separated by commas
         */
        public string GetCommandLineArguments()
        {
            return string.Join(' ', InputData);
        }

        public void CastInputs(List<string> inputTypes)
        {
            Debug.WriteLine(inputTypes.Count);
            Debug.WriteLine(InputData.Count);
            for (int i=0; i<inputTypes.Count; i++)
            {
                Input.Add(Cast(inputTypes[i], InputData[i]));
            }
        }

        public void CastOutput(string outputType)
        {
            Output = Cast(outputType, OutputData);
        }

        private object Cast(string type, object value)
        {
            switch (type)
            {
                case "bool":
                    value = Convert.ToBoolean(value);
                    break;
                case "byte":
                    value = Convert.ToByte(value);
                    break;
                case "sbyte":
                    value = Convert.ToSByte(value);
                    break;
                case "char":
                    value = Convert.ToChar(value);
                    break;
                case "decimal":
                    value = Convert.ToDecimal(value);
                    break;
                case "double":
                    value = Convert.ToDouble(value);
                    break;
                case "float":
                    value = Convert.ToSingle(value);
                    break;
                case "int":
                    value = Convert.ToInt32(value);
                    break;
                case "uint":
                    value = Convert.ToUInt32(value);
                    break;
                case "long":
                    value = Convert.ToInt64(value);
                    break;
                case "ulong":
                    value = Convert.ToUInt64(value);
                    break;
                case "short":
                    value = Convert.ToInt16(value);
                    break;
                case "ushort":
                    value = Convert.ToUInt16(value);
                    break;
            }
            return value;
        }

        public void PrintDataSet()
        {
            Debug.Write("input: ");
            foreach (string input in InputData)
            {
                Debug.Write(input + " ");
            }
            Debug.WriteLine("\noutput: " + OutputData);
        }

        public void PrintDataTypes()
        {
            Debug.Write("input: ");
            foreach (object input in Input)
            {
                Debug.Write(input.GetType() + " ");
            }
            Debug.WriteLine("\noutput: " + Output.GetType());
        }
    }

}
