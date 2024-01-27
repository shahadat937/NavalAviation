using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NameofPublication.Validators;
using SchoolManagement.Application.Features.NameofPublications.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.NameofPublications.Handlers.Commands
{
    public class CreateNameofPublicationCommandHandler : IRequestHandler<CreateNameofPublicationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateNameofPublicationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateNameofPublicationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateNameofPublicationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.NameofPublicationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var NameofPublication = _mapper.Map<NameofPublication>(request.NameofPublicationDto);

                NameofPublication = await _unitOfWork.Repository<NameofPublication>().Add(NameofPublication);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = NameofPublication.NameofPublicationId;
            }

            return response;
        }
    }
}
