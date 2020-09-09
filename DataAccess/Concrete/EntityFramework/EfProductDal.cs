using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Framework.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfRepositoryBase<Product,NorthwindContext>,IProductDal
    {
       
    }
}
