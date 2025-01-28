using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;

namespace ClassLibrary.Models
{

    public class CalculationRecord
    {
        public int Id { get; set; }
        public double? Num1 { get; set; }
        public double? Num2 { get; set; }
        public string Operation { get; set; } = string.Empty;
        public double Result { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

    }
}