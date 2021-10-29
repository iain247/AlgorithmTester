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
    
        public AccuracyCalculator(List<string> correctOutputStrings, List<string> calculatedOutputStrings)
        {
            this.CorrectOutput = correctOutputStrings;
            this.CalculatedOutput = calculatedOutputStrings;
        }

        public double CalculateAccuracy(List<string> correctAnswers)
        {
            double NoOfCorrect = correctAnswers.Count(x => x.Equals("Correct"));

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
                // first try casting the user supplied output to the appropriate type
                try
                {
                    
                    T castCorrectOutput = TypeConverter.GetTypefromString<T>(CorrectOutput[i]);
                }
                // if this causes error, then the user has provided invalid output
                catch(Exception)
                {
                    correctAnswers.Add("Invalid Output");
                    continue;
                }

                // next try casting the calculated output
                try
                {
                    T castCalculatedOutput = TypeConverter.GetTypefromString<T>(CalculatedOutput[i]);
                }
                // if this causes and error, then there has been a runtime error due to the input
                catch(Exception)
                {
                    correctAnswers.Add("Runtime Error");
                    continue;
                }

                // if casts are accepted, then check the accuracy of the calculated output
                if (CorrectOutput[i].Equals(CalculatedOutput[i]))
                {
                    correctAnswers.Add("Correct");
                }
                else
                {
                    correctAnswers.Add("Incorrect");
                }            
            }
            return correctAnswers;
        }
    }
}
