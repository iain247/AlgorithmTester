using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AlgorithmTester.Models
{
    public class AccuracyCalculator : Comparator
    {
        //protected List<string> CorrectOutput { get; set; }
        //protected List<string> CalculatedOutput { get; set; }
        //protected string Type { get; set; }

        //public AccuracyCalculator(List<string> correctOutputStrings, List<string> calculatedOutputStrings, string type)
        //{
        //    this.CorrectOutput = correctOutputStrings;
        //    this.CalculatedOutput = calculatedOutputStrings;
        //    this.Type = type;
        //}

        //public double CalculateAccuracy(List<string> correctAnswers)
        //{
        //    // return -1 if no data supplied
        //    if (correctAnswers.Count() == 0) return -1;

        //    double NoOfCorrect = correctAnswers.Count(x => x.Equals("Correct"));

        //    return 100 * NoOfCorrect / correctAnswers.Count;
        //}


        //public List<string> FindResults()
        //{
        //    var correctAnswers = new List<string>();
        //    for (int i = 0; i < CorrectOutput.Count; i++)
        //    {
        //        // check to see if the output has been tagged as invalid due to bad input data
        //        if (CalculatedOutput[i].Equals("InvalidInput"))
        //            correctAnswers.Add("Invalid Input");

        //        // check to see if the output has been tagged as timing out
        //        else if (CalculatedOutput[i].Equals("Timeout"))
        //            correctAnswers.Add("Timeout");

        //        // check to see if output has been taged as causing a runtime error
        //        else if (CalculatedOutput[i].Equals("RuntimeError"))
        //            correctAnswers.Add("Runtime Error");

        //        // check to see if output is the correct type
        //        else if (!(TypeConverter.CheckCast(CorrectOutput[i], Type)))
        //            correctAnswers.Add("Invalid Output");

        //        // if casts are accepted, then check the accuracy of the calculated output
        //        else if (AreEqual(CalculatedOutput[i], CorrectOutput[i]))
        //            correctAnswers.Add("Correct");

        //        else
        //            correctAnswers.Add("Incorrect");
        //    }

        //    return correctAnswers;
        //}

        public AccuracyCalculator(List<string> correctOutputStrings, List<string> calculatedOutputStrings, string type)
           : base(correctOutputStrings, calculatedOutputStrings, type) { }

        public override bool AreEqual(string correct, string calculated)
        {
            System.Diagnostics.Debug.WriteLine("not comparing floats");
            return correct.Equals(calculated);
        }
    }
}
