using CalculatorApp.Handlers;

namespace CalculatorApp
{
    public interface ICalculatorRepository
    {
        void SaveCalculation(double? num1, double? num2, string operation, double result);
        void DisplayAllCalculations();
        bool UpdateCalculation(int id, double newNum1, double newNum2, double newResult);
        bool DeleteCalculation(int id);
        CalculationRecord? GetCalculationById(int id);
    }

}
