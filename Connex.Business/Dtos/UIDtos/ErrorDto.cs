namespace Connex.Business.Dtos;

public class ErrorDto:IDto
{
    public string Message { get; set; } = null!;
    public int StatusCode { get; set; }
}
