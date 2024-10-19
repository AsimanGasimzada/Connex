using Connex.Business.Exceptions.Common;
using System.Net;

namespace Connex.Business.Exceptions;

public class InvalidInpuException:Exception,IBaseException
{
    public InvalidInpuException(string message="Invalid Input Exception"):base(message)
    {
        
    }

    public HttpStatusCode StatusCode { get; set; }= HttpStatusCode.BadRequest;
    public string Name { get; set; } = "Yanlış format";
}
