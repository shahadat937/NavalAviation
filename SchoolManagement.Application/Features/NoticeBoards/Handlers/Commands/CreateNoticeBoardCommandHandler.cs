using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.NoticeBoards.Validators;
using SchoolManagement.Application.Features.NoticeBoards.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.NoticeBoards.Handlers.Commands
{
    public class CreateNoticeBoardCommandHandler : IRequestHandler<CreateNoticeBoardCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateNoticeBoardCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateNoticeBoardCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateNoticeBoardDtoValidator();
            var validationResult = await validator.ValidateAsync(request.NoticeBoardDto);

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

            if (request.NoticeBoardDto.Doc != null)
            {

              var fileName = Path.GetFileName(request.NoticeBoardDto.Doc.FileName);
              uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
              var a = Directory.GetCurrentDirectory();
              var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Content\\files\\notice", uniqueFileName);
              using (var fileSteam = new FileStream(filePath, FileMode.Create))
              {
                await request.NoticeBoardDto.Doc.CopyToAsync(fileSteam);
              }
            }

              var NoticeBoard = _mapper.Map<NoticeBoard>(request.NoticeBoardDto);

              NoticeBoard.Date = NoticeBoard.Date.Value.AddDays(1.0);

              // var Procurement = _mapper.Map<Procurement>(request.ProcurementDto);
              NoticeBoard.NoticeDocument = request.NoticeBoardDto.NoticeDocument ?? "files/notice/" + uniqueFileName;
              //NoticeBoard.NoticeDocument = request.NoticeBoardDto.NoticeDocument ??uniqueFileName;

              NoticeBoard = await _unitOfWork.Repository<NoticeBoard>().Add(NoticeBoard);

                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex);
                }


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = NoticeBoard.NoticeBoardId;
            }

            return response;
        }
    }
}
