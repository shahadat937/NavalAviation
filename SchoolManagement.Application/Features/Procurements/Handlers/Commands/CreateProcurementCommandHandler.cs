using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Procurement;
using SchoolManagement.Application.DTOs.Procurement.Validators;
using SchoolManagement.Application.Features.Procurements.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Procurements.Handlers.Commands
{
    public class CreateProcurementCommandHandler : IRequestHandler<CreateProcurementCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProcurementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProcurementCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProcurementDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ProcurementDto);

            DateTime defaultDate = new DateTime(1970, 01, 01, 00, 00, 0);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                /////// File Upload //////////
                string uniqueFileNotice = null;
                string uniqueFileName = null;
                string uniqueFileApproval = null;
                string uniqueFileOrder = null;

                if (request.ProcurementDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.ProcurementDto.Doc.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\procurements", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.ProcurementDto.Doc.CopyToAsync(fileSteam);
                    }


                }
                if (request.ProcurementDto.Notice != null)
                {

                    var fileName = Path.GetFileName(request.ProcurementDto.Notice.FileName);
                    uniqueFileNotice = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\procurements", uniqueFileNotice);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.ProcurementDto.Notice.CopyToAsync(fileSteam);
                    }


                }
                if (request.ProcurementDto.PrDoc != null)
                {

                    var fileName = Path.GetFileName(request.ProcurementDto.PrDoc.FileName);
                    uniqueFileApproval = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\procurements", uniqueFileApproval);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.ProcurementDto.PrDoc.CopyToAsync(fileSteam);
                    }


                }

                var Procurement = _mapper.Map<Procurement>(request.ProcurementDto);
                Procurement.TenderSpecification = request.ProcurementDto.TenderSpecification ?? "files/procurements/" + uniqueFileName;
                Procurement.TenderNotice = request.ProcurementDto.TenderNotice ?? "files/procurements/" + uniqueFileNotice;
                Procurement.ProcurementDocument = request.ProcurementDto.ProcurementDocument ?? "files/procurements/" + uniqueFileApproval;
                Procurement.VerificationCompletStatus = 0;
                Procurement = await _unitOfWork.Repository<Procurement>().Add(Procurement);
                Procurement.DateOfTenderFloat = Procurement.DateOfTenderFloat.Value.AddDays(1.0);
                Procurement.TenderopeningDate = Procurement.TenderopeningDate.Value.AddDays(1.0);
                Procurement.DateOfDelivery = Procurement.DateOfDelivery.Value.AddDays(1.0);
                //Procurement.WorkOrderDate = Procurement.WorkOrderDate.Value.AddDays(1.0);

                if(request.ProcurementDto.DateOfTenderFloat == defaultDate)
                {
                    Procurement.DateOfTenderFloat = null;
                }
                if(request.ProcurementDto.TenderopeningDate == defaultDate)
                {
                    Procurement.TenderopeningDate = null;
                }
                if(request.ProcurementDto.WorkOrderDate == defaultDate)
                {
                    Procurement.WorkOrderDate = null;
                }
                if(request.ProcurementDto.DateOfDelivery == defaultDate)
                {
                    Procurement.DateOfDelivery = null;
                }

                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
               


                var demands = await _unitOfWork.Repository<Demand>().Get((int)request.ProcurementDto.DemandId);

                demands.DemandCompleteStatus = 1;

                

                await _unitOfWork.Repository<Demand>().Update(demands);
                
                await _unitOfWork.Save();



                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Procurement.ProcurementId;
            }

            return response;
        }
    }
}
