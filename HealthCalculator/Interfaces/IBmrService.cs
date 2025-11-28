using HealthCalculator.Models;

namespace HealthCalculator.Interfaces;

public interface IBmrService
{
    BmrResponse CalculateBmr(BmrRequest request);
}
