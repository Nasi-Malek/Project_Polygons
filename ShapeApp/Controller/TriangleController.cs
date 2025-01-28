using ClassLibrary.Models;
using Spectre.Console;

namespace ShapeApp.Controller
{
    public class TriangleController
    {
        private readonly IShapeRepository _repository;

        public TriangleController(IShapeRepository repository)
        {
            _repository = repository;
        }

        public void ControllerTriangle()
        {
            Console.Clear();
            AnsiConsole.Markup("[blue]Triangle Calculation:[/]\n");

            double baseLength = GetUserInput("Enter Base: ");
            double height = GetUserInput("Enter Height: ");
            double sideA = GetUserInput("Enter Side A: ");
            double sideB = GetUserInput("Enter Side B: ");
            double sideC = GetUserInput("Enter Side C: ");

            var triangle = new Triangle { Name = "Triangle", Base = baseLength, Height = height, SideA = sideA, SideB = sideB, SideC = sideC };
            string parameters = $"Base: {baseLength}, Height: {height}, Sides: {sideA}, {sideB}, {sideC}";

            SaveShapeToDatabase("Triangle", parameters, triangle.CalculateArea(), triangle.CalculatePerimeter());
            DisplayShapeResults(triangle);
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

        private void DisplayShapeResults(Triangle triangle)
        {
            AnsiConsole.Markup($"\n[green]Area: {triangle.CalculateArea():F2}[/]");
            AnsiConsole.Markup($"\n[green]Perimeter: {triangle.CalculatePerimeter():F2}[/]");
            AnsiConsole.Markup("\n[green]Press any key to return to the Shapes Menu...[/]");
            Console.ReadKey();
        }
        public Triangle UpdateTriangle(ShapeRecord shapeRecord, out string updatedParameters)
        {
            double baseLength = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Base:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            double height = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Height:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            double sideA = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Side A:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            double sideB = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Side B:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            double sideC = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Side C:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            updatedParameters = $"Base: {baseLength}, Height: {height}, Sides: {sideA}, {sideB}, {sideC}";
            return new Triangle { Name = "Triangle", Base = baseLength, Height = height, SideA = sideA, SideB = sideB, SideC = sideC };
        }
    }

}
