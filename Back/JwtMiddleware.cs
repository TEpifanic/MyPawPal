using MyPawPal.Services;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JwtService _jwtService;

    public JwtMiddleware(RequestDelegate next, JwtService jwtService)
    {
        _next = next;
        _jwtService = jwtService;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        if (token != null)
        {
            AttachUserToContext(context, token);
        }

        await _next(context);
    }

    private void AttachUserToContext(HttpContext context, string token)
    {
        try
        {
            var user = _jwtService.ValidateToken(token);
            context.Items["User"] = user;
        }
        catch (Exception)
        {
            // Do nothing if the token is invalid or expired
        }
    }
}
