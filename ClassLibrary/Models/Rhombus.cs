using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class Rhombus : Shape
    {
        public double Diagonal1 { get; set; }
        public double Diagonal2 { get; set; }
        public double Side { get; set; }

        public override double CalculateArea()
        {
            return 0.5 * Diagonal1 * Diagonal2;
        }

        public override double CalculatePerimeter()
        {
            return 4 * Side;
        }
    }
}