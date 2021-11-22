using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Option.Queries.GetOptionsByQuestionId
{
    public class GetOptionsByQuestionIdQuery : IRequest<IDataResult<IEnumerable<OptionDto>>>
    {
        public long Id { get;set;}
    }
}
