using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public static class InputTestValues
    {
        public static List<TestingData> GenerateData(List<string> argumentTypes, List<string> argumentNames)
        {
            // get size of test data dictionaries
            var sizes = new List<int>();
            foreach (string type in argumentTypes)
                sizes.Add(TestLists[type].Count);

            //// get minimum input size
            int size = Enumerable.Min(sizes);

            // create IOData list
            var data = new List<TestingData>();
            for (int i = 0; i < size; i++)
            {
                var testArguments = new List<TestArgument>();
                foreach (string argument in argumentTypes)
                {

                    var valueList = TestLists[argument];        // obtain the appropriate data list
                    TestArgument testArgument = valueList[i];   // retrieve the appropriate test argument object
                    testArguments.Add(testArgument);            // add to list of testing arguments
                }

                // create a test data object             
                TestingData dataSet = new TestingData(testArguments);
                data.Add(dataSet);

            }

            return data;
        }

        private static readonly List<TestArgument> boolValues = new List<TestArgument>()
        {
            new TestArgument("True"), new TestArgument("False")
        };

        private static readonly List<TestArgument> byteValues = new List<TestArgument>()
        {
            new TestArgument("0"), new TestArgument("16"), new TestArgument("32"),
            new TestArgument("64"), new TestArgument("128"), new TestArgument("255")
        };

        private static readonly List<TestArgument> sbyteValues = new List<TestArgument>()
        {
            new TestArgument("0"), new TestArgument("8"), new TestArgument("16"),
            new TestArgument("32"), new TestArgument("64"), new TestArgument("128")
        };

        private static readonly List<TestArgument> charValues = new List<TestArgument>()
        {
            new TestArgument("a"), new TestArgument("b"), new TestArgument("c"),
            new TestArgument("d"), new TestArgument("e"), new TestArgument("f")
        };

        private static readonly List<TestArgument> decimalValues = new List<TestArgument>()
        {
            new TestArgument("0"), new TestArgument("1000"), new TestArgument("1000000"),
            new TestArgument("1000000000000"), new TestArgument("1000000000000000000000"), new TestArgument("10000000000000000000000000000")
        };

        private static readonly List<TestArgument> doubleValues = new List<TestArgument>()
        {
            new TestArgument("0"), new TestArgument("1000"), new TestArgument("1000000"),
            new TestArgument("1000000000000"), new TestArgument("1000000000000000000000"), new TestArgument("100000000000000000000000000000000000000")
        };

        private static readonly List<TestArgument> floatValues = new List<TestArgument>()
        {
            new TestArgument("0"), new TestArgument("1000"), new TestArgument("1000000"),
            new TestArgument("1000000000000"), new TestArgument("1000000000000000000000"), new TestArgument("100000000000000000000000000000000000000")
        };

        private static readonly List<TestArgument> intValues = new List<TestArgument>()
        {
            new TestArgument("1"), new TestArgument("100"), new TestArgument("10000"),
            new TestArgument("1000000"), new TestArgument("10000000"), new TestArgument("2000000000")
        };

        private static readonly List<TestArgument> uintValues = new List<TestArgument>()
        {
            new TestArgument("1"), new TestArgument("100"), new TestArgument("2000"),
            new TestArgument("50000"), new TestArgument("20000000"), new TestArgument("4000000000")
        };

        private static readonly List<TestArgument> longValues = new List<TestArgument>()
        {
            new TestArgument("1"), new TestArgument("100"), new TestArgument("10000"),
            new TestArgument("1000000"), new TestArgument("1000000000000"), new TestArgument("1000000000000000000")
        };

        private static readonly List<TestArgument> ulongValues = new List<TestArgument>()
        {
            new TestArgument("1"), new TestArgument("100"), new TestArgument("100000"),
            new TestArgument("10000000"), new TestArgument("1000000000000"), new TestArgument("10000000000000000000")
        };

        private static readonly List<TestArgument> shortValues = new List<TestArgument>()
        {
            new TestArgument("1"), new TestArgument("10"), new TestArgument("100"),
            new TestArgument("1000"), new TestArgument("8000"), new TestArgument("30000")
        };

        private static readonly List<TestArgument> ushortValues = new List<TestArgument>()
        {
            new TestArgument("1"), new TestArgument("10"), new TestArgument("100"),
            new TestArgument("1000"), new TestArgument("10000"), new TestArgument("60000")
        };

        private static readonly List<TestArgument> stringValues = new List<TestArgument>()
        {
            new TestArgument("a"), new TestArgument("aaaaaaaaaa"), new TestArgument("aaaaaaaaaaaaaaaaaaa"),
            new TestArgument("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"),
            new TestArgument( "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")
        };

        private static readonly List<TestArgument> boolArrayValues = new List<TestArgument>()
        {
            new TestArgument("bool", 1), new TestArgument("bool",10), new TestArgument("bool", 100),
            new TestArgument("bool", 10000), new TestArgument("bool", 100000), new TestArgument("bool", 1000000)
        };

        private static readonly List<TestArgument> byteArrayValues = new List<TestArgument>()
        {
            new TestArgument("byte", 1), new TestArgument("byte",10), new TestArgument("byte", 100),
            new TestArgument("byte", 10000), new TestArgument("byte", 100000), new TestArgument("byte", 1000000)
        };

        private static readonly List<TestArgument> sbyteArrayValues = new List<TestArgument>()
        {
            new TestArgument("sbyte", 1), new TestArgument("sbyte",10), new TestArgument("sbyte", 100),
            new TestArgument("sbyte", 10000), new TestArgument("sbyte", 100000), new TestArgument("sbyte", 1000000)
        };

        private static readonly List<TestArgument> charArrayValues = new List<TestArgument>()
        {
            new TestArgument("char", 1), new TestArgument("char",10), new TestArgument("char", 100),
            new TestArgument("char", 10000), new TestArgument("char", 100000), new TestArgument("char", 1000000)
        };

        private static readonly List<TestArgument> decimalArrayValues = new List<TestArgument>()
        {
            new TestArgument("decimal", 1), new TestArgument("decimal",10), new TestArgument("decimal", 100),
            new TestArgument("decimal", 10000), new TestArgument("decimal", 100000), new TestArgument("decimal", 1000000)
        };

        private static readonly List<TestArgument> doubleArrayValues = new List<TestArgument>()
        {
            new TestArgument("double", 1), new TestArgument("double",10), new TestArgument("double", 100),
            new TestArgument("double", 10000), new TestArgument("double", 100000), new TestArgument("double", 1000000)
        };

        private static readonly List<TestArgument> floatArrayValues = new List<TestArgument>()
        {
            new TestArgument("float", 1), new TestArgument("float",10), new TestArgument("float", 100),
            new TestArgument("float", 10000), new TestArgument("float", 100000), new TestArgument("float", 1000000)
        };

        private static readonly List<TestArgument> intArrayValues = new List<TestArgument>()
        {
            new TestArgument("int", 1), new TestArgument("int",10), new TestArgument("int", 100),
            new TestArgument("int", 10000), new TestArgument("int", 100000), new TestArgument("int", 1000000)
        };

        private static readonly List<TestArgument> uintArrayValues = new List<TestArgument>()
        {
            new TestArgument("uint", 1), new TestArgument("uint",10), new TestArgument("uint", 100),
            new TestArgument("uint", 10000), new TestArgument("uint", 100000), new TestArgument("uint", 1000000)
        };

        private static readonly List<TestArgument> longArrayValues = new List<TestArgument>()
        {
            new TestArgument("long", 1), new TestArgument("long",10), new TestArgument("long", 100),
            new TestArgument("long", 10000), new TestArgument("long", 100000), new TestArgument("long", 1000000)
        };

        private static readonly List<TestArgument> ulongArrayValues = new List<TestArgument>()
        {
            new TestArgument("ulong", 1), new TestArgument("ulong",10), new TestArgument("ulong", 100),
            new TestArgument("ulong", 10000), new TestArgument("ulong", 100000), new TestArgument("ulong", 1000000)
        };

        private static readonly List<TestArgument> shortArrayValues = new List<TestArgument>()
        {
            new TestArgument("short", 1), new TestArgument("short",10), new TestArgument("short", 100),
            new TestArgument("short", 10000), new TestArgument("short", 100000), new TestArgument("short", 1000000)
        };

        private static readonly List<TestArgument> ushortArrayValues = new List<TestArgument>()
        {
            new TestArgument("ushort", 1), new TestArgument("ushort",10), new TestArgument("ushort", 100),
            new TestArgument("ushort", 10000), new TestArgument("ushort", 100000), new TestArgument("ushort", 1000000)
        };

        private static readonly List<TestArgument> stringArrayValues = new List<TestArgument>()
        {
            new TestArgument("string", 1), new TestArgument("string",10), new TestArgument("string", 100),
            new TestArgument("string", 10000), new TestArgument("string", 100000), new TestArgument("string", 1000000)
        };

        private static readonly Dictionary<string, List<TestArgument>> TestLists = new Dictionary<string, List<TestArgument>>()
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
            {"bool[]", boolArrayValues },
            {"byte[]", byteArrayValues },
            {"sbyte[]", sbyteArrayValues },
            {"char[]", charArrayValues },
            {"decimal[]", decimalArrayValues },
            {"double[]", doubleArrayValues },
            {"float[]", floatArrayValues },
            {"int[]", intArrayValues },
            {"uint[]", uintArrayValues },
            {"long[]", longArrayValues },
            {"ulong[]", ulongArrayValues },
            {"short[]", shortArrayValues },
            {"ushort[]", ushortArrayValues },
            {"string[]", stringArrayValues },
        };

    }
}
