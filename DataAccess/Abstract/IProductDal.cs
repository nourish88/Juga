using Entities.Concrete;
using Framework.DataAccess;

namespace DataAccess.Abstract
{ //crud işlemlerini bu yapar.. business değil.
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}
