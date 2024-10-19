using Connex.Business.Exceptions.Common;
using System.Net;

namespace Connex.Business.Exceptions;

public class InvalidInputException:Exception,IBaseException
{
    public InvalidInputException(string message="Invalid Input Exception"):base(message)
    {
        
    }

    public HttpStatusCode StatusCode { get; set; }= HttpStatusCode.BadRequest;
    public string Name { get; set; } = "Yanlış format";
}
