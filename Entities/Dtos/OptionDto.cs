using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OptionDto : IDto
    {
        public string Text { get; set; }
        public int IsTrue { get; set; }
        public long QuestionId { get; set; }
    }
}
