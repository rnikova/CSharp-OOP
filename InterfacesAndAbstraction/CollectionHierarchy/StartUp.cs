using CollectionHierarchy.Core;
using CollectionHierarchy.Models;
using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
