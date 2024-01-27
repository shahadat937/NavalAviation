using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.MeaBlankFormat.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.MeaBlankFormats.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Handlers.Commands
{
    public class UpdateMeaBlankFormatCommandHandler : IRequestHandler<UpdateMeaBlankFormatCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMeaBlankFormatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMeaBlankFormatCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMeaBlankFormatDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.UpdateMeaBlankFormatDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var MeaBlankFormat = await _unitOfWork.Repository<MeaBlankFormat>().Get(request.UpdateMeaBlankFormatDto.MeaBlankFormatId);

            if (MeaBlankFormat is null)
                throw new NotFoundException(nameof(MeaBlankFormat), request.UpdateMeaBlankFormatDto.MeaBlankFormatId);
            /////// File Upload //////////


            string uniqueFileName = null;


            if (request.UpdateMeaBlankFormatDto.Document != null)
            {

              var fileName = Path.GetFileName(request.UpdateMeaBlankFormatDto.Document.FileName);
              uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
              var a = Directory.GetCurrentDirectory();
              var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\mea-blank-format", uniqueFileName);


              using (var fileSteam = new FileStream(filePath, FileMode.Create))
              {
                await request.UpdateMeaBlankFormatDto.Document.CopyToAsync(fileSteam);
              }
            }
            _mapper.Map(request.UpdateMeaBlankFormatDto, MeaBlankFormat);
            MeaBlankFormat.Doc = request.UpdateMeaBlankFormatDto.Document != null ? "files/mea-blank-format/" + uniqueFileName : MeaBlankFormat.Doc.Replace("https://localhost:44395/Content/", String.Empty);
            await _unitOfWork.Repository<MeaBlankFormat>().Update(MeaBlankFormat);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
