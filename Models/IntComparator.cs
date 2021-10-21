using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class IntComparator<T> : IComparator
    {
        public List<T> CorrectOutput { get; set; }
        public List<T> CalculatedOutput { get; set; }

        public void AddData(List<string> correctOutputStrings, List<string> calculatedOutputStrings)
        {
            this.CorrectOutput = TypeConverter.GetTypeFromStringList<T>(correctOutputStrings);
            this.CalculatedOutput = TypeConverter.GetTypeFromStringList<T>(calculatedOutputStrings);
        }

        public List<bool> FindCorrectData()
        {
            return new List<bool>();
        }
        public double CalculateAccuracy()
        {
            return 0;
        }

    }
}
