namespace Architecture.Web;

[ApiController]
[Route("api/auths")]
public sealed class AuthController : BaseController
{

    /// <summary>
    /// Auth
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /api/auths
    ///     {
    ///         "username": "admin",
    ///         "password": "Admin123!"
    ///     }
    /// </remarks>
    /// <response code="200">Returns the token</response>
    [AllowAnonymous]
    [HttpPost]
    public IActionResult Auth(AuthRequest request) => Mediator.HandleAsync<AuthRequest, AuthResponse>(request).ApiResult();
}
