using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace AlgorithmTester.Models
{
    public class FormModel
    {
        public string Code { get; set; }

        public int Accuracy { get; set; }

        public int Speed { get; set; }

        public List<string> InputData { get; set; }

        public List<string> OutputData { get; set; }

        public void PrintValues()
        {
            System.Diagnostics.Debug.WriteLine("code: " + Code);
            try
            {

                for (int i = 0; i < InputData.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("input " + (i + 1) + ": " + InputData[i]);
                }
                for (int i = 0; i < OutputData.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("output " + (i + 1) + ": " + OutputData[i]);
                }

            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                System.Diagnostics.Debug.WriteLine("no input/output data");
            }
            finally
            {
                System.Diagnostics.Debug.WriteLine("accuracy: " + Accuracy);
                System.Diagnostics.Debug.WriteLine("speed: " + Speed);
            }

        }
    }
}
