using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    public class FormModel
    {
        public string Code { get; set; }

        public string Accuracy { get; set; }

        public string Speed { get; set; }

        public List<string> InputData { get; set; }
        public List<string> OutputData { get; set; }  
        public List<string> Results { get; set; }
        private int _numData;
        public int NumData
        {
            get { return InputData.Count(x => x != ""); }
            set { _numData = value; }
        }
        public string UserMessage { get; set; }
        public FormModel()
        {
            // values to populate initial table
            Code = "public class Solution {\n\tpublic static int Algorithm(int n)\n\t{\n\t\t//Enter code here\n\t\treturn 0;\n\t}\n}";
            InputData = new List<string>() { "", "", "" };
            OutputData = new List<string>() { "", "", "" };
            Results = new List<string>() { "", "", "" };
            Accuracy = "";
            UserMessage = String.Empty;
        }


        public void PadData()
        {
            // if there is not enough data for the table's default size, pad with emptry strings
            if (NumData < 3)
            {
                for (int i = NumData; i < 3; i++)
                {
                    InputData.Add(String.Empty);
                    OutputData.Add(String.Empty);
                    Results.Add(String.Empty);
                }
            }
        }

        public void DeleteEmptyData()
        {
            int count = InputData.RemoveAll(x => x is null);
            OutputData.RemoveAll(x => x is null);
            Results.RemoveAll(x => x is null);
            NumData -= count;
        }

        public void PrintValues()
        {
            Debug.WriteLine("code: " + Code);
            try
            {

                for (int i = 0; i < InputData.Count; i++)
                {
                    Debug.WriteLine("input " + (i + 1) + ": " + InputData[i]);
                }
                for (int i = 0; i < OutputData.Count; i++)
                {
                    Debug.WriteLine("output " + (i + 1) + ": " + OutputData[i]);
                }
                Debug.WriteLine("Numer of data sets: " + NumData);

            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                Debug.WriteLine("no input/output data");
            }
            finally
            {
                Debug.WriteLine("accuracy: " + Accuracy);
                Debug.WriteLine("speed: " + Speed);
            }

        }
    }
}
