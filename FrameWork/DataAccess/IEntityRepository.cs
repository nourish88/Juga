using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;
using Framework.Entities;

namespace Framework.DataAccess
{
  public  interface IEntityRepository<T> where T:class,IEntity, new()
  {
      T Get(Expression<Func<T, bool>> filter);
      // T GetById(int Id); Ayrıca bunların async methodları da eklenecek.
      IList<T> GetList(Expression<Func<T, bool>> filter = null);

      void Add(T entity);
      void Update(T entity);
      void Delete(T entity);
  }
}
