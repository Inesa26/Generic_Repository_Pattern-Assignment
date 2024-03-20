using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private static EmployeeRepository? _instance;
        private readonly List<Employee> _employees;

        private EmployeeRepository()
        {
            _employees = new List<Employee>();
        }

        public static EmployeeRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeRepository();
                }
                return _instance;
            }
        }

        public void Add(Employee entity)
        {
            _employees.Add(entity);
        }

        public void Delete(Guid id)
        {
            for (int i = 0; i < _employees.Count; i++)
            {
                if (_employees[i].Id == id)
                {
                    _employees.RemoveAt(i);
                    break;
                }
            }
        }

        public Employee Get(Guid id)
        {
            foreach (var employee in _employees)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }
            return null;
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public void Update(Guid id, Employee entity)
        {
            for (int i = 0; i < _employees.Count; i++)
            {
                if (_employees[i].Id == id)
                {
                    _employees[i] = entity;
                    break;
                }
            }
        }
    }

}
