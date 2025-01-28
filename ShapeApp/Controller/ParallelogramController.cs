using ClassLibrary.Models;
using Spectre.Console;

namespace ShapeApp.Controller
{
    public class ParallelogramController
    {
        private readonly IShapeRepository _repository;

        public ParallelogramController(IShapeRepository repository)
        {
            _repository = repository;
        }

        public void ControllerParallelogram()
        {
            Console.Clear();
            AnsiConsole.Markup("[blue]Parallelogram Calculation:[/]\n");

            double baseLength = GetUserInput("Enter Base: ");
            double height = GetUserInput("Enter Height: ");
            double side = GetUserInput("Enter Side Length: ");

            var parallelogram = new Parallelogram { Name = "Parallelogram", Base = baseLength, Height = height, Side = side };
            string parameters = $"Base: {baseLength}, Height: {height}, Side: {side}";

            SaveShapeToDatabase("Parallelogram", parameters, parallelogram.CalculateArea(), parallelogram.CalculatePerimeter());
            DisplayShapeResults(parallelogram);
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

        private void DisplayShapeResults(Parallelogram parallelogram)
        {
            AnsiConsole.Markup($"\n[green]Area: {parallelogram.CalculateArea():F2}[/]");
            AnsiConsole.Markup($"\n[green]Perimeter: {parallelogram.CalculatePerimeter():F2}[/]");
            AnsiConsole.Markup("\n[green]Press any key to return to the Shapes Menu...[/]");
            Console.ReadKey();
        }

        public Parallelogram UpdateParallelogram(ShapeRecord shapeRecord, out string updatedParameters)
        {
            double baseLength = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Base:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            double height = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Height:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            double side = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Side Length:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            updatedParameters = $"Base: {baseLength}, Height: {height}, Side: {side}";
            return new Parallelogram { Name = "Parallelogram", Base = baseLength, Height = height, Side = side };
        }
    }
}

