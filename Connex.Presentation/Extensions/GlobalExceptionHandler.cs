using Connex.Business.Dtos;
using Connex.Business.Exceptions.Common;
using Newtonsoft.Json;

namespace Connex.Presentation.Extensions;
public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;

    }


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            ErrorDto dto = new ErrorDto()
            {
                Message = "Bilinməyən xəta baş verdi,server ilə əlaqə saxlayın.",
                StatusCode = 500
            };

            if (e is IBaseException)
            {
                dto.StatusCode = 404;
                dto.Message = e.Message;
            }

            var json = JsonConvert.SerializeObject(e);

            context.Response.ContentType = "application/json";
            context.Response.Redirect($"/Home/Error?error={json}");
        }
    }


    private string SanitizeErrorMessage(string errorMessage)
    {
        return new string(errorMessage.Where(c => !char.IsControl(c)).ToArray());
    }
}