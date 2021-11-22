using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result.Abstract
{
    public interface IDataResult<TEntity> : IResult
    {
        public TEntity Data { get;set;}
    }
}
