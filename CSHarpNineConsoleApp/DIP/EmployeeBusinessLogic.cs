using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHarpNineConsoleApp.DIP
{
    /*Dependency Inversion Principle
     * 
     * A high-level module is a module that always depends on other modules.
     * EmployeeBusinessLogic class depends on EmployeeDataAccess class
     * 
     * 
     * (1) So, as per the first rule of the Dependency Inversion Principle in C#, 
     * the EmployeeBusinessLogic class/module should not depend on the concrete EmployeeDataAccess class/module,
     * instead, both the classes should depend on abstraction.
     * 
     * (2) The second rule of the Dependency Inversion Principle state that 
     * “Abstractions should not depend on details. Details should depend on abstractions”.
    */

    public class EmployeeBusinessLogic
    {
        EmployeeDataAccess _EmployeeDataAccess;
        public EmployeeBusinessLogic()
        {
            _EmployeeDataAccess = DataAccessFactory.GetEmployeeDataAccessObj();
        }
        public Employee GetEmployeeDetails(int id)
        {
            return _EmployeeDataAccess.GetEmployeeDetails(id);
        }
    }

}
