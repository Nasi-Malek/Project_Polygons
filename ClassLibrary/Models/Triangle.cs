using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }

        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }
    }
}
