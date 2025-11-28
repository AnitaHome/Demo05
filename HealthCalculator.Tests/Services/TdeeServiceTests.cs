using FluentAssertions;
using HealthCalculator.Interfaces;
using HealthCalculator.Models;
using HealthCalculator.Services;
using Moq;
using Xunit;

namespace HealthCalculator.Tests.Services;

public class TdeeServiceTests
{
    private readonly Mock<IBmrService> _bmrServiceMock;
    private readonly TdeeService _sut;

    public TdeeServiceTests()
    {
        _bmrServiceMock = new Mock<IBmrService>();
        _sut = new TdeeService(_bmrServiceMock.Object);
    }

    [Theory]
    [InlineData(ActivityLevel.Sedentary, 1.2)]
    [InlineData(ActivityLevel.LightlyActive, 1.375)]
    [InlineData(ActivityLevel.ModeratelyActive, 1.55)]
    [InlineData(ActivityLevel.VeryActive, 1.725)]
    [InlineData(ActivityLevel.ExtraActive, 1.9)]
    public void CalculateTdee_ShouldApplyCorrectMultiplier(ActivityLevel activityLevel, double multiplier)
    {
        // Arrange
        double mockBmr = 2000;
        _bmrServiceMock.Setup(x => x.CalculateBmr(It.IsAny<BmrRequest>()))
            .Returns(new BmrResponse(mockBmr));

        var request = new TdeeRequest(Gender.Male, 30, 180, 80, activityLevel);

        // Act
        var result = _sut.CalculateTdee(request);

        // Assert
        result.Tdee.Should().Be(mockBmr * multiplier);
    }
}
