using CustomTestingFramework.TestRunner.Contracts;
using System.Collections.Generic;

namespace CustomTestingFramework.TestRunner
{
    public class TestRunner : ITestRunner
    {
        private readonly ICollection<string> resultInfo;

        public TestRunner()
        {
            this.resultInfo = new List<string>();
        }

        public void Run()
        {

        }
    }
}
