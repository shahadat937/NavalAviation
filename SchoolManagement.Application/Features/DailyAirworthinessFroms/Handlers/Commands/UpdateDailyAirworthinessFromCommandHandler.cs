using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.DailyAirworthinessFrom.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DailyAirworthinessFroms.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.DailyAirworthinessFroms.Handlers.Commands
{
    public class UpdateDailyAirworthinessFromCommandHandler : IRequestHandler<UpdateDailyAirworthinessFromCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDailyAirworthinessFromCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDailyAirworthinessFromCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDailyAirworthinessFromDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.UpdateDailyAirworthinessFromDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DailyAirworthinessFrom = await _unitOfWork.Repository<DailyAirworthinessFrom>().Get(request.UpdateDailyAirworthinessFromDto.DailyAirworthinessFromId);

            if (DailyAirworthinessFrom is null)
                throw new NotFoundException(nameof(DailyAirworthinessFrom), request.UpdateDailyAirworthinessFromDto.DailyAirworthinessFromId);

            /////// File Upload //////////
            string uniqueFileName = null;


            if (request.UpdateDailyAirworthinessFromDto.Document != null)
            {

              var fileName = Path.GetFileName(request.UpdateDailyAirworthinessFromDto.Document.FileName);
              uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
              var a = Directory.GetCurrentDirectory();
              var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\daily-airworthiness-from", uniqueFileName);


              using (var fileSteam = new FileStream(filePath, FileMode.Create))
              {
                await request.UpdateDailyAirworthinessFromDto.Document.CopyToAsync(fileSteam);
              }
            }
            _mapper.Map(request.UpdateDailyAirworthinessFromDto, DailyAirworthinessFrom);
            DailyAirworthinessFrom.Doc = request.UpdateDailyAirworthinessFromDto.Document != null ? "files/daily-airworthiness-from/" + uniqueFileName : DailyAirworthinessFrom.Doc.Replace("https://localhost:44395/Content/", String.Empty);
            await _unitOfWork.Repository<DailyAirworthinessFrom>().Update(DailyAirworthinessFrom);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
