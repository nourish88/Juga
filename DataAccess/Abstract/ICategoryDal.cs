using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Framework.DataAccess;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
      
    }
}
