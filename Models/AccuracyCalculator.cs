using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    public class AccuracyCalculator : Comparator
    {
        public AccuracyCalculator(List<string> correctOutputStrings, List<string> calculatedOutputStrings, string type)
           : base(correctOutputStrings, calculatedOutputStrings, type) { }

        public override bool AreEqual(string correct, string calculated)
        {
            return correct.Equals(calculated);
        }
    }
}
