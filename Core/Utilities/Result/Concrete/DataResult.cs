using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result.Concrete
{
    public class DataResult<TEntity> : Result ,IDataResult<TEntity>
    {
        public DataResult(bool success) : base(success)
        {

        }
        public DataResult(bool success,string message) : base(success,message)
        {

        }
        public DataResult(bool success, TEntity data) : this(success)
        {
            Data = data;
        }
        public DataResult(bool success,string message, TEntity data) : this(success,message)
        {
            Data = data;
        }
        public TEntity Data { get; set ; }

    }
}
