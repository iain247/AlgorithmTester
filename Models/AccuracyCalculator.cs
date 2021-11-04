using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    public class AccuracyCalculator//<T> : IComparator
    {
        public List<string> CorrectOutput { get; set; }
        public List<string> CalculatedOutput { get; set; }
        public string Type { get; set; }

        public AccuracyCalculator(List<string> correctOutputStrings, List<string> calculatedOutputStrings)
        {
            this.CorrectOutput = correctOutputStrings;
            this.CalculatedOutput = calculatedOutputStrings;
        }

        public AccuracyCalculator(List<string> correctOutputStrings, List<string> calculatedOutputStrings, string type)
        {
            this.CorrectOutput = correctOutputStrings;
            this.CalculatedOutput = calculatedOutputStrings;
            this.Type = type;
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
                    correctAnswers.Add("Invalid Input");

                // check to see if the output has been tagged as timing out
                else if (CalculatedOutput[i].Equals("Timeout"))
                    correctAnswers.Add("Timeout");

                // check to see if output has been taged as causing a runtime error
                else if (CalculatedOutput[i].Equals("RuntimeError"))
                    correctAnswers.Add("Runtime Error");

                // check to see if output is the correct type
                else if (!(TypeConverter.CheckCast(CorrectOutput[i], Type)))
                    correctAnswers.Add("Invalid Output");

                // if casts are accepted, then check the accuracy of the calculated output
                else if (CorrectOutput[i].Equals(CalculatedOutput[i]))
                    correctAnswers.Add("Correct");

                else
                    correctAnswers.Add("Incorrect");
            }
            
            return correctAnswers;
        }
    }
}
