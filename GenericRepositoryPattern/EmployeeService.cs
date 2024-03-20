using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    public class EmployeeService
    {
        private static EmployeeService _instance;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;

        private EmployeeService(IRepository<Employee> employeeRepository, IRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public static EmployeeService Instance(IRepository<Employee> employeeRepository, IRepository<Department> departmentRepository)
        {
            if (_instance == null)
            {
                _instance = new EmployeeService(employeeRepository, departmentRepository);
            }
            return _instance;
        }

        public bool HireEmployee(Employee employee, Guid departmentId)
        {
            Department department = _departmentRepository.Get(departmentId);
            if (department == null)
            {
                Console.WriteLine($"Department with id: {departmentId} was not found.");
                return false;
            }
            employee.DepartmentId = departmentId;
            _employeeRepository.Add(employee);
            Console.WriteLine($"The employee {employee.Name} {employee.Surname} was successfully hired in department {department.Name}");
            return true;
        }

        public bool FireEmployee(Guid employeeId)
        {
            Employee employeeToRemove = _employeeRepository.Get(employeeId);
            if (employeeToRemove != null)
            {
                _employeeRepository.Delete(employeeId);
                Console.WriteLine($"Employee {employeeToRemove.Name} {employeeToRemove.Surname} has been terminated from employment.");
                return true;
            }
            else
            {
                Console.WriteLine($"Employee with id: {employeeId} was not found.");
                return false;
            }
        }

        public bool UpdateEmployee(Guid employeeId, Employee employee)
        {
            Employee existingEmployee = _employeeRepository.Get(employeeId);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Surname = employee.Surname;
                existingEmployee.Email = employee.Email;
                existingEmployee.Date = employee.Date;
                existingEmployee.DepartmentId = employeeId;

                _employeeRepository.Update(employeeId, existingEmployee);
                Console.WriteLine($"The data for employee {existingEmployee.Name} {existingEmployee.Surname} was successfully updated");
                return true;
            }
            else
            {
                Console.WriteLine($"Employee with id: {employeeId} was not found.");
                return false;
            }
        }
    }
}
