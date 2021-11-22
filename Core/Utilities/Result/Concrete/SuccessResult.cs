using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result.Concrete
{
    public class SuccessResult : Result,IResult
    {
        public SuccessResult() : base(success :true)
        {

        }
        public SuccessResult(string message) : base(success : true,message)
        {

        }
    }
}
