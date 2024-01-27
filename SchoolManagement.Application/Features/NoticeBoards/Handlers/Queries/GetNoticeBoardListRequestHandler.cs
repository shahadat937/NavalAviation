using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.NoticeBoards;
using SchoolManagement.Application.Features.NoticeBoards.Requests.Queries;

namespace SchoolManagement.Application.Features.NoticeBoards.Handlers.Queries
{
    public class GetNoticeBoardListRequestHandler : IRequestHandler<GetNoticeBoardListRequest, PagedResult<NoticeBoardDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.NoticeBoard> _NoticeBoardRepository;

        private readonly IMapper _mapper;

        public GetNoticeBoardListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.NoticeBoard> NoticeBoardRepository, IMapper mapper)
        {
            _NoticeBoardRepository = NoticeBoardRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<NoticeBoardDto>> Handle(GetNoticeBoardListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.NoticeBoard> NoticeBoards = _NoticeBoardRepository.FilterWithInclude(x =>String.IsNullOrEmpty(request.QueryParams.SearchText), "DepartmentName");
            var totalCount = NoticeBoards.Count();
            NoticeBoards = NoticeBoards.OrderByDescending(x => x.NoticeBoardId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize).Where(x=>x.DepartmentNameId == (request.DepartmentNameId == 0 ? x.DepartmentNameId : request.DepartmentNameId));

            var NoticeBoardDtos = _mapper.Map<List<NoticeBoardDto>>(NoticeBoards);
            var result = new PagedResult<NoticeBoardDto>(NoticeBoardDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
