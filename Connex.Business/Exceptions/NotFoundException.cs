using Connex.Business.Exceptions.Common;
using System.Net;

namespace Connex.Business.Exceptions;

public class NotFoundException : Exception, IBaseException
{
    public NotFoundException(string message = "Not found!") : base(message)
    {

    }
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.NotFound;
    public string Name { get; set; } = "Məlumat tapılmadı";
}
