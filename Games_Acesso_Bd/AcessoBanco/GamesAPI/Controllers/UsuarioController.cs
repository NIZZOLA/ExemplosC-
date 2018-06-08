using AcessoBanco.Model;
using AcessoBanco.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GamesAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        public IHttpActionResult Get(int id)
        {
            UsuarioRepository rep = new UsuarioRepository();
            var rsp = rep.Consultar(id);

            ///var jsonString = JsonConvert.SerializeObject(rsp);
            //return jsonString;
            return Ok(rsp);
        }

        // POST: api/Usuario
        public IHttpActionResult Post([FromBody] Usuario usu )
        {
            UsuarioRepository rep = new UsuarioRepository();
            // consulta se o usuário existe
            var rsp = rep.ConsultarPorEmail(usu.Email);
            if (rsp.UsuarioId != 0)
                return Content(HttpStatusCode.BadRequest, "usuário já existe !");

            var gravado = rep.Incluir(usu);
            if( gravado != null )
                return Ok(gravado);

            return Content(HttpStatusCode.BadRequest, "Erro na gravação");

        }

        // PUT: api/Usuario/5
        //public IHttpActionResult Put(int id, [FromBody] Usuario usu )
        public IHttpActionResult Put( [FromBody] Usuario usu)
        {
            UsuarioRepository rep = new UsuarioRepository();
            if (usu.IsValid())
            {
                var rsp = rep.Incluir(usu);
                return Ok(rsp);
            }
            return Ok();
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
