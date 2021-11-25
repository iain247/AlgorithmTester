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
        public List<string> InputData { get; set; }
        public List<string> OutputData { get; set; }  
        public List<string> Results { get; set; }
        public List<TestingData> TestArguments { get; set; }
        public List<string> ArgumentNames { get; set; }
        public List<string> Times { get; set; }
        public int Timeout { get; set; }
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
            this.Code = "public class Solution\n{\n\tpublic static int Algorithm(int n)\n\t{\n\t\t//Enter code here\n\t\treturn 0;\n\t}\n}";
            this.InputData = new List<string>() { "", "", "" };
            this.OutputData = new List<string>() { "", "", "" };
            this.Results = new List<string>() { "", "", "" };
            this.Accuracy = "";
            this.UserMessage = String.Empty;
            this.Timeout = 10;
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
    }
}
