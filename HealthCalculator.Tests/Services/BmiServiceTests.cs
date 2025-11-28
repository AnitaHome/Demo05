using FluentAssertions;
using HealthCalculator.Models;
using HealthCalculator.Services;
using Xunit;

namespace HealthCalculator.Tests.Services;

public class BmiServiceTests
{
    private readonly BmiService _sut;

    public BmiServiceTests()
    {
        _sut = new BmiService();
    }

    [Theory]
    [InlineData(180, 75, 23.15, "Normal")]
    [InlineData(170, 50, 17.3, "Underweight")]
    [InlineData(170, 80, 27.68, "Overweight")]
    [InlineData(170, 90, 31.14, "Obese")]
    public void CalculateBmi_ShouldReturnCorrectBmiAndStatus(double height, double weight, double expectedBmi, string expectedStatus)
    {
        // Arrange
        var request = new BmiRequest(height, weight);

        // Act
        var result = _sut.CalculateBmi(request);

        // Assert
        result.Bmi.Should().Be(expectedBmi);
        result.Status.Should().Be(expectedStatus);
    }

    [Theory]
    [InlineData(180, 59.9, "Underweight")] // BMI ~18.48
    [InlineData(180, 60, "Normal")] // BMI ~18.51
    [InlineData(180, 80.6, "Normal")] // BMI ~24.87
    [InlineData(180, 80.7, "Overweight")] // BMI ~24.90
    [InlineData(180, 96.8, "Overweight")] // BMI ~29.87
    [InlineData(180, 96.9, "Obese")] // BMI ~29.90
    public void CalculateBmi_ShouldHandleBoundariesCorrectly(double height, double weight, string expectedStatus)
    {
        // Arrange
        var request = new BmiRequest(height, weight);

        // Act
        var result = _sut.CalculateBmi(request);

        // Assert
        result.Status.Should().Be(expectedStatus);
    }

    [Theory]
    [InlineData(0, 70)]
    [InlineData(170, 0)]
    [InlineData(-10, 70)]
    [InlineData(170, -5)]
    public void CalculateBmi_ShouldThrowArgumentException_WhenInputIsInvalid(double height, double weight)
    {
        // Arrange
        var request = new BmiRequest(height, weight);

        // Act
        Action act = () => _sut.CalculateBmi(request);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Height and Weight must be greater than zero.");
    }
}
