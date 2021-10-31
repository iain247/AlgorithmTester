using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public static class InputTestValues
    {
        public const int TestValueSize = 6;

        private static readonly List<string> boolValues = new List<string>()
        {
            "True", "False"
        };

        private static readonly List<string> byteValues = new List<string>()
        {
            "0", "16", "32", "64", "128", "255"
        };

        private static readonly List<string> sbyteValues = new List<string>()
        {
            "0", "8", "16", "32", "64", "128"
        };

        private static readonly List<string> charValues = new List<string>()
        {
            "a", "b", "c", "d", "e", "f"
        };

        private static readonly List<string> decimalValues = new List<string>()
        {
            "0", "1000", "1000000", "1000000000000", "1000000000000000000000", "10000000000000000000000000000"
        };

        private static readonly List<string> doubleValues = new List<string>()
        {
            "0", "1000", "1000000", "1000000000000", "1000000000000000000000", "100000000000000000000000000000000000000"
        };

        private static readonly List<string> floatValues = new List<string>()
        {
            "0", "1000", "1000000", "1000000000000", "1000000000000000000000", "100000000000000000000000000000000000000"
        };

        private static readonly List<string> intValues = new List<string>()
        {
            "1", "100", "10000", "1000000", "10000000", "2000000000"
        };

        private static readonly List<string> uintValues = new List<string>()
        {
            "1", "100", "2000", "50000", "20000000", "4000000000"
        };

        private static readonly List<string> longValues = new List<string>()
        {
            "1", "100", "10000", "1000000", "1000000000000", "1000000000000000000"
        };

        private static readonly List<string> ulongValues = new List<string>()
        {
            "1", "100", "00000", "1000000", "1000000000000", "10000000000000000000"
        };

        private static readonly List<string> shortValues = new List<string>()
        {
            "1", "10", "100", "1000", "8000", "16000", "30000"
        };

        private static readonly List<string> ushortValues = new List<string>()
        {
            "1", "10", "100", "1000", "10000", "30000", "60000"
        };

        private static readonly List<string> stringValues = new List<string>()
        {
            "a", "aaaaaaaaaa", "aaaaaaaaaaaaaaaaaaa","aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
        };

        public static readonly Dictionary<string, List<string>> TestLists = new Dictionary<string, List<string>>()
        {
            {"bool", boolValues },
            {"byte", byteValues },
            {"sbyte", sbyteValues },
            {"char", charValues },
            {"decimal", decimalValues },
            {"double", doubleValues },
            {"float", floatValues },
            {"int", intValues },
            {"uint", uintValues },
            {"long", longValues },
            {"ulong", ulongValues },
            {"short", shortValues },
            {"ushort", ushortValues },
            {"string", stringValues },
            {"int[]", intValues } /// TEMPORARY FOR TESTING
        };


        public static IOData GenerateData(List<string> argumentTypes, int sizeIndex)
        {
            // size index must be between 0 and 5 to extract input test data
            if (sizeIndex < 0 || sizeIndex > 5) return null;

            var arguments = new List<string>();
            // loop through each argument in the arguments string
            foreach (string argument in argumentTypes)
            {
                var valueList = TestLists[argument];    // obtain the appropriate data list
                string argumentValue = valueList[sizeIndex];    // retrieve the appropriately sized argument value
                arguments.Add(argumentValue);
            }

            return new IOData(arguments);
        }

        public static List<IOData> GenerateData(List<string> argumentTypes, List<string> argumentNames)
        {
            // get size of test data dictionaries
            var sizes = new List<int>();
            foreach (string type in argumentTypes)
            {
                sizes.Add(TestLists[type].Count);
            }

            // get minimum input size
            int size = Enumerable.Min(sizes);

            // create IOData list
            var data = new List<IOData>();
            for (int i=0; i<size; i++)
            {
                var arguments = new List<string>();
                foreach (string argument in argumentTypes)
                {
                    var valueList = TestLists[argument];    // obtain the appropriate data list
                    string argumentValue = valueList[i];    // retrieve the appropriately sized argument value
                    arguments.Add(argumentValue);
                }
                IOData dataSet = new IOData(arguments);
                dataSet.AddArgumentNames(argumentNames);
                data.Add(dataSet);
            }

            return data;
        }

    }
}
