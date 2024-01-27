using MediatR;
using SchoolManagement.Application.DTOs.ArchivingforPublication;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ArchivingforPublications.Requests.Commands
{
    public class UpdateArchivingforPublicationCommand : IRequest<Unit>
    {
        public CreateArchivingforPublicationDto UpdateArchivingforPublicationDto { get; set; }
    }
}
