using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHarpNineConsoleApp.CorrectDIP
{
    /*Dependency Inversion Principle
     * 
     * That’s it. We have implemented the Dependency Inversion Principle in our example where
     * the high-level module (EmployeeBusinessLogic) and low-level module (EmployeeDataAccess)
     * depend on abstraction (IEmployeeDataAccess). 
     * Also, abstraction (IEmployeeDataAccess) does not depend on details (EmployeeDataAccess) but details depend on abstraction.
     */
    public class EmployeeBusinessLogic
    {
        IEmployeeDataAccess _EmployeeDataAccess;
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
