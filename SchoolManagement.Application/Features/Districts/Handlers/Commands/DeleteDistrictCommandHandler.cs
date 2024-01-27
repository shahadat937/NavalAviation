using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Districts.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.Districts.Handlers.Commands
{
    public class DeleteDistrictCommandHandler : IRequestHandler<DeleteDistrictCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDistrictCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDistrictCommand request, CancellationToken cancellationToken)
        {
            var Districts = await _unitOfWork.Repository<District>().Get(request.DistrictId);

            if (Districts == null)
                throw new NotFoundException(nameof(District), request.DistrictId);

            await _unitOfWork.Repository<District>().Delete(Districts);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
