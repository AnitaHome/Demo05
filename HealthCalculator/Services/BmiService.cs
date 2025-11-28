using HealthCalculator.Interfaces;
using HealthCalculator.Models;

namespace HealthCalculator.Services;

public class BmiService : IBmiService
{
    public BmiResponse CalculateBmi(BmiRequest request)
    {
        if (request.Height <= 0 || request.Weight <= 0)
        {
            throw new ArgumentException("Height and Weight must be greater than zero.");
        }

        double heightInMeters = request.Height / 100.0;
        double bmi = request.Weight / (heightInMeters * heightInMeters);
        
        string status = GetBmiStatus(bmi);

        return new BmiResponse(Math.Round(bmi, 2), status);
    }

    private string GetBmiStatus(double bmi)
    {
        if (bmi < 18.5) return "Underweight";
        if (bmi < 24.9) return "Normal";
        if (bmi < 29.9) return "Overweight";
        return "Obese";
    }
}
