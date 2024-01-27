using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Manufacture;
using SchoolManagement.Application.Features.Manufactures.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Manufactures.Handlers.Queries
{
    public class GetManufactureDetailRequestHandler : IRequestHandler<GetManufactureDetailRequest, ManufactureDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<Manufacture> _ManufactureRepository;
        public GetManufactureDetailRequestHandler(ISchoolManagementRepository<Manufacture> ManufactureRepository, IMapper mapper)
        {
            _ManufactureRepository = ManufactureRepository;
            _mapper = mapper;
        }
        public async Task<ManufactureDto> Handle(GetManufactureDetailRequest request, CancellationToken cancellationToken)
        {
            var Manufacture = await _ManufactureRepository.Get(request.ManufactureId);
            return _mapper.Map<ManufactureDto>(Manufacture);
        }
    }
}
