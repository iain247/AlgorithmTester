using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class AccuracyCalculator
    {
        public IComparator Comparator { get; set; }


        public AccuracyCalculator(List<string> correctOutput, List<string> calculatedOutput, string type)
        {
            this.Comparator = ComparatorFactory.GetComparator(type);
            this.Comparator.AddData(correctOutput, calculatedOutput);       
        }

        
    }
}
