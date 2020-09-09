using Entities.Concrete;
using System.Collections.Generic;
using Framework.Utilities.Results;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>>  Getlist();
        IDataResult<List<Product>> GetListByCategory(int categoryId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<Product> GetById(int poductId);
    }
}
