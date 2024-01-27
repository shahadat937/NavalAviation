using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.StockTransferNsd.Validators;
using SchoolManagement.Application.Features.StockTransferNsds.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.StockTransferNsds.Handlers.Commands
{
    public class CreateStockTransferNsdCommandHandler : IRequestHandler<CreateStockTransferNsdCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateStockTransferNsdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateStockTransferNsdCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateStockTransferNsdDtoValidator();
            var validationResult = await validator.ValidateAsync(request.StockTransferNsdDto);
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

              string uniqueFileName = null;


              if (request.StockTransferNsdDto.Document != null)
              {

                var fileName = Path.GetFileName(request.StockTransferNsdDto.Document.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\stock-transfer-nsd", uniqueFileName);
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                  await request.StockTransferNsdDto.Document.CopyToAsync(fileSteam);
                }
              }
              var StockTransferNsd = _mapper.Map<StockTransferNsd>(request.StockTransferNsdDto);
              //StockTransferNsd.VerificationCompletStatus = 0;
              StockTransferNsd.Doc = request.StockTransferNsdDto.Doc ?? "files/stock-transfer-nsd/" + uniqueFileName;
              StockTransferNsd.StockAdjustmentDate = StockTransferNsd.StockAdjustmentDate.Value.AddDays(1.0);
              if(request.StockTransferNsdDto.StockAdjustmentDate == defaultDate)
              {
                  StockTransferNsd.StockAdjustmentDate = null;
              }
              StockTransferNsd = await _unitOfWork.Repository<StockTransferNsd>().Add(StockTransferNsd);
              StockTransferNsd.VerificationCompletStatus = 0;
              var itemStor = await _unitOfWork.Repository<ItemStor>().Get((int)request.StockTransferNsdDto.ItemStorId);
              itemStor.NsdQty = itemStor.NsdQty - request.StockTransferNsdDto.TransferQty;
              itemStor.AvailableQty = itemStor.AvailableQty + request.StockTransferNsdDto.TransferQty;

              await _unitOfWork.Repository<ItemStor>().Update(itemStor);
              

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
                response.Id = StockTransferNsd.StockTransferNsdId;
            }

            return response;
        }
    }
}
