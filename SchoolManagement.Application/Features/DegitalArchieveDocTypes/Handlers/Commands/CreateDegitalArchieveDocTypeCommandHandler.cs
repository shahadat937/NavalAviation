using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DegitalArchieveDocType.Validators;
using SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Handlers.Commands
{
    public class CreateDegitalArchieveDocTypeCommandHandler : IRequestHandler<CreateDegitalArchieveDocTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDegitalArchieveDocTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDegitalArchieveDocTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDegitalArchieveDocTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DegitalArchieveDocTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DegitalArchieveDocType = _mapper.Map<DegitalArchieveDocType>(request.DegitalArchieveDocTypeDto);

                DegitalArchieveDocType = await _unitOfWork.Repository<DegitalArchieveDocType>().Add(DegitalArchieveDocType);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DegitalArchieveDocType.DegitalArchieveDocTypeId;
            }

            return response;
        }
    }
}
