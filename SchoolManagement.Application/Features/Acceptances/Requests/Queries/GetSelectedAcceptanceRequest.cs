using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Acceptances.Requests.Queries
{
    public class GetSelectedAcceptanceRequest : IRequest<List<SelectedModel>>
    {
    }
} 
