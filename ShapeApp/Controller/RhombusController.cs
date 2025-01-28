using ClassLibrary.Models;
using Spectre.Console;

namespace ShapeApp.Controller
{
    public class RhombusController
    {
        private readonly IShapeRepository _repository;

        public RhombusController(IShapeRepository repository)
        {
            _repository = repository;
        }

        public void HandleRhombus()
        {
            Console.Clear();
            AnsiConsole.Markup("[blue]Rhombus Calculation:[/]\n");

            double diagonal1 = GetUserInput("Enter Diagonal 1: ");
            double diagonal2 = GetUserInput("Enter Diagonal 2: ");
            double side = GetUserInput("Enter Side Length: ");

            var rhombus = new Rhombus { Name = "Rhombus", Diagonal1 = diagonal1, Diagonal2 = diagonal2, Side = side };
            string parameters = $"Diagonal1: {diagonal1}, Diagonal2: {diagonal2}, Side: {side}";

            SaveShapeToDatabase("Rhombus", parameters, rhombus.CalculateArea(), rhombus.CalculatePerimeter());
            DisplayShapeResults(rhombus);
        }

        private double GetUserInput(string prompt)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<double>($"[yellow]{prompt}[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));
        }

        private void SaveShapeToDatabase(string shapeName, string parameters, double area, double perimeter)
        {
            try
            {
                _repository.SaveShape(shapeName, parameters, area, perimeter);
                AnsiConsole.Markup("[green]Shape saved successfully![/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.Markup($"[red]Error saving shape: {ex.Message}[/]");
            }
        }

        private void DisplayShapeResults(Rhombus rhombus)
        {
            AnsiConsole.Markup($"\n[green]Area: {rhombus.CalculateArea():F2}[/]");
            AnsiConsole.Markup($"\n[green]Perimeter: {rhombus.CalculatePerimeter():F2}[/]");
            AnsiConsole.Markup("\n[green]Press any key to return to the Shapes Menu...[/]");
            Console.ReadKey();
        }
        public Rhombus UpdateRhombus(ShapeRecord shapeRecord, out string updatedParameters)
        {
            double diagonal1 = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Diagonal 1:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            double diagonal2 = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Diagonal 2:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            double side = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Side Length:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            updatedParameters = $"Diagonal1: {diagonal1}, Diagonal2: {diagonal2}, Side: {side}";
            return new Rhombus { Name = "Rhombus", Diagonal1 = diagonal1, Diagonal2 = diagonal2, Side = side };
        }
    }

}
