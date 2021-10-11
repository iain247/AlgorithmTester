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
    }
}
