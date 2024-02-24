using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CallibrationState.Validators;
using SchoolManagement.Application.Features.CallibrationStates.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CallibrationStates.Handlers.Commands
{
    public class CreateCallibrationStateCommandHandler : IRequestHandler<CreateCallibrationStateCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCallibrationStateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCallibrationStateCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCallibrationStateDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CallibrationStateDto);

            //if (validationResult.IsValid == false)
            //{
            //    response.Success = false;
            //    response.Message = "Creation Failed";
            //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            //}
            //else
            //{
                var CallibrationState = _mapper.Map<CallibrationState>(request.CallibrationStateDto);

                CallibrationState = await _unitOfWork.Repository<CallibrationState>().Add(CallibrationState);
                CallibrationState.LastDateofCalibrated = CallibrationState.LastDateofCalibrated.Value.AddDays(1.0);
                CallibrationState.NextDueDate = CallibrationState.NextDueDate.Value.AddDays(1.0);

                await _unitOfWork.Save();


      //Get Item Stor Data
      try
      {
        var itemStor = await _unitOfWork.Repository<ItemStor>().Get(CallibrationState.ItemStoreId.Value);
        itemStor.NextCalibrationDate = CallibrationState.NextDueDate;
        itemStor.LastCalibrationDate = CallibrationState.LastDateofCalibrated;


        await _unitOfWork.Repository<ItemStor>().Update(itemStor);
        await _unitOfWork.Save();
      }
      catch (Exception e)
      {

        throw;
      }
              

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CallibrationState.CallibrationStateId;
           // }

            return response;
        }
    }
}
