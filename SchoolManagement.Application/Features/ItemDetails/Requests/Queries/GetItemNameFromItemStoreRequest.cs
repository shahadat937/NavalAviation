using MediatR;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;
 
namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
    public class GetItemNameFromItemStoreRequest : IRequest<List<SelectedModel>>
    {
        //public int BaseSchoolNameId { get; set; } 
        //public int CourseNameId { get; set; }  
        //public DateTime Date { get; set; }
        //public int ClassPeriodId { get; set; } 
    }
}

 