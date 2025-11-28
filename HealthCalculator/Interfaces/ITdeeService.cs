using HealthCalculator.Models;

namespace HealthCalculator.Interfaces;

public interface ITdeeService
{
    TdeeResponse CalculateTdee(TdeeRequest request);
}
