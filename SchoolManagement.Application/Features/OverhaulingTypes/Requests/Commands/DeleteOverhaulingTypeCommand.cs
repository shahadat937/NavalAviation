using MediatR;

namespace SchoolManagement.Application.Features.OverhaulingTypes.Requests.Commands
{
    public class DeleteOverhaulingTypeCommand : IRequest
    {
        public int OverhaulingTypeId { get; set; }
    }
}
