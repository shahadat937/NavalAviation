using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.ItemStor;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class ItemStoreFileUrlResolver : IValueResolver<ItemStor, ItemStorDto,  string>
    {
        private readonly IConfiguration _config;
        public ItemStoreFileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ItemStor source, ItemStorDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.OtherDoc))
            {

                return _config["ApiUrl"] + source.OtherDoc;
            }


            return null;
        }


    }
}
