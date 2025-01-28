using Microsoft.EntityFrameworkCore;
using ClassLibrary.Models;


namespace ClassLibrary.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var staticDate1 = new DateTime(2023, 1, 1, 12, 0, 0);
            var staticDate2 = new DateTime(2023, 1, 2, 12, 0, 0);
            var staticDate3 = new DateTime(2023, 1, 3, 12, 0, 0);
            var staticDate4 = new DateTime(2023, 1, 3, 14, 0, 0);


            modelBuilder.Entity<ShapeRecord>().HasData(
                new ShapeRecord { Id = 1, ShapeName = "Rectangle", Parameters = "Width: 6, Height: 12", Area = 72, Perimeter = 36, CalculationDate = staticDate1 },
                new ShapeRecord { Id = 2, ShapeName = "Parallelogram", Parameters = "Base: 8, Height: 5", Area = 40, Perimeter = 26, CalculationDate = staticDate2 },
                new ShapeRecord { Id = 3, ShapeName = "Triangle", Parameters = "Base: 7, Height: 3", Area = 10.5, Perimeter = 20, CalculationDate = staticDate3 },
                new ShapeRecord { Id = 4, ShapeName = "Rhombus", Parameters = "Diagonal1: 6, Diagonal2: 8", Area = 24, Perimeter = 28, CalculationDate = staticDate4 }
            );


            modelBuilder.Entity<CalculationRecord>().HasData(
                new CalculationRecord { Id = 1, Num1 = 15, Num2 = 5, Operation = "-", Result = 10, Date = staticDate1 },
                new CalculationRecord { Id = 2, Num1 = 9, Num2 = 3, Operation = "*", Result = 27, Date = staticDate2 },
                new CalculationRecord { Id = 3, Num1 = 20, Num2 = 4, Operation = "/", Result = 5, Date = staticDate3 },
                new CalculationRecord { Id = 4, Num1 = 8, Num2 = 2, Operation = "+", Result = 10, Date = staticDate4 }
            );


            modelBuilder.Entity<GameRecord>().HasData(
                new GameRecord { Id = 1, PlayerMove = "Rock", ComputerMove = "Scissors", Result = "Win", GameDate = staticDate1, UserWinRate = 100, ComputerWinRate = 0 },
                new GameRecord { Id = 2, PlayerMove = "Paper", ComputerMove = "Rock", Result = "Win", GameDate = staticDate2, UserWinRate = 75, ComputerWinRate = 25 },
                new GameRecord { Id = 3, PlayerMove = "Scissors", ComputerMove = "Rock", Result = "Loss", GameDate = staticDate3, UserWinRate = 50, ComputerWinRate = 50 }
            );
        }
    }
}