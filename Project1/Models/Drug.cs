﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Models
{
    class Drug
    {
        public string Name { get; }
        public int Id { get; }
        public DrugType Type { get; }

        public int Price { get; }
        public int Count { get; }

        private static int _counter = 0;

        public Drug()
        {
            _counter++;
            Id = _counter;
        }

        public Drug(string name, DrugType type, int price, int count): this()
        {
            Name = name;
            Type = type;
            Price = price;
            Count = count;
        }

        public override string ToString()
        {
            return $"{Id} Name: {Name} Price: {Price} Count: {Count}";
        }
    }
}
