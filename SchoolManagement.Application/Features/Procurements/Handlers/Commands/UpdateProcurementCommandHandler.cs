using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Procurement.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Procurements.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.Procurements.Handlers.Commands
{
    public class UpdateProcurementCommandHandler : IRequestHandler<UpdateProcurementCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProcurementCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProcurementCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProcurementDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.UpdateProcurementDto);

            DateTime defaultDate = new DateTime(1970, 01, 01, 00, 00, 0);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Procurement = await _unitOfWork.Repository<Procurement>().Get(request.UpdateProcurementDto.ProcurementId);

            if (Procurement is null)
                throw new NotFoundException(nameof(Procurement), request.UpdateProcurementDto.ProcurementId);

            /////// File Upload //////////
            string uniqueFileNotice = null;
            string uniqueFileName = null;
            string uniqueFileApproval = null;
            string uniqueFileOrder = null;

            if (request.UpdateProcurementDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.UpdateProcurementDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\procurements", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.UpdateProcurementDto.Doc.CopyToAsync(fileSteam);
                }
            }
            if (request.UpdateProcurementDto.Notice != null)
            {

                var fileName = Path.GetFileName(request.UpdateProcurementDto.Notice.FileName);
                uniqueFileNotice = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\procurements", uniqueFileNotice);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.UpdateProcurementDto.Notice.CopyToAsync(fileSteam);
                }
            }
            if (request.UpdateProcurementDto.PrDoc != null)
            {

                var fileName = Path.GetFileName(request.UpdateProcurementDto.PrDoc.FileName);
                uniqueFileApproval = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\procurements", uniqueFileApproval);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.UpdateProcurementDto.PrDoc.CopyToAsync(fileSteam);
                }
            }
            
            _mapper.Map(request.UpdateProcurementDto, Procurement);
            Procurement.DateOfTenderFloat = Procurement.DateOfTenderFloat.Value.AddDays(1.0);
            Procurement.TenderopeningDate = Procurement.TenderopeningDate.Value.AddDays(1.0);
            Procurement.DateOfDelivery = Procurement.DateOfDelivery.Value.AddDays(1.0);

            if(request.UpdateProcurementDto.DateOfTenderFloat == defaultDate)
            {
                Procurement.DateOfTenderFloat = null;
            }
            if(request.UpdateProcurementDto.TenderopeningDate == defaultDate)
            {
                Procurement.TenderopeningDate = null;
            }
            if(request.UpdateProcurementDto.WorkOrderDate == defaultDate)
            {
                Procurement.WorkOrderDate = null;
            }
            if(request.UpdateProcurementDto.DateOfDelivery == defaultDate)
            {
                Procurement.DateOfDelivery = null;
            }

            Procurement.TenderSpecification = request.UpdateProcurementDto.Doc != null ? "files/procurements/" + uniqueFileName : Procurement.TenderSpecification.Replace("https://localhost:44395/Content/", String.Empty);
            Procurement.TenderNotice = request.UpdateProcurementDto.Notice != null ? "files/procurements/" + uniqueFileNotice : Procurement.TenderNotice.Replace("https://localhost:44395/Content/", String.Empty);
            Procurement.ProcurementDocument = request.UpdateProcurementDto.PrDoc != null ? "files/procurements/" + uniqueFileApproval : Procurement.ProcurementDocument.Replace("https://localhost:44395/Content/", String.Empty);
            
            await _unitOfWork.Repository<Procurement>().Update(Procurement);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
