using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OccasionOfDemand;
using SchoolManagement.Application.Features.OccasionOfDemands.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.OccasionOfDemands.Handlers.Queries
{
    public class GetOccasionOfDemandDetailRequestHandler : IRequestHandler<GetOccasionOfDemandDetailRequest, OccasionOfDemandDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<OccasionOfDemand> _OccasionOfDemandRepository;
        public GetOccasionOfDemandDetailRequestHandler(ISchoolManagementRepository<OccasionOfDemand> OccasionOfDemandRepository, IMapper mapper)
        {
            _OccasionOfDemandRepository = OccasionOfDemandRepository;
            _mapper = mapper;
        }
        public async Task<OccasionOfDemandDto> Handle(GetOccasionOfDemandDetailRequest request, CancellationToken cancellationToken)
        {
            var OccasionOfDemand = await _OccasionOfDemandRepository.Get(request.OccasionOfDemandId);
            return _mapper.Map<OccasionOfDemandDto>(OccasionOfDemand);
        }
    }
}
