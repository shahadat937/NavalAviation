using AutoMapper;
using SchoolManagement.Application.DTOs.TestEquipmentDetail.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Handlers.Commands
{
    public class UpdateTestEquipmentDetailCommandHandler : IRequestHandler<UpdateTestEquipmentDetailCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTestEquipmentDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTestEquipmentDetailCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTestEquipmentDetailDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TestEquipmentDetailDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TestEquipmentDetail = await _unitOfWork.Repository<TestEquipmentDetail>().Get(request.TestEquipmentDetailDto.TestEquipmentDetailId);

            if (TestEquipmentDetail is null)
                throw new NotFoundException(nameof(TestEquipmentDetail), request.TestEquipmentDetailDto.TestEquipmentDetailId);

            _mapper.Map(request.TestEquipmentDetailDto, TestEquipmentDetail);

            await _unitOfWork.Repository<TestEquipmentDetail>().Update(TestEquipmentDetail);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
