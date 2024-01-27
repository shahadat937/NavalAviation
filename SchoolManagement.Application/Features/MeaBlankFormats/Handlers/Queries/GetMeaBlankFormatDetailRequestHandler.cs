using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MeaBlankFormat;
using SchoolManagement.Application.Features.MeaBlankFormats.Requests.Queries;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Handlers.Queries
{
    public class GetMeaBlankFormatDetailRequestHandler : IRequestHandler<GetMeaBlankFormatDetailRequest, MeaBlankFormatDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.MeaBlankFormat> _MeaBlankFormatRepository;
        public GetMeaBlankFormatDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.MeaBlankFormat> MeaBlankFormatRepository, IMapper mapper)
        {
            _MeaBlankFormatRepository = MeaBlankFormatRepository;
            _mapper = mapper;
        }
        public async Task<MeaBlankFormatDto> Handle(GetMeaBlankFormatDetailRequest request, CancellationToken cancellationToken)
        {
            var MeaBlankFormat = await _MeaBlankFormatRepository.Get(request.MeaBlankFormatId);
            return _mapper.Map<MeaBlankFormatDto>(MeaBlankFormat);
        }
    }
}
