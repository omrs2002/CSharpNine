using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHarpNineConsoleApp.CorrectDIP
{
    public interface IEmployeeDataAccess
    {
        Employee GetEmployeeDetails(int id);
    }

}
