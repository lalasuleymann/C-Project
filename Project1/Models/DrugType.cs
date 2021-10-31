using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models
{
    class DrugType
    {
        public int Id { get; }
        public string TypeName { get; set; }

        private static int _counter = 0;

        public DrugType()
        {
            _counter++;
            Id = _counter;
        }
        public DrugType(int id, string typeName): this()
        {
            Id = id;
            TypeName = typeName;
            _counter++;
            Id = _counter;
        }
        public override string ToString()
        {
            return $"{TypeName}";
        }
    }
}
