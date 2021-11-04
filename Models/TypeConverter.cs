using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public static class TypeConverter
    {
        public static readonly Dictionary<string, Type> TypeDict = new Dictionary<string, Type>()
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

        public static Type GetType(string typeString)
        {
            return TypeDict[typeString];
        }

        public static string GetDefaultString(string typeString)
        {
            Type type = TypeDict[typeString];
            // if type is a value type, use activator to call the default constructor to get default value
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type).ToString();
            }
            // for reference type, the default value is null
            return null;
        }

        public static List<object> CastList(List<string> values, string type)
        {
            var newValues = new List<object>();

            foreach (string value in values)
            {
                var newValue = Cast(value, type);
                newValues.Add(newValue);
            }

            return newValues;
        }

        public static object Cast(string value, string typeString)
        {
            Type type = TypeDict[typeString];
            return Convert.ChangeType(value, type);
        }

        public static T[] GetTypeFromStringList<T>(string[] values)
        {
            var list = new T[values.Length];

            for (int i=0; i<values.Count(); i++)
            {
                T castValue = GetTypeFromString<T>(values[i]);
                list[i] = castValue;
            }

            return list;
        }

        public static T GetTypeFromString<T>(string value)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            return (T)(converter.ConvertFromInvariantString(value));
        }

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
                    System.Diagnostics.Debug.WriteLine("value: " + value);
                    foreach (string s in valueArray)
                    {
                        System.Diagnostics.Debug.WriteLine("value in valuearray: " + s);
                    }
                    
                    System.Array.ConvertAll(valueArray, foo => Convert.ChangeType(foo, type.GetElementType()));
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
