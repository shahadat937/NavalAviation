using AutoMapper;
using SchoolManagement.Application.DTOs.TestEquipmentDetail.Validators;
using SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Handlers.Commands
{
    public class CreateTestEquipmentDetailCommandHandler : IRequestHandler<CreateTestEquipmentDetailCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTestEquipmentDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTestEquipmentDetailCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTestEquipmentDetailDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TestEquipmentDetailDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TestEquipmentDetail = _mapper.Map<TestEquipmentDetail>(request.TestEquipmentDetailDto);

                TestEquipmentDetail = await _unitOfWork.Repository<TestEquipmentDetail>().Add(TestEquipmentDetail);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TestEquipmentDetail.TestEquipmentDetailId;
            }

            return response;
        }
    }
}
