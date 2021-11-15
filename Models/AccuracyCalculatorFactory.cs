using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class AccuracyCalculatorFactory
    {
        public static Comparator Create(List<string> correctOutputStrings, List<string> calculatedOutputStrings, string type)
        {
            var ComparatorConstructor = new Dictionary<string, Comparator>()
            {
                {"bool",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"byte",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"sbyte",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"char", new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"decimal",  new FloatAccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"double",  new FloatAccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"float",  new FloatAccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"int",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"uint",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"long",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"ulong",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"short",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"ushort",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"string",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"bool[]",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"byte[]",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"sbyte[]",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"char[]", new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"decimal[]",  new FloatAccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"double[]",  new FloatAccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"float[]",  new FloatAccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"int[]",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"uint[]",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"long[]",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"ulong[]",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"short[]",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"ushort[]",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)},
                {"string[]",  new AccuracyCalculator(correctOutputStrings, calculatedOutputStrings, type)}
            };
            return ComparatorConstructor[type];
        }
    }
}
