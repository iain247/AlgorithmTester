using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public interface IComparator
    {
        public List<bool> FindCorrectData();
        public double CalculateAccuracy();
        public void AddData(List<string> correctOutputStrings, List<string> calculatedOutputStrings);
    }
}
