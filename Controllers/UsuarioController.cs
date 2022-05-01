using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace login_crud_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController()
        {


        }

        [HttpGet("prueba")]
        public IActionResult Prueba()
        {
            var a = new DatUsuario().prueba();
            return Ok(a);
        }

        [HttpPost("Alta")]

        public IActionResult Alta([FromBody] Usuario user)
        {
            try
            {
                var resultado = new DatUsuario().AltaUsuario(user);
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }


        }

        [HttpGet("consulta")]
        public IActionResult consulta()
        {

            try
            {
                var resultado = new DatUsuario().consulta();
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("actualiza")]

        public IActionResult actualiza(int id, [FromBody] Usuario user)
        {

            try
            {
                var resultado = new DatUsuario().ActualizaUser(id, user);
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        [HttpDelete("eliminar")]

        public IActionResult eliminar(int id)
        {

            try
            {
                var resultado = new DatUsuario().eliminar(id);
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost("login")]

        public IActionResult login([FromBody] Usuario user)
        {
            bool resultado = false;
            try
            {

                var usuario = new DatUsuario().login(user.username);
                if (usuario != null)
                {
                    if (usuario.password == user.password)
                    {
                        resultado = true;
                    }
                }
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

        }

    }
}
