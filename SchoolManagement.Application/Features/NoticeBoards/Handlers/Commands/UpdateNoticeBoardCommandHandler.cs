using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NoticeBoards.Validators;
using SchoolManagement.Application.Features.NoticeBoards.Requests.Commands;

namespace SchoolManagement.Application.Features.NoticeBoards.Handlers.Commands
{
    public class UpdateNoticeBoardCommandHandler : IRequestHandler<UpdateNoticeBoardCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNoticeBoardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNoticeBoardCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNoticeBoardDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.UpdateNoticeBoardDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var NoticeBoard = await _unitOfWork.Repository<NoticeBoard>().Get(request.UpdateNoticeBoardDto.NoticeBoardId);

            if (NoticeBoard is null)
                throw new NotFoundException(nameof(NoticeBoard), request.UpdateNoticeBoardDto.NoticeBoardId);

          /////// File Upload //////////


          string uniqueFileName = null;


          if (request.UpdateNoticeBoardDto.Doc != null)
          {

            var fileName = Path.GetFileName(request.UpdateNoticeBoardDto.Doc.FileName);
            uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            var a = Directory.GetCurrentDirectory();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\notice", uniqueFileName);
  
            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
              await request.UpdateNoticeBoardDto.Doc.CopyToAsync(fileSteam);
            }
          }
          _mapper.Map(request.UpdateNoticeBoardDto, NoticeBoard);

          NoticeBoard.NoticeDocument = request.UpdateNoticeBoardDto.Doc != null ? "files/notice/" + uniqueFileName : NoticeBoard.NoticeDocument.Replace("https://localhost:44395/Content/", String.Empty);
          //Demand.DemandLetterNo = request.UpdateDemandDto.Doc != null ? "files/demand/" + uniqueFileNameDemandLetter : Demand.DemandLetterNo.Replace("https://localhost:44395/Content/", String.Empty);
          await _unitOfWork.Repository<NoticeBoard>().Update(NoticeBoard);
          await _unitOfWork.Save();

          return Unit.Value;
    }
    }
}
