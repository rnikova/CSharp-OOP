using System;
using CustomTestingFramework.Exceptions;

namespace CustomTestingFramework.Asserts
{
    public static class Assert
    {
        public static void AreEqual(object firstObject, object secondObject)
        {
            if (!firstObject.Equals(secondObject))
            {
                throw new TestException();
            }
        }

        public static void AreNotEqual(object firstObject, object secondObject)
        {
            if (firstObject.Equals(secondObject))
            {
                throw new TestException();
            }
        }

        public static void Throws<T>(Func<bool> condition)
            where T : Exception
        {
            try
            {
                condition.Invoke();
            }
            catch(T)
            {

            }
            catch
            {

                throw new TestException();
            }
        }
    }
}
