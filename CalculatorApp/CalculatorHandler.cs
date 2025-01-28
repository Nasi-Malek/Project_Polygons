using CalculatorApp.Handler;
using CalculatorApp.Handlers;
using Spectre.Console;


namespace CalculatorApp
{
    public class CalculatorHandler
    {
        private readonly ICalculatorRepository _repository;
        private readonly Dictionary<string, Action> _operations;

        public CalculatorHandler(
            ICalculatorRepository repository,
            OperationHandler operationHandler,
            HistoryHandler historyHandler,
            UpdateHandler updateHandler,
            DeleteHandler deleteHandler)
        {
            _repository = repository;

            _operations = new Dictionary<string, Action>
        {
            { "Addition (+)", () => operationHandler.PerformOperation("+") },
            { "Subtraction (-)", () => operationHandler.PerformOperation("-") },
            { "Multiplication (*)", () => operationHandler.PerformOperation("*") },
            { "Division (/)", () => operationHandler.PerformOperation("/") },
            { "Modulus (%)", () => operationHandler.PerformOperation("%") },
            { "Square Root (√)", () => operationHandler.PerformOperation("√") },
            { "View Calculation History", historyHandler.ShowHistory },
            { "Update Calculation", updateHandler.UpdateCalculation },
            { "Delete Calculation", deleteHandler.DeleteCalculation },
            { "Back to Main Menu", () => throw new OperationCanceledException() }
        };
        }

        public void ShowCalculatorMenu()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[blue]Choose an operation:[/]")
                            .PageSize(10)
                            .AddChoices(_operations.Keys));

                    if (_operations.TryGetValue(choice, out var action))
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
                    AnsiConsole.Markup($"[bold red]An error occurred: {ex.Message}[/]");
                    Console.ReadKey();
                }
            }
        }
    }
}