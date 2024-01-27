using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Surveys.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Surveys.Handlers.Commands
{
    public class DeleteSurveyCommandHandler : IRequestHandler<DeleteSurveyCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSurveyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSurveyCommand request, CancellationToken cancellationToken)
        {
            var Survey = await _unitOfWork.Repository<Survey>().Get(request.SurveyId);

            if (Survey == null)
                throw new NotFoundException(nameof(Survey), request.SurveyId);

            await _unitOfWork.Repository<Survey>().Delete(Survey);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            //await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
