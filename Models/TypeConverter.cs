using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public static class TypeConverter
    {
        private static readonly Dictionary<string, Type> TypeDict = new Dictionary<string, Type>()
            {
                {"bool",  typeof(bool)},
                {"byte",  typeof(byte)},
                {"sbyte",  typeof(sbyte)},
                {"char",  typeof(char)},
                {"decimal",  typeof(decimal)},
                {"double",  typeof(double)},
                {"float",  typeof(float)},
                {"int",  typeof(int)},
                {"uint",  typeof(uint)},
                {"long",  typeof(long)},
                {"ulong",  typeof(ulong)},
                {"short",  typeof(short)},
                {"ushort",  typeof(ushort)},
                {"string", typeof(string)},
                {"bool[]",  typeof(bool[])},
                {"byte[]",  typeof(byte[])},
                {"sbyte[]",  typeof(sbyte[])},
                {"char[]",  typeof(char[])},
                {"decimal[]",  typeof(decimal[])},
                {"double[]",  typeof(double[])},
                {"float[]",  typeof(float[])},
                {"int[]",  typeof(int[])},
                {"uint[]",  typeof(uint[])},
                {"long[]",  typeof(long[])},
                {"ulong[]",  typeof(ulong[])},
                {"short[]",  typeof(short[])},
                {"ushort[]",  typeof(ushort[])},
                {"string[]", typeof(string[])},
            };

        public static bool CheckCast(string value, string typeString)
        {
            try
            {
                Type type = TypeDict[typeString];
                
                // convert value to type
                if (!type.IsArray)
                {
                    Convert.ChangeType(value, type);
                    return true;
                }
                // try convert to an array
                else
                {
                    // remove the square brackets and create string array
                    string allElements = value.Replace("[", "").Replace("]", "");
                    string[] valueArray = allElements.Split(',').Select(x => x.Trim()).ToArray();

                    // convert each item in the array to the array's element type              
                    Array.ConvertAll(valueArray, foo => Convert.ChangeType(foo, type.GetElementType()));
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
