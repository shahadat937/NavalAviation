using AutoMapper;
using FluentValidation;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.IssueRegister.Validators;
using SchoolManagement.Application.Features.IssueRegisters.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IssueRegisters.Handlers.Commands
{
    public class CreateIssueRegisterCommandHandler : IRequestHandler<CreateIssueRegisterCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateIssueRegisterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateIssueRegisterCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateIssueRegisterDtoValidator();
            var validationResult = await validator.ValidateAsync(request.IssueRegisterDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var issueRegister = request.IssueRegisterDto;

                //For Update ItemStor table
                //var itemStoreId = issueRegister.ItemStoreList.Select(x => x.ItemStorId.Value).FirstOrDefault();
                //var itemStore= await _unitOfWork.Repository<ItemStor>().Get(itemStoreId);


                var issueRegisterList = issueRegister.ItemStoreList.Select(x => new IssueRegister()
                {
                    IssueRegisterId = issueRegister.IssueRegisterId.Value,
                    ItemStoreId = x.ItemStorId,
                    DepartmentNameId = x.DepartmentNameId,
                    SparesCategoryId = x.SparesCategoryId,
                    ItemDetailId = x.ItemDetailId,
                    TrainingCrewId =issueRegister.TrainingCrewId,
                    IssueStatusId = x.IssueStatusId,
                    TotalReceivedQty = x.TotalReceivedQty,
                    IssueQty = x.IssueQty,                    
                    IssueDate = issueRegister.IssueDate,
                    LastMaintenanceDate = issueRegister.LastMaintenanceDate,
                    LastCalibrationDate = issueRegister.LastCalibrationDate,
                    IssuedTo = issueRegister.IssuedTo,
                    Reason = issueRegister.Reason,
                    IsRefundable = x.IsRefundable,
                    AvailableQtyBeforeIssue = issueRegister.AvailableQtyBeforeIssue,
                    AvailableQtyAfterIssue = issueRegister.AvailableQtyAfterIssue,
                    ReceivedPerson = issueRegister.ReceivedPerson,
                    Remarks = issueRegister.Remarks,
                    IsActive = issueRegister.IsActive,
                });

        //For Update Item StorList and minus issue qty UserTransferBackup

        foreach (var item in issueRegisterList)
                {
                    var itemStor = await _unitOfWork.Repository<ItemStor>().Get(item.ItemStoreId.Value);
                    var availableQty = itemStor.AvailableQty;
                    var issueQty = item.IssueQty;

                    var storedIssueQty = itemStor.IssuedQty;
                    itemStor.IssuedQty = storedIssueQty + item.IssueQty;

                    itemStor.AvailableQty = availableQty - issueQty;

                      // parmanent
                      if (item.IssueStatusId == 1)
                      {
                        itemStor.PermanentQty += item.IssueQty;
                      }

                      //ty
                      if (item.IssueStatusId == 2)
                      {
                        itemStor.TYQty += item.IssueQty;
                        item.ReturnQty = item.IssueQty;
                      }
                      //survey
                      if (item.IssueStatusId == 5)
                      {
                        itemStor.SurveyQty += item.IssueQty;
                      }
                      //repair
                      if (item.IssueStatusId == 4)
                      {
                        itemStor.RepairQty += item.IssueQty;
                      }
                      //shift fitted 
                      if (item.IssueStatusId == 6)
                      {
                        itemStor.AircraftFittedQty += item.IssueQty;
                      }

                      //shift fitted 
                      if (item.IssueStatusId == 7)
                      {
                        itemStor.MaintenanceQty += item.IssueQty;
                      }

                      //calibration
                      if (item.IssueStatusId == 8)
                      {
                        itemStor.CalibrationQty += item.IssueQty;
                      }

                      await _unitOfWork.Repository<ItemStor>().Update(itemStor);
                      await _unitOfWork.Repository<IssueRegister>().Add(item);

                      await _unitOfWork.Save();
                }

                response.Success = true;
                response.Message = "Creation Successful";
            }

            return response;
        }
    }
}
