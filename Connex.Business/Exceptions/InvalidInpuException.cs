using Connex.Business.Exceptions.Common;

namespace Connex.Business.Exceptions;

public class InvalidInpuException:Exception,IBaseException
{
    public InvalidInpuException(string message="Invalid Input Exception"):base(message)
    {
        
    }
}
