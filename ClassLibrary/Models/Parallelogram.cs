using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Parallelogram : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public double Side { get; set; }

        public override double CalculateArea()
        {
            return Base * Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (Base + Side);
        }
    }
}
