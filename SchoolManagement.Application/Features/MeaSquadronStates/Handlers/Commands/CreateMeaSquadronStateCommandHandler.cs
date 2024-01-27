using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MeaSquadronState.Validators;
using SchoolManagement.Application.Features.MeaSquadronStates.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Handlers.Commands
{
    public class CreateMeaSquadronStateCommandHandler : IRequestHandler<CreateMeaSquadronStateCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMeaSquadronStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMeaSquadronStateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMeaSquadronStateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MeaSquadronStateDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MeaSquadronState = _mapper.Map<MeaSquadronState>(request.MeaSquadronStateDto);
                  MeaSquadronState.JobStatus = null;
                  MeaSquadronState.WorkCompletedStatus = 0;
                  MeaSquadronState = await _unitOfWork.Repository<MeaSquadronState>().Add(MeaSquadronState);

        //MeaSquadronState.WorkOrderDate = MeaSquadronState.WorkOrderDate.Value.AddDays(1.0);
              try
              {
                await _unitOfWork.Save();
              }
              catch (Exception ex)
              {

                Console.WriteLine(ex);
              }
        
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MeaSquadronState.MeaSquadronStateId;
            }

            return response;
        }
    }
}
