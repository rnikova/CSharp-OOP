using System.Collections.Generic;

namespace CustomTestingFramework.TestRunner.Contracts
{
    public interface ITestRunner
    {
        ICollection<string> Run(string assemblyPath);
    }
}
