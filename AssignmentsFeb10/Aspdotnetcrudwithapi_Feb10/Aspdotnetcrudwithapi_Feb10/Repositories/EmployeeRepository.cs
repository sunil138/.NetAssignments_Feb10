using Aspdotnetcrudwithapi_Feb10.Models;

namespace Aspdotnetcrudwithapi_Feb10.Repositories
{
    public class EmployeeRepository
    {
        //add context file
        private readonly EmployeeContext _employeeContext;
        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

    }
}
