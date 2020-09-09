using System.Collections.Generic;
using Entities.Concrete;
using Framework.DataAccess;
using Framework.Entities.Concrete;

namespace DataAccess.Abstract
{
 public interface    IUserDal:IEntityRepository<User>
 {
     List<OperationClaim> GetClaims(User user);
 }
}
