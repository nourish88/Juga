using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Framework.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfCategoryDal : EfRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
