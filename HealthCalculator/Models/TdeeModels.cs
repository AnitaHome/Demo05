namespace HealthCalculator.Models;

public record TdeeRequest(Gender Gender, int Age, double Height, double Weight, ActivityLevel ActivityLevel);

public record TdeeResponse(double Tdee);
