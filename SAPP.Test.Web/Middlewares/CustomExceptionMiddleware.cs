using SAPP.Test.Domain.Exeptions;

namespace SAPP.Test.Web.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext _context)
        {
            try
            {
                await _next(_context);
            }
            catch (GlobalException ex)
            {
                _context.Response.ContentType = "application/json";
                _context.Response.StatusCode = _context.Response.StatusCode;
                await _context.Response.WriteAsync(ex.ToString());
            }
            
        }
    }
}
