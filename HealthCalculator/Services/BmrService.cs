using HealthCalculator.Interfaces;
using HealthCalculator.Models;

namespace HealthCalculator.Services;

public class BmrService : IBmrService
{
    public BmrResponse CalculateBmr(BmrRequest request)
    {
        if (request.Height <= 0 || request.Weight <= 0 || request.Age <= 0)
        {
            throw new ArgumentException("Height, Weight and Age must be greater than zero.");
        }

        // Mifflin-St Jeor Equation
        double bmr = (10 * request.Weight) + (6.25 * request.Height) - (5 * request.Age);

        if (request.Gender == Gender.Male)
        {
            bmr += 5;
        }
        else
        {
            bmr -= 161;
        }

        return new BmrResponse(Math.Round(bmr, 2));
    }
}
