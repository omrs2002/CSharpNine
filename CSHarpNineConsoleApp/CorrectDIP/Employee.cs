﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHarpNineConsoleApp.CorrectDIP
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"{ID}-{Name}  - Department:{Department} ,Salary:{Salary}";
        }
    }

}