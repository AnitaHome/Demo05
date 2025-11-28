namespace HealthCalculator.Models;

public record BmrRequest(Gender Gender, int Age, double Height, double Weight);

public record BmrResponse(double Bmr);
