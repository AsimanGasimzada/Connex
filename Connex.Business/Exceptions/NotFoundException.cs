using Connex.Business.Exceptions.Common;

namespace Connex.Business.Exceptions;

public class NotFoundException:Exception,IBaseException
{
    public NotFoundException(string message = "Not found!"):base(message)   
    {
        
    }
}
