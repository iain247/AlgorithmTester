using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    public class AccuracyCalculator<T> : IComparator
    {
        public List<string> CorrectOutput { get; set; }
        public List<string> CalculatedOutput { get; set; }

        public void AddData(List<string> correctOutputStrings, List<string> calculatedOutputStrings)
        {
            this.CorrectOutput = correctOutputStrings;
            this.CalculatedOutput = calculatedOutputStrings;
        }
        public AccuracyCalculator()
        {
            CorrectOutput = new List<string>();
            CalculatedOutput = new List<string>();
        }

        public double CalculateAccuracy(List<bool> correctAnswers)
        {
            double NoOfCorrect = correctAnswers.Count(x => x);

            return 100 * NoOfCorrect / correctAnswers.Count;
        }

        public double CalculateAccuracy(List<string> correctAnswers)
        {
            double NoOfCorrect = correctAnswers.Count(x => x.Equals("correct"));

            return 100 * NoOfCorrect / correctAnswers.Count;
        }


        public List<string> FindResults()
        {
            var correctAnswers = new List<string>();
            for (int i = 0; i < CorrectOutput.Count; i++)
            {
                // check to see if the output has been tagged as invalid due to bad input data
                if (CalculatedOutput[i].Equals("InvalidInput"))
                {
                    correctAnswers.Add("Invalid Input");
                    continue;
                }
                // otherwise try casting the output
                try
                {
                    // first cast the values to the appropriate type
                    T castCorrectOutput = Cast(CorrectOutput[i]);
                    T castCalculatedOutput = Cast(CalculatedOutput[i]);

                    if (CorrectOutput[i].Equals(CalculatedOutput[i]))
                    {
                        correctAnswers.Add("correct");
                    }
                    else
                    {
                        correctAnswers.Add("incorrect");
                    }
                }
                // outputs which resulted in runtime errors will not be able to be cast correctly
                catch (Exception e)
                {
                    correctAnswers.Add("runtime error");
                }

            }
            return correctAnswers;
        }

        public T Cast(string value)
        {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            return (T)converter.ConvertFromInvariantString(value);
        }
    }
}
