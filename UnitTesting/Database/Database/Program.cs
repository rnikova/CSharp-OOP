using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseProblem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Database db = new Database(1, 2);
            db.Add(3);
        }
    }
}
