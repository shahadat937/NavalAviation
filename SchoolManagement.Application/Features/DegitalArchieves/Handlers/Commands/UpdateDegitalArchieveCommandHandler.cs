using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieve.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DegitalArchieves.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.DegitalArchieves.Handlers.Commands
{
    public class UpdateDegitalArchieveCommandHandler : IRequestHandler<UpdateDegitalArchieveCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDegitalArchieveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDegitalArchieveCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDegitalArchieveDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.UpdateDegitalArchieveDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DegitalArchieve = await _unitOfWork.Repository<DegitalArchieve>().Get(request.UpdateDegitalArchieveDto.DegitalArchieveId);

            if (DegitalArchieve is null)
                throw new NotFoundException(nameof(DegitalArchieve), request.UpdateDegitalArchieveDto.DegitalArchieveId);
            /////// File Upload //////////


            string uniqueFileName = null;


            if (request.UpdateDegitalArchieveDto.Document != null)
            {

              var fileName = Path.GetFileName(request.UpdateDegitalArchieveDto.Document.FileName);
              uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
              var a = Directory.GetCurrentDirectory();
              var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\degital-archieve", uniqueFileName);


              using (var fileSteam = new FileStream(filePath, FileMode.Create))
              {
                await request.UpdateDegitalArchieveDto.Document.CopyToAsync(fileSteam);
              }
            }
            _mapper.Map(request.UpdateDegitalArchieveDto, DegitalArchieve);
            DegitalArchieve.Doc = request.UpdateDegitalArchieveDto.Document != null ? "files/degital-archieve/" + uniqueFileName : DegitalArchieve.Doc.Replace("https://localhost:44395/Content/", String.Empty);
            //DegitalArchieve.Doc = request.UpdateDegitalArchieveDto.Document != null ? uniqueFileName : DegitalArchieve.Doc.Replace("https://localhost:44395/Content/", String.Empty);
            await _unitOfWork.Repository<DegitalArchieve>().Update(DegitalArchieve);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
