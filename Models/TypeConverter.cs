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
                {"string", typeof(string)}
            };

        public static Type GetType(string identifier)
        {
            return TypeDict[identifier];
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

        public static List<T> GetTypeFromStringList<T>(List<string> values)
        {
            var list = new List<T>();

            foreach (string value in values)
            {
                T castValue = GetTypefromString<T>(value);
                list.Add(castValue);
            }

            return list;
        }

        public static T GetTypefromString<T>(string value)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            return (T)(converter.ConvertFromInvariantString(value));
        }
    }
}
