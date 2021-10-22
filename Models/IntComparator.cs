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
            var correctAnswers = new List<bool>();
            for (int i=0; i<CorrectOutput.Count; i++)
            {
                correctAnswers[i] = (CorrectOutput[i].Equals(CalculatedOutput[i]));
            }
            return correctAnswers;
        }
        public double CalculateAccuracy(List<bool> correctAnswers)
        {
            double NoOfCorrect = correctAnswers.Count(x => x);

            return 100 * NoOfCorrect / correctAnswers.Count;
        }

    }
}
