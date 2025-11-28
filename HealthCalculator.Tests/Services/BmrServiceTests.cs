using FluentAssertions;
using HealthCalculator.Models;
using HealthCalculator.Services;
using Xunit;

namespace HealthCalculator.Tests.Services;

public class BmrServiceTests
{
    private readonly BmrService _sut;

    public BmrServiceTests()
    {
        _sut = new BmrService();
    }

    [Theory]
    [InlineData(Gender.Male, 180, 80, 30, 1780)] // (10*80) + (6.25*180) - (5*30) + 5 = 800 + 1125 - 150 + 5 = 1780
    [InlineData(Gender.Female, 180, 80, 30, 1614)] // (10*80) + (6.25*180) - (5*30) - 161 = 800 + 1125 - 150 - 161 = 1614
    public void CalculateBmr_ShouldReturnCorrectBmr(Gender gender, double height, double weight, int age, double expectedBmr)
    {
        // Arrange
        var request = new BmrRequest(gender, age, height, weight);

        // Act
        var result = _sut.CalculateBmr(request);

        // Assert
        result.Bmr.Should().Be(expectedBmr);
    }

    [Theory]
    [InlineData(0, 80, 30)]
    [InlineData(180, 0, 30)]
    [InlineData(180, 80, 0)]
    [InlineData(-10, 80, 30)]
    public void CalculateBmr_ShouldThrowArgumentException_WhenInputIsInvalid(double height, double weight, int age)
    {
        // Arrange
        var request = new BmrRequest(Gender.Male, age, height, weight);

        // Act
        Action act = () => _sut.CalculateBmr(request);

        // Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage("Height, Weight and Age must be greater than zero.");
    }
}
