using System.Collections.Generic;
using Framework.Entities.Concrete;

namespace Framework.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
