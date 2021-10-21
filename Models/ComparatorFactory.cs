using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class ComparatorFactory
    {
        public static readonly Dictionary<string, IComparator> ComparatorConstructor = new Dictionary<string, IComparator>()
            {
                {"bool",  null},
                {"byte",  null},
                {"sbyte",  null},
                {"char",  null},
                {"decimal",  new FloatComparator<decimal>()},
                {"double",  new FloatComparator<double>()},
                {"float",  new FloatComparator<float>()},
                {"int",  new IntComparator<int>()},
                {"uint",  new IntComparator<int>()},
                {"long",  new IntComparator<int>()},
                {"ulong",  new IntComparator<int>()},
                {"short",  new IntComparator<int>()},
                {"ushort",  new IntComparator<int>()},
                {"string",  null}
            };

        public static IComparator GetComparator(string identifier)
        {
            return ComparatorConstructor[identifier];
        }
    }
}
