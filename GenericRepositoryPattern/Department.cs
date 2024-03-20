using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    public class Department : Entity
    {
        public string Name { get; set; }

        public override string? ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
    }
}
