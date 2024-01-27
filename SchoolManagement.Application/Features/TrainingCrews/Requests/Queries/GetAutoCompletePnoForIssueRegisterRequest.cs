using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetAutoCompletePnoForIssueRegisterRequest : IRequest<List<SelectedModel>>
    {
        public string Pno { get; set; }
    }
}
 