using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ServiceLifeTypees.Handlers.Commands
{
    public class DeleteServiceLifeTypeCommandHandler : IRequestHandler<DeleteServiceLifeTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteServiceLifeTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteServiceLifeTypeCommand request, CancellationToken cancellationToken)
        {
            var ServiceLifeTypee = await _unitOfWork.Repository<ServiceLifeType>().Get(request.ServiceLifeTypeId);

            if (ServiceLifeTypee == null)
                throw new NotFoundException(nameof(ServiceLifeTypee), request.ServiceLifeTypeId);

            await _unitOfWork.Repository<ServiceLifeType>().Delete(ServiceLifeTypee);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
