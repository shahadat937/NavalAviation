using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.EquipmentNames.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.EquipmentNames.Handlers.Commands
{
    public class DeleteEquipmentNameCommandHandler : IRequestHandler<DeleteEquipmentNameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEquipmentNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEquipmentNameCommand request, CancellationToken cancellationToken)
        {
            var EquipmentName = await _unitOfWork.Repository<EquipmentName>().Get(request.EquipmentNameId);

            if (EquipmentName == null)
                throw new NotFoundException(nameof(EquipmentName), request.EquipmentNameId);

            await _unitOfWork.Repository<EquipmentName>().Delete(EquipmentName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
