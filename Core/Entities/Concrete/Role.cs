using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Role : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
