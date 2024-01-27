using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ArchivingforPublication.Validators;
using SchoolManagement.Application.Features.ArchivingforPublications.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Handlers.Commands
{
    public class CreateArchivingforPublicationCommandHandler : IRequestHandler<CreateArchivingforPublicationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateArchivingforPublicationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateArchivingforPublicationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateArchivingforPublicationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ArchivingforPublicationDto);

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


                if (request.ArchivingforPublicationDto.Document != null)
                {

                  var fileName = Path.GetFileName(request.ArchivingforPublicationDto.Document.FileName);
                  uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                  var a = Directory.GetCurrentDirectory();
                  var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\archiving-for-publication", uniqueFileName);
                  using (var fileSteam = new FileStream(filePath, FileMode.Create))
                  {
                    await request.ArchivingforPublicationDto.Document.CopyToAsync(fileSteam);
                  }
                }
                var ArchivingforPublication = _mapper.Map<ArchivingforPublication>(request.ArchivingforPublicationDto);
                ArchivingforPublication.DocUpload = request.ArchivingforPublicationDto.DocUpload ?? "files/archiving-for-publication/" + uniqueFileName;
                ArchivingforPublication = await _unitOfWork.Repository<ArchivingforPublication>().Add(ArchivingforPublication);
                ArchivingforPublication.Date = ArchivingforPublication.Date.Value.AddDays(1.0);
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
                response.Id = ArchivingforPublication.ArchivingforPublicationId;
            }

            return response;
        }
    }
}
