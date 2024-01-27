using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom.Validators;
using SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Handlers.Commands
{
    public class CreateDailyAirworthinessFromCommandHandler : IRequestHandler<CreateDailyAirworthinessFromCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDailyAirworthinessFromCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDailyAirworthinessFromCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDailyAirworthinessFromDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DailyAirworthinessFromDto);

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


                if (request.DailyAirworthinessFromDto.Document != null)
                {

                  var fileName = Path.GetFileName(request.DailyAirworthinessFromDto.Document.FileName);
                  uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                  var a = Directory.GetCurrentDirectory();
                  //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                  var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\daily-airworthiness-from", uniqueFileName);
                  using (var fileSteam = new FileStream(filePath, FileMode.Create))
                  {
                    await request.DailyAirworthinessFromDto.Document.CopyToAsync(fileSteam);
                  }
                }

                var DailyAirworthinessFrom = _mapper.Map<DailyAirworthinessFrom>(request.DailyAirworthinessFromDto);
                DailyAirworthinessFrom.Doc = request.DailyAirworthinessFromDto.Doc ?? "files/daily-airworthiness-from/" + uniqueFileName;
                //DailyAirworthinessFrom.UploadDate = DailyAirworthinessFrom.UploadDate.Value.AddDays(1.0);
                DailyAirworthinessFrom = await _unitOfWork.Repository<DailyAirworthinessFrom>().Add(DailyAirworthinessFrom);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DailyAirworthinessFrom.DailyAirworthinessFromId;
            }

            return response;
        }
    }
}
