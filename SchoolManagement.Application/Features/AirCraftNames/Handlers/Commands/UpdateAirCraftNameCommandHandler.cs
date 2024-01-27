using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.AirCraftName.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using FluentValidation;
using ValidationException = SchoolManagement.Application.Exceptions.ValidationException;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Commands
{
    public class UpdateAirCraftNameCommandHandler : IRequestHandler<UpdateAirCraftNameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAirCraftNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAirCraftNameCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAirCraftNameDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.CreateAirCraftNameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var AirCraftName = await _unitOfWork.Repository<AirCraftName>().Get(request.CreateAirCraftNameDto.AirCraftNameId);

            if (AirCraftName is null)
                throw new NotFoundException(nameof(AirCraftName), request.CreateAirCraftNameDto.AirCraftNameId);
            /////// Image Upload //////////
            ///
            string uniqueFileName = null;

            if (request.CreateAirCraftNameDto.Photo != null)
            {

                var fileName = Path.GetFileName(request.CreateAirCraftNameDto.Photo.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\air-craft-name", uniqueFileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.CreateAirCraftNameDto.Photo.CopyToAsync(fileSteam);
                }

                
            }

            

            _mapper.Map(request.CreateAirCraftNameDto, AirCraftName);
            AirCraftName.Image = request.CreateAirCraftNameDto.Photo != null ? "files/air-craft-name/" + uniqueFileName : AirCraftName.Image.Replace("https://localhost:44395/Content/", String.Empty);

            await _unitOfWork.Repository<AirCraftName>().Update(AirCraftName);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
