using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHarpNineConsoleApp
{
    public class Student
    {
        public string StudentName { get; init; }

        internal void PrintUserInfo()
        {
            Console.WriteLine(StudentName);
        }
        public override bool Equals(object obj)
        {
            if (obj is not Student other)
            {
                return false;
            }

            return this.StudentName == other.StudentName;

        }
    }
}
