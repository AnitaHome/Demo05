using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using HealthCalculator.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace HealthCalculator.Tests.Integration;

public class HealthApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public HealthApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CalculateBmi_ShouldReturnOkAndCorrectResult()
    {
        // Arrange
        var request = new BmiRequest(180, 75);

        // Act
        var response = await _client.PostAsJsonAsync("/health/bmi", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<BmiResponse>();
        result.Should().NotBeNull();
        result!.Bmi.Should().Be(23.15);
        result.Status.Should().Be("Normal");
    }

    [Fact]
    public async Task CalculateBmr_ShouldReturnOkAndCorrectResult()
    {
        // Arrange
        var request = new BmrRequest(Gender.Male, 30, 180, 80);

        // Act
        var response = await _client.PostAsJsonAsync("/health/bmr", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<BmrResponse>();
        result.Should().NotBeNull();
        result!.Bmr.Should().Be(1780);
    }

    [Fact]
    public async Task CalculateTdee_ShouldReturnOkAndCorrectResult()
    {
        // Arrange
        var request = new TdeeRequest(Gender.Male, 30, 180, 80, ActivityLevel.Sedentary);

        // Act
        var response = await _client.PostAsJsonAsync("/health/tdee", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var result = await response.Content.ReadFromJsonAsync<TdeeResponse>();
        result.Should().NotBeNull();
        // BMR 1780 * 1.2 = 2136
        result!.Tdee.Should().Be(2136);
    }

    [Fact]
    public async Task CalculateBmi_ShouldReturnInternalServerError_WhenInputIsInvalid()
    {
        // Arrange
        var request = new BmiRequest(0, 0);

        // Act
        var response = await _client.PostAsJsonAsync("/health/bmi", request);

        // Assert
        // Currently the API throws exception which results in 500
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }
}
