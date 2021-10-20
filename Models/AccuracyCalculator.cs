using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class AccuracyCalculator<T>
    {
        public string Identifier { get; set; }
        public List<T> CorrectOutputs { get; set; }
        public List<T> CalculatedOutput { get; set; }

        public static T GetTypefromString<T>(string mystring)
        {
            var foo = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            return (T)(foo.ConvertFromInvariantString(mystring));

        }
    }
}
