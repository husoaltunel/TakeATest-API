using AutoMapper;
using Core.DataAccess.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Utilities.UnitOfWork;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Services.Option.Queries.GetOptionsByQuestionId
{
    public class Handler : BaseConnection, IRequestHandler<GetOptionsByQuestionIdQuery, IDataResult<IEnumerable<OptionDto>>>
    {
        private readonly IMapper _mapper;
        public Handler(IDbConnection dbConnection, IMapper mapper)
        {
            Connection = dbConnection;
            _mapper = mapper;
        }
        public async Task<IDataResult<IEnumerable<OptionDto>>> Handle(GetOptionsByQuestionIdQuery request, CancellationToken cancellationToken)
        {
            using (var unitOfWork = UnitOfWorkUtil.GetUnitOfWork(Connection))
            {
                var result = await unitOfWork.DbContext.Options.GetOptionsByQuestionId(request.Id);
                if (!ResultUtil<IEnumerable<Entities.Entities.Option>>.IsDataExist(result))
                {
                    return new ErrorDataResult<IEnumerable<OptionDto>>();
                }
                var options = result.Select(option => _mapper.Map<OptionDto>(option));
                return new SuccessDataResult<IEnumerable<OptionDto>>(options);
            }
        }
    }
}
