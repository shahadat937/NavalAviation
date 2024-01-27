using MediatR;
using SchoolManagement.Application.DTOs.NameofPublication;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NameofPublications.Requests.Commands
{
    public class UpdateNameofPublicationCommand : IRequest<Unit>
    {
        public NameofPublicationDto NameofPublicationDto { get; set; }
    }
}
