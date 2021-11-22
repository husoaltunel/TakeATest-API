using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result.Concrete
{
    public class ErrorDataResult<TEntity> : DataResult<TEntity>, IDataResult<TEntity>
    {
        public ErrorDataResult() : base(success:false)
        {

        }
        public ErrorDataResult(string message) : base(success:false,message)
        {

        }
        public ErrorDataResult(TEntity data) : base(success: false, data)
        {

        }

        public ErrorDataResult(string message,TEntity data) : base(success: false, message,data)
        {

        }
    }
}
