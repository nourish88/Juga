using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Framework.Utilities.Results;

namespace Business.Concrete
{
   public class CategoryManager:ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal _categoryDal)
        {
            _categoryDal = _categoryDal;
        }
        public IDataResult<List<Category>> Getlist()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList().ToList());
        }
    }
}
