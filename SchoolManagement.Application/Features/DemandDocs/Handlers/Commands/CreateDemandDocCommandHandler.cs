using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DemandDocs.Validators;
using SchoolManagement.Application.Features.DemandDocs.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DemandDocs.Handlers.Commands
{
    public class CreateDemandDocCommandHandler : IRequestHandler<CreateDemandDocCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDemandDocCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDemandDocCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDemandDocDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DemandDocDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DemandDoc = _mapper.Map<DemandDoc>(request.DemandDocDto);

                DemandDoc = await _unitOfWork.Repository<DemandDoc>().Add(DemandDoc);

                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DemandDoc.DemandDocId;
            }

            return response;
        }
    }
}
