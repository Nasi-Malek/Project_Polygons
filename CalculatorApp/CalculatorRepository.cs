using Spectre.Console;
using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using CalculatorApp;


namespace CalculatorApp
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private readonly AppDbContext _context;

        public CalculatorRepository(AppDbContext context)
        {
            _context = context;
        }

        public void SaveCalculation(double? num1, double? num2, string operation, double result)
        {
            var calculation = new ClassLibrary.Models.CalculationRecord
            {
                Num1 = num1,
                Num2 = num2,
                Operation = operation,
                Result = result,
                Date = DateTime.Now
            };
            _context.CalculationRecords.Add(calculation);
            _context.SaveChanges();
        }

        public void DisplayAllCalculations()
        {
            var calculations = _context.CalculationRecords.ToList();

            if (!calculations.Any())
            {
                AnsiConsole.Markup("[red]No calculations found in the database.[/]\n");
                return;
            }

            var table = new Table();
            table.AddColumn("ID");
            table.AddColumn("First Number");
            table.AddColumn("Operation");
            table.AddColumn("Second Number");
            table.AddColumn("Result");
            table.AddColumn("Date");

            foreach (var calc in calculations)
            {
                table.AddRow(
                    calc.Id.ToString(),
                    calc.Num1?.ToString("F2") ?? "N/A",
                    calc.Operation,
                    calc.Num2?.ToString("F2") ?? "N/A",
                    calc.Result.ToString("F2"),
                    calc.Date.ToString("g"));
            }

            AnsiConsole.Write(table);
        }

        public bool UpdateCalculation(int id, double newNum1, double newNum2, double newResult)
        {
            var record = _context.CalculationRecords.IgnoreQueryFilters().FirstOrDefault(cr => cr.Id == id);
            if (record == null || record.IsDeleted) // Check if the record is soft-deleted
            {
                return false; // Prevent updating soft-deleted records
            }

            record.Num1 = newNum1;
            record.Num2 = newNum2;
            record.Result = newResult;
            record.Date = DateTime.Now;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteCalculation(int id)
        {
            var record = _context.CalculationRecords.Find(id);
            if (record == null) return false;

            record.IsDeleted = true;
            _context.SaveChanges();
            return true;
        }

        public bool RestoreCalculation(int id)
        {
            var record = _context.CalculationRecords.IgnoreQueryFilters().FirstOrDefault(cr => cr.Id == id && cr.IsDeleted);
            if (record == null) return false;

            record.IsDeleted = false;
            _context.SaveChanges();
            return true;
        }

        public CalculationRecord? GetCalculationById(int id)
        {
            var record = _context.CalculationRecords.IgnoreQueryFilters().FirstOrDefault(cr => cr.Id == id);
            if (record == null) return null;

            return new CalculationRecord
            {
                Id = record.Id,
                Num1 = record.Num1,
                Num2 = record.Num2,
                Operation = record.Operation,
                Result = record.Result,
                Date = record.Date,
                IsDeleted = record.IsDeleted
            };
        }
    }
}
