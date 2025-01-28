using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;


namespace ClassLibrary.Models
{
    public class ShapeRecord
    {
        public int Id { get; set; }
        public string ShapeName { get; set; } = string.Empty;
        public string Parameters { get; set; } = string.Empty;
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public DateTime CalculationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}