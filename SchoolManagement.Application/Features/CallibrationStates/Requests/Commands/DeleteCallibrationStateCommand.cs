using MediatR;

namespace SchoolManagement.Application.Features.CallibrationStates.Requests.Commands
{
    public class DeleteCallibrationStateCommand : IRequest
    {
        public int CallibrationStateId { get; set; }
    }
} 
