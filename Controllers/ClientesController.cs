using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using CrudImport.DataBase_Access;
using CrudImport.ViewModels;
using CrudImport.ViewModels.Mappings;

namespace CrudImport.Controllers
{
    public class ClientesController : ApiController
    {
        private Repository _repository = new Repository();
        private IMapper _mapper = new Mapper(AutoMapperConfiguration.RegisterMappings());

        // GET: api/Clientes
        public ICollection<ClienteViewModel> GetClientes(int start, int length)
        {
            start = start * length;
            var clientes = _repository.Listar(start, length);
            return _mapper.Map<ICollection<ClienteViewModel>>(clientes);
        }

        // GET: api/Clientes/5
        //[ResponseType(typeof(Cliente))]
        //public IHttpActionResult GetCliente(int id)
        //{
        //    Cliente cliente = db.Clientes.Find(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    //}

        //    return Ok(cliente);
        //}

        // PUT: api/Clientes/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCliente(int id, Cliente cliente)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != cliente.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(cliente).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClienteExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Clientes
        [ResponseType(typeof(Cliente))]
        public IHttpActionResult PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Adicionar(cliente);

            return CreatedAtRoute("DefaultApi", new { id = cliente.Id }, cliente);
        }


        // DELETE: api/Clientes/5
        //[ResponseType(typeof(Cliente))]
        //public IHttpActionResult DeleteCliente(int id)
        //{
        //    Cliente cliente = db.Clientes.Find(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Clientes.Remove(cliente);
        //    db.SaveChanges();

        //    return Ok(cliente);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ClienteExists(int id)
        //{
        //    return db.Clientes.Count(e => e.Id == id) > 0;
        //}
    }
}