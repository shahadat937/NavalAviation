using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DegitalArchieve.Validators;
using SchoolManagement.Application.Features.DegitalArchieves.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.DegitalArchieves.Handlers.Commands
{
    public class CreateDegitalArchieveCommandHandler : IRequestHandler<CreateDegitalArchieveCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDegitalArchieveCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDegitalArchieveCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDegitalArchieveDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DegitalArchieveDto);

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


                if (request.DegitalArchieveDto.Document != null)
                {

                  var fileName = Path.GetFileName(request.DegitalArchieveDto.Document.FileName);
                  uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
                  var a = Directory.GetCurrentDirectory();
                  var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\degital-archieve", uniqueFileName);
                  using (var fileSteam = new FileStream(filePath, FileMode.Create))
                  {
                    await request.DegitalArchieveDto.Document.CopyToAsync(fileSteam);
                  }
                }
                var DegitalArchieve = _mapper.Map<DegitalArchieve>(request.DegitalArchieveDto);
                //DegitalArchieve.Doc = request.DegitalArchieveDto.Doc ?? "files/demand/" + uniqueFileNameTenderSpec;
                DegitalArchieve.Doc = request.DegitalArchieveDto.Doc ?? "files/degital-archieve/" + uniqueFileName;
                //DegitalArchieve.Doc = request.DegitalArchieveDto.Doc ?? uniqueFileName;
                DegitalArchieve = await _unitOfWork.Repository<DegitalArchieve>().Add(DegitalArchieve);
                DegitalArchieve.DateOfLastRev = DegitalArchieve.DateOfLastRev.Value.AddDays(1.0);
                await _unitOfWork.Save();
                
               


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DegitalArchieve.DegitalArchieveId;
            }

            return response;
        }
    }
}
