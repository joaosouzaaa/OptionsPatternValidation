using OptionsPatternValidation.API.Validators;
using UnitTests.TestBuilders;

namespace UnitTests.ValidatorsTests;

public sealed class TokenOptionsValidatorTests
{
    private readonly TokenOptionsValidator _tokenOptionsValidator;

    public TokenOptionsValidatorTests()
    {
        _tokenOptionsValidator = new TokenOptionsValidator();
    }

    [Fact]
    public void Validate_SuccessfulScenario_ReturnsTrue()
    {
        // A
        var tokenOptions = TokenOptionsBuilder.NewObject().OptionsBuild();

        // A
        var validationResult = _tokenOptionsValidator.Validate(tokenOptions);

        // A
        Assert.True(validationResult.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("test")]
    [InlineData("random")]
    public void Validate_InvalidKey_ReturnsFalse(string key)
    {
        // A
        var tokenOptionsWithInvalidKey = TokenOptionsBuilder.NewObject().WithKey(key).OptionsBuild();

        // A
        var validationResult = _tokenOptionsValidator.Validate(tokenOptionsWithInvalidKey);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Fact]
    public void Validate_InvalidKey_ReturnsIssuer()
    {
        // A
        var tokenOptionsWithInvalidIssuer = TokenOptionsBuilder.NewObject().WithIssuer(null!).OptionsBuild();

        // A
        var validationResult = _tokenOptionsValidator.Validate(tokenOptionsWithInvalidIssuer);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Fact]
    public void Validate_InvalidAudience_ReturnsFalse()
    {
        // A
        var tokenOptionsWithInvalidAudience = TokenOptionsBuilder.NewObject().WithAudience(string.Empty).OptionsBuild();

        // A
        var validationResult = _tokenOptionsValidator.Validate(tokenOptionsWithInvalidAudience);

        // A
        Assert.False(validationResult.IsValid);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(4)]
    [InlineData(-2)]
    public void Validate_InvalidExpirationTimeInMinutes_ReturnsFalse(int expirationTimeInMinutes)
    {
        // A
        var tokenOptionsWithInvalidExpirationTimeInMinutes = TokenOptionsBuilder
            .NewObject()
            .WithExpirationTimeInMinutes(expirationTimeInMinutes)
            .OptionsBuild();

        // A
        var validationResult = _tokenOptionsValidator.Validate(tokenOptionsWithInvalidExpirationTimeInMinutes);

        // A
        Assert.False(validationResult.IsValid);
    }
}
