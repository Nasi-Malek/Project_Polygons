using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Handlers
{
    public class DeleteHandler
    {
        private readonly ICalculatorRepository _repository;

        public DeleteHandler(ICalculatorRepository repository)
        {
            _repository = repository;
        }

        public void DeleteCalculation()
        {
            Console.Clear();
            AnsiConsole.Markup("[blue]Delete Calculation:[/]\n");

            int id = GetValidId("Enter the ID of the calculation to delete: ");

            if (_repository.DeleteCalculation(id))
            {
                AnsiConsole.Markup("[green]Calculation deleted successfully![/]");
            }
            else
            {
                AnsiConsole.Markup("[red]Calculation not found.[/]");
            }

            Console.ReadKey();
        }

        private int GetValidId(string prompt)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<int>($"[yellow]{prompt}[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive integer.[/]")
                    .Validate(value => value > 0));
        }
    }
}
