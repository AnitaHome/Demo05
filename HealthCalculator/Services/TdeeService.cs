using HealthCalculator.Interfaces;
using HealthCalculator.Models;

namespace HealthCalculator.Services;

public class TdeeService : ITdeeService
{
    private readonly IBmrService _bmrService;

    public TdeeService(IBmrService bmrService)
    {
        _bmrService = bmrService;
    }

    public TdeeResponse CalculateTdee(TdeeRequest request)
    {
        var bmrRequest = new BmrRequest(request.Gender, request.Age, request.Height, request.Weight);
        var bmrResponse = _bmrService.CalculateBmr(bmrRequest);

        double multiplier = GetActivityMultiplier(request.ActivityLevel);
        double tdee = bmrResponse.Bmr * multiplier;

        return new TdeeResponse(Math.Round(tdee, 2));
    }

    private double GetActivityMultiplier(ActivityLevel level)
    {
        return level switch
        {
            ActivityLevel.Sedentary => 1.2,
            ActivityLevel.LightlyActive => 1.375,
            ActivityLevel.ModeratelyActive => 1.55,
            ActivityLevel.VeryActive => 1.725,
            ActivityLevel.ExtraActive => 1.9,
            _ => 1.2
        };
    }
}
