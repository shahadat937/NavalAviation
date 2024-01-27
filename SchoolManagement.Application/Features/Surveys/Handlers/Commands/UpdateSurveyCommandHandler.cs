using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Survey.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Surveys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;

namespace SchoolManagement.Application.Features.Surveys.Handlers.Commands
{
    public class UpdateSurveyCommandHandler : IRequestHandler<UpdateSurveyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSurveyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSurveyDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.SurveyDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Survey = await _unitOfWork.Repository<Survey>().Get(request.SurveyDto.SurveyId);

            if (Survey is null)
                throw new NotFoundException(nameof(Survey), request.SurveyDto.SurveyId);

            _mapper.Map(request.SurveyDto, Survey);

            await _unitOfWork.Repository<Survey>().Update(Survey);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
