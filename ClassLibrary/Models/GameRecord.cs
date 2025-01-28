using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;

namespace ClassLibrary.Models
{

    public class GameRecord
    {
        public int Id { get; set; }
        public string PlayerMove { get; set; } = string.Empty;
        public string ComputerMove { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public DateTime GameDate { get; set; }
        public double UserWinRate { get; set; }
        public double ComputerWinRate { get; set; }

    }
}
