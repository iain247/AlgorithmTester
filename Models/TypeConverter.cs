using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class TypeConverter
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
            //switch (type)
            //{
            //    case "bool":
            //        return Convert.ToBoolean(value);
            //    case "byte":
            //        return Convert.ToByte(value);
            //    case "sbyte":
            //        return Convert.ToSByte(value);
            //        break;
            //    case "char":
            //        return Convert.ToChar(value);
            //        break;
            //    case "decimal":
            //        return Convert.ToDecimal(value);
            //        break;
            //    case "double":
            //        return Convert.ToDouble(value);
            //        break;
            //    case "float":
            //        return Convert.ToSingle(value);
            //        break;
            //    case "int":
            //        castValue = Convert.ToInt32(value);
            //        break;
            //    case "uint":
            //        castValue = Convert.ToUInt32(value);
            //        break;
            //    case "long":
            //        castValue = Convert.ToInt64(value);
            //        break;
            //    case "ulong":
            //        castValue = Convert.ToUInt64(value);
            //        break;
            //    case "short":
            //        value = Convert.ToInt16(value);
            //        break;
            //    case "ushort":
            //        value = Convert.ToUInt16(value);
            //        break;
            //}
            //return value;
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
