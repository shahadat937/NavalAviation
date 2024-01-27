using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemInspection.Validators;
using SchoolManagement.Application.Features.ItemInspections.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemInspections.Handlers.Commands
{
    public class CreateItemInspectionCommandHandler : IRequestHandler<CreateItemInspectionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateItemInspectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateItemInspectionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateItemInspectionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ItemInspectionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var ItemInspection = _mapper.Map<ItemInspection>(request.ItemInspectionDto);

                ItemInspection = await _unitOfWork.Repository<ItemInspection>().Add(ItemInspection);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = ItemInspection.ItemInspectionId;
            }

            return response;
        }
    }
}
