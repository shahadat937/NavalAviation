using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaintenenceState.Validators;
using SchoolManagement.Application.Features.MaintenenceStates.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MaintenenceStates.Handlers.Commands
{
    public class CreateMaintenenceStateCommandHandler : IRequestHandler<CreateMaintenenceStateCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMaintenenceStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMaintenenceStateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMaintenenceStateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MaintenenceStateDto);

            //if (validationResult.IsValid == false)
            //{
            //    response.Success = false;
            //    response.Message = "Creation Failed";
            //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            //}
            //else
            //{
                var MaintenenceState = _mapper.Map<MaintenenceState>(request.MaintenenceStateDto);

                MaintenenceState = await _unitOfWork.Repository<MaintenenceState>().Add(MaintenenceState);
                MaintenenceState.LastDateofMaintenence = MaintenenceState.LastDateofMaintenence.Value.AddDays(1.0);
                MaintenenceState.NextDueDate = MaintenenceState.NextDueDate.Value.AddDays(1.0);

                await _unitOfWork.Save();


     // Get Item Stor Data
                var itemStor = await _unitOfWork.Repository<ItemStor>().Get(MaintenenceState.ItemStoreId.Value);
                itemStor.NextMaintenenceDate = MaintenenceState.NextDueDate;
                itemStor.LastMaintenanceDate = MaintenenceState.LastDateofMaintenence;


                await _unitOfWork.Repository<ItemStor>().Update(itemStor);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MaintenenceState.MaintenenceStateId;
           // }

            return response;
        }
    }
}
