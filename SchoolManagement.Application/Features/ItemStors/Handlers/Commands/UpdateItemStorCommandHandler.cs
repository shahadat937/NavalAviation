using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ItemStor.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ItemStors.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.ItemStors.Handlers.Commands
{
    public class UpdateItemStorCommandHandler : IRequestHandler<UpdateItemStorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateItemStorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateItemStorCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateItemStorDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.UpdateItemStorDto);
            DateTime defaultDate = new DateTime(1970, 01, 01, 00, 00, 0);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ItemStor = await _unitOfWork.Repository<ItemStor>().Get(request.UpdateItemStorDto.ItemStorId);

            if (ItemStor is null)
                throw new NotFoundException(nameof(ItemStor), request.UpdateItemStorDto.ItemStorId);
            
            /////// File Upload //////////


            string uniqueFileName = null;

            if (request.UpdateItemStorDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.UpdateItemStorDto.Doc.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\item-stores", uniqueFileName);


                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.UpdateItemStorDto.Doc.CopyToAsync(fileSteam);
                }
            }
            _mapper.Map(request.UpdateItemStorDto, ItemStor);
            ItemStor.DemandDate = ItemStor.DemandDate.Value.AddDays(1.0);
            ItemStor.ManufacturingDate = ItemStor.ManufacturingDate.Value.AddDays(1.0);
            ItemStor.WarrantyEndDate = ItemStor.WarrantyEndDate.Value.AddDays(1.0);
            //ItemStor.ItemReceivedDate = ItemStor.ItemReceivedDate.Value.AddDays(1.0);
            if (request.UpdateItemStorDto.DemandDate == defaultDate)
            {
              ItemStor.DemandDate = null;
            }
            if (request.UpdateItemStorDto.ManufacturingDate == defaultDate)
            {
              ItemStor.ManufacturingDate = null;
            }
            if (request.UpdateItemStorDto.WarrantyEndDate == defaultDate)
            {
              ItemStor.WarrantyEndDate = null;
            }
            ItemStor.OtherDoc = request.UpdateItemStorDto.Doc != null ? "files/item-stores/" + uniqueFileName : ItemStor.OtherDoc.Replace("https://localhost:44395/Content/", String.Empty);
            await _unitOfWork.Repository<ItemStor>().Update(ItemStor);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
