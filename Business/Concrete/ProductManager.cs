using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Framework.Aspects.Autofac.Caching;
using Framework.Aspects.Autofac.Transcation;
using Framework.Aspects.Autofac.Validation;
using Framework.CrossCuttingConcerns.Validation.FluentValidation;
using Framework.Utilities.Results;

namespace Business.Concrete
{
   public class ProductManager:IProductService
   {
       private IProductDal _productDal;

       public ProductManager(IProductDal productDal)
       {
           _productDal = productDal;
       }
      
        public IDataResult<List<Product>> Getlist( )
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetList().ToList());
        }
        [CacheAspect(duration:1)]// süre vermezsek 60 olarak set etmiştik.
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p=>p.CategoryId==categoryId).ToList());
        }
        [ValidationAspect(typeof(ProductValidator),Priority = 1)]
        public IResult Add(Product product)
        {
            //ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Add(product);
           return new SuccessResult(Messages.ProductAdded); 
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }
        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult();
        }
   }
}
