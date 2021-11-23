using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class QuestionDto : BaseDto, IDto
    {
        public string Text { get; set; }
        public long ExamId { get; set; }
        public List<OptionDto> Options { get;set;}
    }
}
