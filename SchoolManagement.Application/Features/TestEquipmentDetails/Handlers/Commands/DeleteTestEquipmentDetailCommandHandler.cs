using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Handlers.Commands
{
    public class DeleteTestEquipmentDetailCommandHandler : IRequestHandler<DeleteTestEquipmentDetailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTestEquipmentDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTestEquipmentDetailCommand request, CancellationToken cancellationToken)
        {
            var TestEquipmentDetail = await _unitOfWork.Repository<TestEquipmentDetail>().Get(request.TestEquipmentDetailId);

            if (TestEquipmentDetail == null)
                throw new NotFoundException(nameof(TestEquipmentDetail), request.TestEquipmentDetailId);

            await _unitOfWork.Repository<TestEquipmentDetail>().Delete(TestEquipmentDetail);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
