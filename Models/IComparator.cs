using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public interface IComparator
    {
        public List<string> FindResults();
        public double CalculateAccuracy(List<string> correctAnswers);
        public void AddData(List<string> correctOutputStrings, List<string> calculatedOutputStrings);
    }
}
