using Core.Entities.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ExamWithQuestionsDto : BaseDto,IDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int IsActive { get; set; }
        public string Date { get; set; }
        public List<QuestionDto> Questions { get;set;}
    }
}
