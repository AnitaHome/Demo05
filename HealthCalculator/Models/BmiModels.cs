namespace HealthCalculator.Models;

public record BmiRequest(double Height, double Weight);

public record BmiResponse(double Bmi, string Status);
