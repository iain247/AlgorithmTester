using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Models
{
    interface ISpeedTester
    {
        public void AddCompiler(CodeCompiler c);
        public List<double> FindTimes();
        public void GenerateTestData();
    }
}
