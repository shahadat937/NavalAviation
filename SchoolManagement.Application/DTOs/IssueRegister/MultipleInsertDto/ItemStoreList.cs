using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.IssueRegister.MultipleInsertDto
{
    public class ItemStoreList 
    { 
        public string? Deno { get; set; }
        public string? ItemDetail { get; set; }
        public string? PartNo { get; set; }
        public string? ItemSerNo { get; set; }
        public int? IssueStatusId { get; set; }
        public int? IssuedQty { get; set; }
        public int? IssueQty { get; set; }
        public int? Status { get; set; }
        public int? ItemDetailId { get; set; }
        public int? ItemStorId { get; set; }
        public int? DepartmentNameId { get; set; }
        public int? SparesCategoryId { get; set; }
        public bool IsRefundable { get; set; }
        public int? TotalReceivedQty { get; set; }
    }
}
