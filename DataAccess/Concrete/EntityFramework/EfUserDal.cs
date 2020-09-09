using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Framework.DataAccess.EntityFramework;
using Framework.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
  public  class EfUserDal:EfRepositoryBase<User, NorthwindContext>, IUserDal
  {

      private NorthwindContext _context;

      public EfUserDal(NorthwindContext context)
      {
          _context = context;
      }

      public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.UserId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name};
return result.ToList();
            }
            
        }
    }
}
