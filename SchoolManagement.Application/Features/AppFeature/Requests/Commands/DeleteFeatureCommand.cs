using MediatR;

namespace SchoolManagement.Application.Features.AppFeature.Requests.Commands
{
    public class DeleteFeatureCommand : IRequest  
    {  
        public int Id { get; set; } 
    }
}
