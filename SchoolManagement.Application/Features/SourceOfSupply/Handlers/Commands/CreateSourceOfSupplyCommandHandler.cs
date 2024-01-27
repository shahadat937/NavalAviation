using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SourceOfSupply.Validators;
using SchoolManagement.Application.Features.SourceOfSupplys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Handlers.Commands
{
    public class CreateSourceOfSupplyCommandHandler : IRequestHandler<CreateSourceOfSupplyCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSourceOfSupplyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSourceOfSupplyCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSourceOfSupplyDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SourceOfSupplyDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SourceOfSupply = _mapper.Map<SourceOfSupply>(request.SourceOfSupplyDto);

                SourceOfSupply = await _unitOfWork.Repository<SourceOfSupply>().Add(SourceOfSupply);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SourceOfSupply.SourceOfSupplyId;
            }

            return response;
        }
    }
}
