using AutoMapper;
using SchoolManagement.Application.DTOs.Caste.Validators;
using SchoolManagement.Application.Features.Castes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Castes.Handlers.Commands
{
    public class CreateCasteCommandHandler : IRequestHandler<CreateCasteCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCasteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCasteCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCasteDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CasteDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Castes = _mapper.Map<Caste>(request.CasteDto);

                Castes = await _unitOfWork.Repository<Caste>().Add(Castes);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Castes.CasteId;
            }

            return response;
        }
    }
}
