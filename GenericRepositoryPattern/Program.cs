
namespace GenericRepositoryPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var departmentRepository = DepartmentRepository.Instance;
            var employeeRepository = EmployeeRepository.Instance;

            // Create singleton instances of services
            var departmentService = DepartmentService.Instance(departmentRepository);
            var employeeService = EmployeeService.Instance(employeeRepository, departmentRepository);

            // Adding a new department
            Department newDepartment = new Department { Name = "Department 1" };
            departmentService.AddDepartment(newDepartment);
            departmentService.AddDepartment(new Department { Name = "Department 2" });

            // Attempt to create a duplicate department
            departmentService.AddDepartment(new Department { Name = "Department 1" });

            //Get list of Departments
            List<Department> departments = departmentService.GetDepartments();
            foreach (Department department in departments)
            {
                Console.WriteLine(department);
            }

            //Hiring a new employee
            Employee newEmployee = new Employee
            {
                Name = "Vlad",
                Surname = "Godorozea",
                Email = "Vladgodorozea@gmail.com",
                Date = new DateTime(1990, 7, 17),
            };

            employeeService.HireEmployee(newEmployee, newDepartment.Id);

            //Update data for existing employee
            employeeService.UpdateEmployee(newEmployee.Id, new Employee
            {
                Name = "Alex",
                Surname = "Godorozea",
                Email = "Alexgodorozea@gmail.com",
                Date = new DateTime(1993, 1, 28)
            });
            Console.WriteLine(newEmployee);
        }
    }
}
