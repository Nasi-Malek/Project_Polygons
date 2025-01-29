using ClassLibrary.Models;
using Spectre.Console;

namespace ShapeApp.Controller
{
    public class RectangleController
    {
        private readonly IShapeRepository _repository;


        public RectangleController(IShapeRepository repository)
        {
            _repository = repository;
        }
        public void ControllerRectangle()
        {
            Console.Clear();
            AnsiConsole.Markup("[blue]Rectangle Calculation:[/]\n");

            double width = GetUserInput("Enter Width: ");
            double height = GetUserInput("Enter Height: ");

            var rectangle = new Rectangle { Name = "Rectangle", Width = width, Height = height };
            string parameters = $"Width: {width}, Height: {height}";

            SaveShapeToDatabase("Rectangle", parameters, rectangle.CalculateArea(), rectangle.CalculatePerimeter());
            DisplayShapeResults(rectangle);
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

        private void DisplayShapeResults(Rectangle rectangle)
        {
            AnsiConsole.Markup($"\n[green]Area: {rectangle.CalculateArea():F2}[/]");
            AnsiConsole.Markup($"\n[green]Perimeter: {rectangle.CalculatePerimeter():F2}[/]");
            AnsiConsole.Markup("\n[green]Press any key to return to the Shapes Menu...[/]");
            Console.ReadKey();
        }
        public Rectangle UpdateRectangle(ShapeRecord shapeRecord, out string updatedParameters)
        {
            double width = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Width:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            double height = AnsiConsole.Prompt(
                new TextPrompt<double>("[yellow]Enter new Height:[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive number.[/]")
                    .Validate(value => value > 0));

            updatedParameters = $"Width: {width}, Height: {height}";
            return new Rectangle { Name = "Rectangle", Width = width, Height = height };
        }

    }
}


