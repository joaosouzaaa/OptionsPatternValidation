using OptionsPatternValidation.API.Options;

namespace UnitTests.TestBuilders;

public sealed class TokenOptionsBuilder
{
    private string _key = "10003d68b1123asa1asdadasd231asd7d";
    private string _issuer = "random";
    private string _audience = "test";
    private int _expirationTimeInMinutes = 5;

    public static TokenOptionsBuilder NewObject() =>
        new();

    public TokenOptions OptionsBuild() =>
        new()
        {
            Key = _key,
            Issuer = _issuer,
            Audience = _audience,
            ExpirationTimeInMinutes = _expirationTimeInMinutes
        };

    public TokenOptionsBuilder WithKey(string key)
    {
        _key = key;

        return this;
    }

    public TokenOptionsBuilder WithIssuer(string issuer)
    {
        _issuer = issuer;

        return this;
    }

    public TokenOptionsBuilder WithAudience(string audience)
    {
        _audience = audience;

        return this;
    }

    public TokenOptionsBuilder WithExpirationTimeInMinutes(int expirationTimeInMinutes)
    {
        _expirationTimeInMinutes = expirationTimeInMinutes;

        return this;
    }
}
