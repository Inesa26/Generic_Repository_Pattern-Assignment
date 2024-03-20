using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    public class DepartmentRepository : IRepository<Department>
    {
        private static DepartmentRepository? _instance;
        private readonly List<Department> _departments;

        private DepartmentRepository()
        {
            _departments = new List<Department>();
        }

        public static DepartmentRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DepartmentRepository();
                }
                return _instance;
            }
        }

        public void Add(Department entity)
        {
            _departments.Add(entity);
        }

        public void Delete(Guid id)
        {
            for (int i = 0; i < _departments.Count; i++)
            {
                if (_departments[i].Id == id)
                {
                    _departments.RemoveAt(i);
                    break;
                }
            }
        }

        public Department Get(Guid id)
        {
            Department department = new Department();
            for (int i = 0; i < _departments.Count; i++)
            {
                if (_departments[i].Id == id)
                {
                    department = _departments[i];
                }
                return department;
            }
            return null;
        }

        public List<Department> GetAll()
        {
            return _departments;
        }

        public void Update(Guid id, Department entity)
        {
            Department department = new Department();
            for (int i = 0; i < _departments.Count; i++)
            {
                if (_departments[i].Id == id)
                {
                    department = _departments[i];
                }
            }
            if (department is not null)
            {
                department.Name = entity.Name;
            }

        }
    }
}
