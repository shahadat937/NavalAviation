using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AirCraftName.Validators;
using SchoolManagement.Application.Features.AirCraftNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AirCraftNames.Handlers.Commands
{
    public class CreateAirCraftNameCommandHandler : IRequestHandler<CreateAirCraftNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAirCraftNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAirCraftNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAirCraftNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AirCraftNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                /////// Image Upload //////////
                ///
                string uniqueFileName = null;

                if (request.AirCraftNameDto.Photo != null)
                {

                    var fileName = Path.GetFileName(request.AirCraftNameDto.Photo.FileName);
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\air-craft-name", uniqueFileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.AirCraftNameDto.Photo.CopyToAsync(fileSteam);
                    }


                }
                var AirCraftName = _mapper.Map<AirCraftName>(request.AirCraftNameDto);
                AirCraftName.Image = request.AirCraftNameDto.Image ?? "files/air-craft-name/" + uniqueFileName;

                AirCraftName = await _unitOfWork.Repository<AirCraftName>().Add(AirCraftName);
                AirCraftName.MaintenenceState = 0;
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = AirCraftName.AirCraftNameId;
            }

            return response;
        }
    }
}
