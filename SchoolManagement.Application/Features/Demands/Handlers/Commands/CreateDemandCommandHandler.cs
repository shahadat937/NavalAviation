using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Demands.Validators;
using SchoolManagement.Application.Features.Demands.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Demands.Handlers.Commands
{
    public class CreateDemandCommandHandler : IRequestHandler<CreateDemandCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDemandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDemandCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDemandDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DemandDto);
         
            DateTime defaultDate = new DateTime(1970, 01, 01, 00, 00, 0);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {

                /////// File Upload //////////

                string uniqueFileNameDemandLetter = null;
                string uniqueFileNameTenderSpec = null;


                if (request.DemandDto.Doc != null)
                {

                    var fileName = Path.GetFileName(request.DemandDto.Doc.FileName);
                    uniqueFileNameDemandLetter = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\demand", uniqueFileNameDemandLetter);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.DemandDto.Doc.CopyToAsync(fileSteam);
                    }
                }

                if (request.DemandDto.SpecDocument != null)
                {
                    var fileName = Path.GetFileName(request.DemandDto.SpecDocument.FileName);
                    uniqueFileNameTenderSpec = Guid.NewGuid().ToString() + "_" + fileName;
                    var a = Directory.GetCurrentDirectory();
                    //var filePath = Path.Combine(_hostingEnv.WebRootPath, "Content\\images\\profile", uniqueFileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\demand", uniqueFileNameTenderSpec);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await request.DemandDto.SpecDocument.CopyToAsync(fileSteam);
                    }
                }
                ////
                //  DateTime? d = request.TraineeBioDataGeneralInfoDto.DateOfBirth.ConvertToDateTime();

                var demands = _mapper.Map<Demand>(request.DemandDto);
                demands.DemandCompleteStatus = 0;
                demands.VerificationCompletStatus = 0;
                demands.DemandLetterNo = request.DemandDto.DemandLetterNo ?? "files/demand/" + uniqueFileNameDemandLetter;
                demands.SpecDoc = request.DemandDto.SpecDoc ?? "files/demand/" + uniqueFileNameTenderSpec;
        //demands.DemandLetterNo = request.DemandDto.DemandLetterNo ??  uniqueFileNameDemandLetter;
        //        demands.SpecDoc = request.DemandDto.SpecDoc ?? uniqueFileNameTenderSpec;

        // var ReadingMaterials = _mapper.Map<ReadingMaterial>(request.ReadingMaterialDto);


        demands = await _unitOfWork.Repository<Demand>().Add(demands);
                    demands.DemandDate = demands.DemandDate.Value.AddDays(1.0);
                    if(request.DemandDto.DemandDate == defaultDate)
                    {
                        demands.DemandDate = null;
                    }
                    await _unitOfWork.Save();
                
                

                
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = demands.DemandId;
            }

            return response;
        }
    }
}
