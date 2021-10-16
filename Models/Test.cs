using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    public class Test
    {
        public FormModel FormData { get; set; }

        public Test(FormModel formData)
        {
            this.FormData = formData;
        } 

        public static void PrintValues(FormModel data)
        {
            System.Diagnostics.Debug.WriteLine("code: " + data.Code);
            try
            {
                
                for (int i = 0; i < data.InputData.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("input " + (i + 1) + ": " + data.InputData[i]);
                }
                for (int i = 0; i < data.OutputData.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("output " + (i + 1) + ": " + data.OutputData[i]);
                }

                
            } catch(System.NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
                System.Diagnostics.Debug.WriteLine("no input/output data");
            } finally
            {
                System.Diagnostics.Debug.WriteLine("accuracy: " + data.Accuracy);
                System.Diagnostics.Debug.WriteLine("speed: " + data.Speed);
            }
            
        }
    }
}
