using System.Net;

namespace Connex.Business.Exceptions.Common;

public interface IBaseException
{
    public HttpStatusCode StatusCode { get; set; }
    public string Name { get; set; }
}
