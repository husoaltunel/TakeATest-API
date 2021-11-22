using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result.Concrete
{
    public class SuccessDataResult<TEntity> : DataResult<TEntity>, IDataResult<TEntity>
    {

        public SuccessDataResult() : base(success: true)
        {

        }
        public SuccessDataResult(string message) : base(success: true, message)
        {

        }
        public SuccessDataResult(TEntity data) : base(success: true,data)
        {

        }
        public SuccessDataResult(TEntity data, string message) : base(success: true, message,data)
        {

        }
    }
}
