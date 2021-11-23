using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Question : BaseEntity, IEntity
    {
        public string Text { get; set; }
        public long ExamId { get; set; }
    }
}
