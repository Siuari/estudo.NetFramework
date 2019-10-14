using AutoMapper;
using CrudImport.DataBase_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudImport.ViewModels.Mappings
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Cliente, ClienteViewModel>();

            CreateMap<Telefone, TelefoneViewModel>();
        }
    }
}