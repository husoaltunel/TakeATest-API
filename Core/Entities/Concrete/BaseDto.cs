using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class BaseDto : IDto
    {
        public long Id { get;set;}
    }
}
