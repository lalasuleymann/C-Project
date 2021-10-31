using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models
{
    partial class Pharmacy
    {
        private List<Drug> Drugs;
        public string Name { get; }
        public int Id { get; }

        private static int _counter = 0;

        public Pharmacy()
        {
            _counter++;
            Id = _counter;
        }
        public Pharmacy(string name): this()
        {
            Name = name;
            Drugs = new List<Drug>();
        }

        public override string ToString()
        {
            //return $"Id: {Id}  Name: {Name}";
            return Name;
        }
    }
}
