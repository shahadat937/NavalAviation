using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.Survey;
using SchoolManagement.Application.Features.Surveys.Requests.Queries;

namespace SchoolManagement.Application.Features.Surveys.Handlers.Queries
{
    public class GetSurveyListByDepartmentNameIdRequestHandler : IRequestHandler<GetSurveyListByDepartmentNameIdRequest, List<SurveyDto>>
    {
        private readonly ISchoolManagementRepository<Survey> _SurveyRepository;

        private readonly IMapper _mapper;
        public GetSurveyListByDepartmentNameIdRequestHandler(ISchoolManagementRepository<Survey> SurveyRepository, IMapper mapper)
        {
            _SurveyRepository = SurveyRepository;
            _mapper = mapper;
        }

        public async Task<List<SurveyDto>> Handle(GetSurveyListByDepartmentNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Survey> Surveys = _SurveyRepository.FilterWithInclude(x => x.DepartmentNameId == request.DepartmentNameId , "DepartmentName", "ItemDetail", "ItemCategory");
            var totalCount = Surveys.Count();
            Surveys = Surveys.OrderByDescending(x => x.SurveyId);
            var SurveyDtos = _mapper.Map<List<SurveyDto>>(Surveys);

            return SurveyDtos;
        }

    }
}
