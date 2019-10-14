using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudImport.ViewModels.Mappings
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(pd =>
            {
                pd.AddProfile(new DomainToViewModelMapping());
            });
        }
    }
}