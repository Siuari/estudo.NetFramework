using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudImport.ViewModels
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public ICollection<TelefoneViewModel> Telefones { get; set; }
    }
}