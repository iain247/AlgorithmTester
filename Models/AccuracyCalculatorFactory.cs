using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class AccuracyCalculatorFactory
    {
        public static IComparator Create(string identifier)
        {
            var ComparatorConstructor = new Dictionary<string, IComparator>()
            {
                {"bool",  new AccuracyCalculator<bool>()},
                {"byte",  new AccuracyCalculator<byte>()},
                {"sbyte",  new AccuracyCalculator<sbyte>()},
                {"char", new AccuracyCalculator<char>()},
                {"decimal",  new AccuracyCalculator<decimal>()},
                {"double",  new AccuracyCalculator<double>()},
                {"float",  new AccuracyCalculator<float>()},
                {"int",  new AccuracyCalculator<int>()},
                {"uint",  new AccuracyCalculator<uint>()},
                {"long",  new AccuracyCalculator<long>()},
                {"ulong",  new AccuracyCalculator<ulong>()},
                {"short",  new AccuracyCalculator<short>()},
                {"ushort",  new AccuracyCalculator<ushort>()},
                {"string",  new AccuracyCalculator<string>()}
            };
            return ComparatorConstructor[identifier];
        }
    }
}
