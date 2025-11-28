using HealthCalculator.Models;

namespace HealthCalculator.Interfaces;

public interface IBmiService
{
    BmiResponse CalculateBmi(BmiRequest request);
}
