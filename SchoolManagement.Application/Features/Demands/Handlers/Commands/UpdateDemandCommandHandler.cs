using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Demands.Validators;
using SchoolManagement.Application.Features.Demands.Requests.Commands;

namespace SchoolManagement.Application.Features.Demands.Handlers.Commands
{
    public class UpdateDemandCommandHandler : IRequestHandler<UpdateDemandCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDemandCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDemandCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDemandDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.UpdateDemandDto);

            DateTime defaultDate = new DateTime(1970, 01, 01, 00, 00, 0);

            var checkTime = request.UpdateDemandDto.DemandDate.Value.ToString("MM/dd/yyyy");
            

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Demand = await _unitOfWork.Repository<Demand>().Get(request.UpdateDemandDto.DemandId);

            if (Demand is null)
                throw new NotFoundException(nameof(Demand), request.UpdateDemandDto.DemandId);

            /////// File Upload //////////

           
            string uniqueFileName = null;

            ///
            string uniqueFileNameDemandLetter = null;
            string uniqueFileNameTenderSpec = null;


            if (request.UpdateDemandDto.Doc != null)
            {

                var fileName = Path.GetFileName(request.UpdateDemandDto.Doc.FileName);
                uniqueFileNameDemandLetter = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\demand", uniqueFileNameDemandLetter);


                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.UpdateDemandDto.Doc.CopyToAsync(fileSteam);
                }
            }
            if (request.UpdateDemandDto.SpecDocument != null)
            {
                var fileName = Path.GetFileName(request.UpdateDemandDto.SpecDocument.FileName);
                uniqueFileNameTenderSpec = Guid.NewGuid().ToString() + "_" + fileName;
                var a = Directory.GetCurrentDirectory();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\demand", uniqueFileNameTenderSpec);


            //_mapper.Map(request.UpdateDemandDto, Demand);
            //Demand.DemandLetterNo = request.UpdateDemandDto.Doc != null ? "files/demand/" + uniqueFileName : Demand.DemandLetterNo.Replace("https://localhost:44395/Content/", String.Empty);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await request.UpdateDemandDto.SpecDocument.CopyToAsync(fileSteam);
                }
            }

            _mapper.Map(request.UpdateDemandDto, Demand);
            Demand.DemandDate = Demand.DemandDate.Value.AddDays(1.0);
        //Demand.DemandCompleteStatus = 0;
          Demand.DemandLetterNo = request.UpdateDemandDto.Doc != null ? "files/demand/" + uniqueFileNameDemandLetter : Demand.DemandLetterNo.Replace("https://localhost:44395/Content/", String.Empty);
          Demand.SpecDoc = request.UpdateDemandDto.SpecDocument != null ? "files/demand/" + uniqueFileNameTenderSpec : Demand.SpecDoc.Replace("https://localhost:44395/Content/", String.Empty);
        //Demand.DemandLetterNo = request.UpdateDemandDto.Doc != null ?  uniqueFileNameDemandLetter : Demand.DemandLetterNo.Replace("https://localhost:44395/Content/", String.Empty);
        //Demand.SpecDoc = request.UpdateDemandDto.SpecDocument != null ? uniqueFileNameTenderSpec : Demand.SpecDoc.Replace("https://localhost:44395/Content/", String.Empty);

      await _unitOfWork.Repository<Demand>().Update(Demand);
            if(request.UpdateDemandDto.DemandDate == defaultDate)
                    {
                        Demand.DemandDate = null;
                    }
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
