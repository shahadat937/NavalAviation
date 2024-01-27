using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.StockTransferNsd;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class StockTransferNsdFileUrlResolver : IValueResolver<StockTransferNsd, StockTransferNsdDto,  string>
    {
        private readonly IConfiguration _config;
        public StockTransferNsdFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(StockTransferNsd source, StockTransferNsdDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Doc))
            {

                return _config["ApiUrl"] + source.Doc;
            }


            return null;
        }


    }
}
