using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class TestArgument
    {
        public string Value { get; set; }
        public string Label { get; set; }
        public int Size { get; set; }

        public TestArgument(string value)
        {
            this.Value = value;
            this.Label = value;
        }

        public TestArgument(string type, int size)
        {
            this.Value = CreateArrayString(size, type);
            this.Label = type + " array of size " + size;
        }

        public string CreateArrayString(int size, string type)
        {
            // 
            return "array_test-" + size;
        }
    }

}