namespace Application.IdentityService.Jwt;

/// <summary>
///     Represent refresh token generator interface.
/// </summary>
public interface IRefreshTokenHandler
{
    public string Generate(int length);
}
