using Spectre.Console;


namespace CalculatorApp.Handler
{
    public class OperationHandler
    {
        private readonly ICalculatorRepository _repository;

        public OperationHandler(ICalculatorRepository repository)
        {
            _repository = repository;
        }

        public void PerformOperation(string operation)
        {
            Console.Clear();
            AnsiConsole.Markup($"[blue]{operation} Calculation:[/]\n");

            double num1 = GetValidInput("Enter the first number: ");
            double num2 = operation == "√" ? 0 : GetValidInput("Enter the second number: ");

            double result = operation switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Cannot divide by zero."),
                "%" => num2 != 0 ? num1 % num2 : throw new DivideByZeroException("Cannot perform modulus with zero."),
                "√" => num1 >= 0 ? Math.Sqrt(num1) : throw new InvalidOperationException("Square root of a negative number is not allowed."),
                _ => throw new InvalidOperationException("Invalid operation.")
            };

            DisplayResult(num1, num2, operation, result);
            SaveCalculation(num1, num2, operation, result);
        }

        private double GetValidInput(string prompt)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<double>($"[yellow]{prompt}[/]")
                    .ValidationErrorMessage("[red]Please enter a valid number.[/]")
                    .Validate(value => true));
        }

        private void DisplayResult(double? num1, double? num2, string operation, double result)
        {
            Console.Clear();
            AnsiConsole.Markup($"\n[green]Calculation Result:[/]\n");

            if (operation == "√")
            {
                AnsiConsole.Markup($"[blue]Square Root of {num1} = {result:F2}[/]");
            }
            else
            {
                AnsiConsole.Markup($"[blue]{num1} {operation} {num2} = {result:F2}[/]");
            }

            AnsiConsole.Markup("\n[green]Press any key to return...[/]");
            Console.ReadKey();
        }

        private void SaveCalculation(double? num1, double? num2, string operation, double result)
        {
            try
            {
                _repository.SaveCalculation(num1, num2, operation, result); // Use repository for saving
                AnsiConsole.Markup("[green]Calculation saved successfully![/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.Markup($"[red]Error saving calculation: {ex.Message}[/]");
            }
        }
    }
}
