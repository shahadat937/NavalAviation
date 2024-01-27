using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Survey;
using SchoolManagement.Application.Features.Surveys.Requests.Queries;

namespace SchoolManagement.Application.Features.Surveys.Handlers.Queries
{
    public class GetSurveyDetailRequestHandler : IRequestHandler<GetSurveyDetailRequest, SurveyDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Survey> _SurveyRepository;
        public GetSurveyDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Survey> SurveyRepository, IMapper mapper)
        {
            _SurveyRepository = SurveyRepository;
            _mapper = mapper;
        }
        public async Task<SurveyDto> Handle(GetSurveyDetailRequest request, CancellationToken cancellationToken)
        {
            var Survey = await _SurveyRepository.Get(request.SurveyId);
            return _mapper.Map<SurveyDto>(Survey);
        }
    }
}
