using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MeaBlankFormat.Validators;
using SchoolManagement.Application.Features.MeaBlankFormats.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Handlers.Commands
{
    public class CreateMeaBlankFormatCommandHandler : IRequestHandler<CreateMeaBlankFormatCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMeaBlankFormatCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMeaBlankFormatCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMeaBlankFormatDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MeaBlankFormatDto);

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


                if (request.MeaBlankFormatDto.Document != null)
                {

                  var fileName = Path.GetFileName(request.MeaBlankFormatDto.Document.FileName);
                  uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                  var a = Directory.GetCurrentDirectory();
                  var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\mea-blank-format", uniqueFileName);
                  using (var fileSteam = new FileStream(filePath, FileMode.Create))
                  {
                    await request.MeaBlankFormatDto.Document.CopyToAsync(fileSteam);
                  }
                }
                var MeaBlankFormat = _mapper.Map<MeaBlankFormat>(request.MeaBlankFormatDto);
                MeaBlankFormat.Doc = request.MeaBlankFormatDto.Doc ?? "files/mea-blank-format/" + uniqueFileName;
                MeaBlankFormat = await _unitOfWork.Repository<MeaBlankFormat>().Add(MeaBlankFormat);
               
                    await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MeaBlankFormat.MeaBlankFormatId;
            }

            return response;
        }
    }
}
