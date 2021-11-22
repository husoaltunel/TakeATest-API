using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Option : BaseEntity, IEntity
    {
        public string Text { get; set; }
        public int IsTrue { get; set; }
        public long QuestionId { get; set; }
    }
}
