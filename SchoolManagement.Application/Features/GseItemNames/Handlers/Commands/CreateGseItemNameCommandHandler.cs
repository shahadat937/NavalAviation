using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.GseItemName.Validators;
using SchoolManagement.Application.Features.GseItemNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GseItemNames.Handlers.Commands
{
    public class CreateGseItemNameCommandHandler : IRequestHandler<CreateGseItemNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGseItemNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGseItemNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGseItemNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GseItemNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var GseItemName = _mapper.Map<GseItemName>(request.GseItemNameDto);

                GseItemName = await _unitOfWork.Repository<GseItemName>().Add(GseItemName);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = GseItemName.GseItemNameId;
            }

            return response;
        }
    }
}
