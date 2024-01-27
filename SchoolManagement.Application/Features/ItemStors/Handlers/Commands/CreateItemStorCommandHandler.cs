using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ItemStor.Validators;
using SchoolManagement.Application.Features.ItemStors.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Commands
{
    public class CreateItemStorCommandHandler : IRequestHandler<CreateItemStorCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateItemStorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateItemStorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateItemStorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ItemStorDto);

            DateTime defaultDate = new DateTime(1970, 01, 01, 00, 00, 0);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {


                  if (request.ItemStorDto.AcceptanceId != null)
                  {

                    var Acceptances = await _unitOfWork.Repository<Acceptance>().Get((int)request.ItemStorDto.AcceptanceId);


                    if (request.ItemStorDto.ProcurementStatusId == 1)
                    {
                      var indevidualQty = 1;
                      var accSftQty = Acceptances.StoreQty;
                      var accQty = Acceptances.SftQty;
                      var storSftQty = indevidualQty;
                      var remainAccQty = accSftQty + storSftQty;
                      Acceptances.StoreQty = remainAccQty;
                      Acceptances.StoreQtyStatus = request.ItemStorDto.QtyEntryType;
                      request.ItemStorDto.AvailableQty = indevidualQty;
                      request.ItemStorDto.TotalReceivedQty = indevidualQty;
                      if (remainAccQty < accQty)
                      {
                        Acceptances.SftStatus = 0;


                      }
                      else
                      {

                        Acceptances.SftStatus = 1;
                      }
                    }
                    else if (request.ItemStorDto.ProcurementStatusId ==2)
                    {
                      Acceptances.StoreQty = Acceptances.SftQty;
                      request.ItemStorDto.AvailableQty = request.ItemStorDto.TotalReceivedQty;
                      request.ItemStorDto.TotalReceivedQty = request.ItemStorDto.TotalReceivedQty;
                      Acceptances.StoreQtyStatus = request.ItemStorDto.QtyEntryType;
                      Acceptances.SftStatus = 1;
                    } 
                    else
                    {                     
                      Acceptances.StoreQty = Acceptances.SftQty;
                      request.ItemStorDto.AvailableQty = Acceptances.SftQty;
                      request.ItemStorDto.TotalReceivedQty = Acceptances.SftQty;
                      Acceptances.StoreQtyStatus = request.ItemStorDto.QtyEntryType;
                      Acceptances.SftStatus = 1;
                    }

                    /////// File Upload //////////

                    string uniqueFileName = null;


                    if (request.ItemStorDto.Doc != null)
                    {

                      var fileName = Path.GetFileName(request.ItemStorDto.Doc.FileName);
                      uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                      var a = Directory.GetCurrentDirectory();
                      //if (ItemStor.OtherDoc== null)
                      //{

                      //}
                      var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\item-stores", uniqueFileName);
                      using (var fileSteam = new FileStream(filePath, FileMode.Create))
                      {
                        await request.ItemStorDto.Doc.CopyToAsync(fileSteam);
                      }
                    }

                    var ItemStor = _mapper.Map<ItemStor>(request.ItemStorDto);
                    //ItemStor.OtherDoc = request.ItemStorDto.OtherDoc ?? "files/item-stores/" + uniqueFileName;
                    ItemStor.OtherDoc = request.ItemStorDto.OtherDoc ?? uniqueFileName;

                    ItemStor = await _unitOfWork.Repository<ItemStor>().Add(ItemStor);
                    ItemStor.VerificationCompletStatus = 0;
                    ItemStor.DemandDate = ItemStor.DemandDate.Value.AddDays(1.0);
                    ItemStor.ManufacturingDate = ItemStor.ManufacturingDate.Value.AddDays(1.0);
                    ItemStor.WarrantyEndDate = ItemStor.WarrantyEndDate.Value.AddDays(1.0);

                    if(request.ItemStorDto.DemandDate == defaultDate)
                    {
                        ItemStor.DemandDate = null;
                    }
                    if(request.ItemStorDto.ManufacturingDate == defaultDate)
                    {
                        ItemStor.ManufacturingDate = null;
                    }
                    if(request.ItemStorDto.WarrantyEndDate == defaultDate)
                    {
                        ItemStor.WarrantyEndDate = null;
                    }
                    ItemStor.IssuedQty = 0;
                 //   ItemStor
                 //ItemStor.ItemReceivedDate = ItemStor.ItemReceivedDate.Value.AddDays(1.0);

                    //Update  nsd Qty and available qty
                    if (ItemStor.ToolsLocationId == 8)
                    {
                      ItemStor.NsdQty = ItemStor.AvailableQty;
                      ItemStor.AvailableQty = 0;
                    }

                    if (ItemStor.ToolsLocationId == 1)
                    {
                      ItemStor.NsdQty = 0;
                      ItemStor.AvailableQty = ItemStor.AvailableQty;
                    }

                    await _unitOfWork.Repository<Acceptance>().Update(Acceptances);
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
                    response.Id = ItemStor.ItemStorId;
                  }
                  else
                  {
                    /////// File Upload //////////

                    string uniqueFileName = null;


                    if (request.ItemStorDto.Doc != null)
                    {

                      var fileName = Path.GetFileName(request.ItemStorDto.Doc.FileName);
                      uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                      var a = Directory.GetCurrentDirectory();
                      var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\item-stores", uniqueFileName);
                      using (var fileSteam = new FileStream(filePath, FileMode.Create))
                      {
                        await request.ItemStorDto.Doc.CopyToAsync(fileSteam);
                      }
                    }

                    var ItemStor = _mapper.Map<ItemStor>(request.ItemStorDto);
                    ItemStor.OtherDoc = request.ItemStorDto.OtherDoc ?? "files/item-stores/" + uniqueFileName;

                    ItemStor = await _unitOfWork.Repository<ItemStor>().Add(ItemStor);
                    ItemStor.VerificationCompletStatus = 0;
                    ItemStor.DemandDate = ItemStor.DemandDate.Value.AddDays(1.0);
                    ItemStor.ManufacturingDate = ItemStor.ManufacturingDate.Value.AddDays(1.0);
                    ItemStor.WarrantyEndDate = ItemStor.WarrantyEndDate.Value.AddDays(1.0);
                    if(request.ItemStorDto.DemandDate == defaultDate)
                    {
                        ItemStor.DemandDate = null;
                    }
                    if(request.ItemStorDto.ManufacturingDate == defaultDate)
                    {
                        ItemStor.ManufacturingDate = null;
                    }
                    if(request.ItemStorDto.WarrantyEndDate == defaultDate)
                    {
                        ItemStor.WarrantyEndDate = null;
                    }
                    ItemStor.IssuedQty = 0;

                    if (ItemStor.ToolsLocationId == 8)
                    {
                      ItemStor.NsdQty = ItemStor.AvailableQty;
                      ItemStor.AvailableQty = 0;
                    }

                    if (ItemStor.ToolsLocationId == 1)
                    {
                      ItemStor.NsdQty = 0;
                      ItemStor.AvailableQty = ItemStor.AvailableQty;
                    }

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
                    response.Id = ItemStor.ItemStorId;
                  }                                                            
            }

            return response;
        }
    }
}
