using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    public class DepartmentService
    {
        List<Department> _departments;
        private static DepartmentService _instance;
        private readonly IRepository<Department> _departmentRepository;

        private DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public static DepartmentService Instance(IRepository<Department> departmentRepository)
        {
            if (_instance == null)
            {
                _instance = new DepartmentService(departmentRepository);
            }
            return _instance;
        }

        public List<Department> GetDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public bool AddDepartment(Department department)
        {
            foreach (var existingDepartment in _departmentRepository.GetAll())
            {
                if (existingDepartment.Name == department.Name)
                {
                    Console.WriteLine($"Department '{department.Name}' already exists.");
                    return false;
                }
            }

            _departmentRepository.Add(department);
            Console.WriteLine($"Department '{department.Name}' added successfully.");
            return true;
        }

        public bool RemoveDepartment(Guid departmentId)
        {
            _departments = _departmentRepository.GetAll();

            for (int i = 0; i < _departments.Count; i++)
            {
                if (_departments[i].Id == departmentId)
                {
                    _departmentRepository.Delete(departmentId);
                    Console.WriteLine($"Department with ID {departmentId} removed successfully.");
                    return true;
                }
            }
            Console.WriteLine($"Department with ID {departmentId} not found.");
            return false;
        }

    }
}
