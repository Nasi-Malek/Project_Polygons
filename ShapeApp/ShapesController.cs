using ClassLibrary.Models;
using ShapeApp.Controller;
using Spectre.Console;

namespace ShapeApp
{
    public class ShapesController
    {
        private readonly IShapeRepository _repository;
        private readonly RectangleController _rectangleController;
        private readonly ParallelogramController _parallelogramController;
        private readonly TriangleController _triangleController;
        private readonly RhombusController _rhombusController;
        private readonly Dictionary<string, Action> _shapeOptions;

        // Inject dependencies via the constructor
        public ShapesController(
            IShapeRepository repository,
            RectangleController rectangleController,
            ParallelogramController parallelogramController,
            TriangleController triangleController,
            RhombusController rhombusController)
        {
            _repository = repository;
            _rectangleController = rectangleController;
            _parallelogramController = parallelogramController;
            _triangleController = triangleController;
            _rhombusController = rhombusController;

            // Use injected handlers
            _shapeOptions = new Dictionary<string, Action>
                        {
                            { "Rectangle", _rectangleController.ControllerRectangle },
                            { "Parallelogram", _parallelogramController.ControllerParallelogram },
                            { "Triangle", _triangleController.ControllerTriangle },
                            { "Rhombus", _rhombusController.HandleRhombus },
                            { "Display All Shapes", DisplayAllShapes },
                            { "Update Shape", UpdateShape },
                            { "Delete Shape", DeleteShape },
                            { "Back to Main Menu", () => throw new OperationCanceledException() }
                        };
        }

        public void ShowShapesMenu()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    string choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[green]Select an option:[/]")
                            .PageSize(10)
                            .AddChoices(_shapeOptions.Keys));

                    if (_shapeOptions.TryGetValue(choice, out var action))
                    {
                        action();
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    AnsiConsole.Markup($"[bold red]An unexpected error occurred: {ex.Message}[/]");
                    Console.ReadKey();
                }
            }
        }
        private void DisplayAllShapes()
        {
            Console.Clear();
            AnsiConsole.Markup("[blue]Displaying All Shapes:[/]\n");

            var shapes = _repository.GetAllShapes();
            if (shapes.Count == 0)
            {
                AnsiConsole.Markup("[red]No shapes found in the database.[/]");
            }
            else
            {
                var table = new Table();
                table.AddColumn("ID");
                table.AddColumn("Shape");
                table.AddColumn("Parameters");
                table.AddColumn("Area");
                table.AddColumn("Perimeter");
                table.AddColumn("Date");

                foreach (var shape in shapes)
                {
                    table.AddRow(
                        shape.Id.ToString(),
                        shape.ShapeName,
                        shape.Parameters,
                        shape.Area.ToString("F2"),
                        shape.Perimeter.ToString("F2"),
                        shape.CalculationDate.ToString("g"));
                }

                AnsiConsole.Write(table);
            }

            AnsiConsole.Markup("[green]Press any key to return to the menu...[/]");
            Console.ReadKey();
        }

        private void UpdateShape()
        {
            Console.Clear();
            AnsiConsole.Markup("[blue]Update Shape:[/]\n");

            int id = GetValidId("Enter the ID of the shape to update: ");
            var shapeRecord = _repository.GetShapeById(id);

            if (shapeRecord == null)
            {
                AnsiConsole.Markup("[red]Shape not found.[/]");
                Console.ReadKey();
                return;
            }

            AnsiConsole.Markup($"[green]You are updating a {shapeRecord.ShapeName}[/]\n");


            string updatedParameters = string.Empty;
            Shape updatedShape = shapeRecord.ShapeName switch
            {
                "Rectangle" => _rectangleController.UpdateRectangle(shapeRecord, out updatedParameters),
                "Parallelogram" => _parallelogramController.UpdateParallelogram(shapeRecord, out updatedParameters),
                "Triangle" => _triangleController.UpdateTriangle(shapeRecord, out updatedParameters),
                "Rhombus" => _rhombusController.UpdateRhombus(shapeRecord, out updatedParameters),
                _ => throw new InvalidOperationException("Unknown shape type.")
            };

            double updatedArea = updatedShape.CalculateArea();
            double updatedPerimeter = updatedShape.CalculatePerimeter();

            if (_repository.UpdateShape(id, updatedParameters, updatedArea, updatedPerimeter))
            {
                AnsiConsole.Markup("[green]Shape updated successfully![/]");
            }
            else
            {
                AnsiConsole.Markup("[red]Failed to update shape.[/]");
            }

            Console.ReadKey();
        }

        private int GetValidId(string prompt)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<int>($"[yellow]{prompt}[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive integer.[/]")
                    .Validate(value => value > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]ID must be positive.[/]")));
        }

        private void DeleteShape()
        {
            Console.Clear();
            AnsiConsole.Markup("[blue]Delete Shape:[/]\n");

            int id = AnsiConsole.Prompt(
                new TextPrompt<int>("[yellow]Enter the ID of the shape to delete:[/]")
                    .Validate(value => value > 0 ? ValidationResult.Success() : ValidationResult.Error("[red]ID must be positive.[/]")));

            if (_repository.DeleteShape(id))
            {
                AnsiConsole.Markup("[green]Shape deleted successfully![/]");
            }
            else
            {
                AnsiConsole.Markup("[red]Shape not found.[/]");
            }

            Console.ReadKey();
        }
    }
}