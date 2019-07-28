using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using CustomTestingFramework.Utilities;
using CustomTestingFramework.Attributes;
using CustomTestingFramework.Exceptions;
using CustomTestingFramework.TestRunner.Contracts;

namespace CustomTestingFramework.TestRunner
{
    public class TestRunner : ITestRunner
    {
        private readonly ICollection<string> resultInfo;

        public TestRunner()
        {
            this.resultInfo = new List<string>();
        }

        public ICollection<string> Run(string assemblyPath)
        {
            var testClasses = Assembly
                .LoadFrom(assemblyPath)
                .GetTypes()
                .Where(x => x.HasAttribute<TestClassAttribute>())
                .ToList();

            foreach (var testClass in testClasses)
            {
                var testMethods = testClass
                    .GetMethods()
                    .Where(x => x.HasAttribute<TestMethodAttribute>())
                    .ToList();

                var testClassInstance = Activator.CreateInstance(testClass);

                foreach (var methodInfo in testMethods)
                {
                    try
                    {
                        methodInfo.Invoke(testClassInstance, null);

                        resultInfo.Add($"Method: {methodInfo.Name} - passed!");
                    }
                    catch (TestException te)
                    {

                        resultInfo.Add($"Method: {methodInfo.Name} - failed!");
                    }
                    catch
                    {
                        resultInfo.Add($"Method: {methodInfo.Name} - unexpected error occured!");
                    }
                }
            }

            return resultInfo;
        }
    }
}
