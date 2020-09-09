using Entities.Concrete;
using Framework.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> Getlist();
    
    }
}
