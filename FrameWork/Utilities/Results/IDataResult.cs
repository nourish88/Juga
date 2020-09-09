using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Utilities.Results
{
   public interface IDataResult<T> :IResult
    {
        T Data { get; }
    }
}
