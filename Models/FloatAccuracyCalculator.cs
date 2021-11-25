using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class FloatAccuracyCalculator : Comparator
    {
        public const double Precision = 0.0001;

        public FloatAccuracyCalculator(List<string> correctOutputStrings, List<string> calculatedOutputStrings, string type)
            : base(correctOutputStrings, calculatedOutputStrings, type) {}

        public override bool AreEqual(string correct, string calculated)
        {
            // if array string detected, convert and check each value
            if (correct.Contains("["))
            {
                var correctArray = Array.ConvertAll(ConvertStringToArray(correct), i => Convert.ToDouble(i));
                var calculatedArray = Array.ConvertAll(ConvertStringToArray(calculated), i => Convert.ToDouble(i));
                for (int i=0; i<correctArray.Length; i++)
                {
                    if (!Compare(correctArray[i], calculatedArray[i])) return false;
                }
                return true;
            }

            // else convert the float and compare 
            double correctValue = Convert.ToDouble(correct);
            double calculatedValue = Convert.ToDouble(calculated);

            return Compare(correctValue, calculatedValue);
        }

        private bool Compare(double correct, double calculated)
        {
            return (Math.Abs(correct - calculated) < Precision);
        }

        private string[] ConvertStringToArray(string arrayString)
        {
            string allElements = arrayString.Replace("[", "").Replace("]", "");
            return allElements.Split(',');
    }

    }
}
