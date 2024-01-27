using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.StockTransferNsd.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.StockTransferNsds.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.StockTransferNsds.Handlers.Commands
{
    public class UpdateStockTransferNsdCommandHandler : IRequestHandler<UpdateStockTransferNsdCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStockTransferNsdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStockTransferNsdCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStockTransferNsdDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.UpdateStockTransferNsdDto);
            DateTime defaultDate = new DateTime(1970, 01, 01, 00, 00, 0);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var StockTransferNsd = await _unitOfWork.Repository<StockTransferNsd>().Get(request.UpdateStockTransferNsdDto.StockTransferNsdId);

            if (StockTransferNsd is null)
                throw new NotFoundException(nameof(StockTransferNsd), request.UpdateStockTransferNsdDto.StockTransferNsdId);
            /////// File Upload //////////


          string uniqueFileName = null;


          if (request.UpdateStockTransferNsdDto.Document != null)
          {

              var fileName = Path.GetFileName(request.UpdateStockTransferNsdDto.Document.FileName);
              uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
              var a = Directory.GetCurrentDirectory();
              var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\stock-transfer-nsd", uniqueFileName);


              using (var fileSteam = new FileStream(filePath, FileMode.Create))
              {
                await request.UpdateStockTransferNsdDto.Document.CopyToAsync(fileSteam);
              }
          }
          _mapper.Map(request.UpdateStockTransferNsdDto, StockTransferNsd);
          StockTransferNsd.Doc = request.UpdateStockTransferNsdDto.Document != null ? "files/stock-transfer-nsd/" + uniqueFileName : StockTransferNsd.Doc.Replace("https://localhost:44395/Content/", String.Empty);
          StockTransferNsd.StockAdjustmentDate = StockTransferNsd.StockAdjustmentDate.Value.AddDays(1.0);
          if (request.UpdateStockTransferNsdDto.StockAdjustmentDate == defaultDate)
          {
            StockTransferNsd.StockAdjustmentDate = null;
          }
          await _unitOfWork.Repository<StockTransferNsd>().Update(StockTransferNsd);
          try
          {
              await _unitOfWork.Save();
          }
          catch (Exception ex)
          {

            Console.WriteLine(ex);
          }
           

            return Unit.Value;
        }
    }
}
