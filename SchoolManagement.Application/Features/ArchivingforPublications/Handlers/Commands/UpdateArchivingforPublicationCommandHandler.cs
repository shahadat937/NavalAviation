using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ArchivingforPublication.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ArchivingforPublications.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Handlers.Commands
{
    public class UpdateArchivingforPublicationCommandHandler : IRequestHandler<UpdateArchivingforPublicationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateArchivingforPublicationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateArchivingforPublicationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateArchivingforPublicationDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.UpdateArchivingforPublicationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ArchivingforPublication = await _unitOfWork.Repository<ArchivingforPublication>().Get(request.UpdateArchivingforPublicationDto.ArchivingforPublicationId);

            if (ArchivingforPublication is null)
                throw new NotFoundException(nameof(ArchivingforPublication), request.UpdateArchivingforPublicationDto.ArchivingforPublicationId);

            /////// File Upload //////////


            string uniqueFileName = null;


            if (request.UpdateArchivingforPublicationDto.Document != null)
            {

              var fileName = Path.GetFileName(request.UpdateArchivingforPublicationDto.Document.FileName);
              uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
              var a = Directory.GetCurrentDirectory();
              var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\archiving-for-publication", uniqueFileName);


              using (var fileSteam = new FileStream(filePath, FileMode.Create))
              {
                await request.UpdateArchivingforPublicationDto.Document.CopyToAsync(fileSteam);
              }
            }
            _mapper.Map(request.UpdateArchivingforPublicationDto, ArchivingforPublication);
            ArchivingforPublication.DocUpload = request.UpdateArchivingforPublicationDto.Document != null ? "files/archiving-for-publication/" + uniqueFileName : ArchivingforPublication.DocUpload.Replace("https://localhost:44395/Content/", String.Empty);
            await _unitOfWork.Repository<ArchivingforPublication>().Update(ArchivingforPublication);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
