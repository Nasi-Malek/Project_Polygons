using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public abstract class Shape
    {
        public required string Name { get; set; }

        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
}

