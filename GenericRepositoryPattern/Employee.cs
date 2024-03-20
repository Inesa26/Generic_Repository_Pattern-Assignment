using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public Guid DepartmentId { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Surname: {Surname}, Date: {Date}, Email: {Email}, DepartmentId: {DepartmentId}";
        }
    }
}
