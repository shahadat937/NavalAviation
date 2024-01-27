using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.MeaSquadronState;
using SchoolManagement.Application.Features.MeaSquadronStates.Requests.Queries;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Handlers.Queries
{
    public class GetMeaSquadronStateListRequestHandler : IRequestHandler<GetMeaSquadronStateListRequest, PagedResult<MeaSquadronStateDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MeaSquadronState> _MeaSquadronStateRepository;

        private readonly IMapper _mapper;

        public GetMeaSquadronStateListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.MeaSquadronState> MeaSquadronStateRepository, IMapper mapper)
        {
            _MeaSquadronStateRepository = MeaSquadronStateRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MeaSquadronStateDto>> Handle(GetMeaSquadronStateListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.MeaSquadronState> MeaSquadronStates = _MeaSquadronStateRepository.FilterWithInclude(x => (x.WorkOrderReceived.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "DepartmentName", "ItemDetail", "Trade", "MeaWorkShop").Where(x=>x.JobStatus !=0 && x.WorkCompletedStatus == request.CompleteStatus);
            var totalCount = MeaSquadronStates.Count();
            MeaSquadronStates = MeaSquadronStates.OrderByDescending(x => x.MeaSquadronStateId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var MeaSquadronStateDtos = _mapper.Map<List<MeaSquadronStateDto>>(MeaSquadronStates);
            var result = new PagedResult<MeaSquadronStateDto>(MeaSquadronStateDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
