using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result.Concrete
{
    public class ErrorResult : Result,IResult
    {
        public ErrorResult() : base(success : false)
        {

        }
        public ErrorResult(string message) : base(success : false,message)
        {

        }
    }
}
