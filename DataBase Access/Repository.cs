using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudImport.DataBase_Access
{
    public class Repository
    {
        private NutelaContext _context;

        public Repository()
        {
            _context = new NutelaContext();
        }

        public void Adicionar(Cliente cliente)
        {
            _context.Set<Cliente>().Add(cliente);
            _context.SaveChanges();
        }

        public ICollection<Cliente> Listar(int? start = null, int? length = null)
        {
            var cliente = _context.Set<Cliente>().Include(x => x.Telefones);

            return (start != null && cliente.Any()) ? cliente.OrderBy(x => x.Id).Skip(start.Value).Take(length.Value).ToList() : cliente.ToList() ;
        }

        public void Atualizar(Cliente cliente)
        {
            var clienteAtualizar = _context.Set<Cliente>().Where(x => x.Id == cliente.Id).FirstOrDefault();

            clienteAtualizar.Nome = cliente.Nome;
            clienteAtualizar.Endereco = cliente.Endereco;

            _context.SaveChanges();
        }

        public void Adicionar(Telefone telefone)
        {
            _context.Set<Telefone>().Add(telefone);
            _context.SaveChanges();
        }

    }
}