using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Verify.V2.Service;
namespace login_crud_server
{

    public class DatUsuario
    {
        public Usuario prueba()
        {
            Usuario a = new Usuario();
            a.username = "Axel";
            return a;
        }
        public bool AltaUsuario(Usuario user)
        {

            bool resultado = false;
            try
            {
                var lista_parametros = new DynamicParameters();
                lista_parametros.Add("@username", user.username);
                lista_parametros.Add("@password", user.password);
                lista_parametros.Add("@direccion", user.direccion);
                lista_parametros.Add("@telefono", user.telefono);
                lista_parametros.Add("@codigo_postal", user.codigo_postal);
                lista_parametros.Add("@tipo_de_usuario", user.tipo_de_usuario);
                lista_parametros.Add("@estado", user.estado);
                lista_parametros.Add("@ciudad", user.ciudad);

                using (var conexion = new SqlConnection("Server=localhost;Database=CRUD;Trusted_Connection=True;"))
                {

                    conexion.Open();
                    conexion.Execute("ALTA_USUARIO", lista_parametros, commandType: System.Data.CommandType.StoredProcedure);
                    resultado = true;

                    string accountSid = (@"AC34066e5809028f4f23135dfaaacd6274");
                    string authToken = (@"885871c531de833629848bf99f16661a");
                    TwilioClient.Init(accountSid, authToken);
                    var message = $"Hola {user.username} te mando SMS para avisarte que te diste de alta en nuestra página de Nezter"; MessageResource.Create(

                            body: message,
                            from: new Twilio.Types.PhoneNumber("+19595005622"),
                            to: new Twilio.Types.PhoneNumber("+52" + user.telefono)
                        );
                }
            }
            catch (System.Exception ex)
            {
                resultado = false;
                throw ex;
            }
            return resultado;
        }

        public List<Usuario> consulta()
        {
            List<Usuario> lista = null;
            try
            {
                using (var conexion = new SqlConnection("Server=localhost;Database=CRUD;Trusted_Connection=True;"))
                {
                    conexion.Open();
                    lista = conexion.Query<Usuario>("CONSULTA_USUARIOS", commandType: System.Data.CommandType.StoredProcedure).ToList();

                }
            }
            catch (System.Exception ex)
            {
                lista = null;
                throw ex;
            }
            return lista;
        }


        public Usuario consulta(int id)
        {
            Usuario lista = null;
            try
            {
                var lista_parametros = new DynamicParameters();
                lista_parametros.Add("@id", id);
                using (var conexion = new SqlConnection("Server=localhost;Database=CRUD;Trusted_Connection=True;"))
                {
                    conexion.Open();
                    lista = conexion.QuerySingle<Usuario>("ConsultaUsuario", lista_parametros, commandType: System.Data.CommandType.StoredProcedure);

                }
            }
            catch (System.Exception ex)
            {
                lista = null;
                throw ex;
            }
            return lista;
        }



        public bool ActualizaUser(int id, Usuario user)
        {
            bool resultado = false;

            try
            {
                var lista_parametros = new DynamicParameters();
                lista_parametros.Add("@id", id);
                lista_parametros.Add("@username", user.username);
                lista_parametros.Add("@password", user.password);
                lista_parametros.Add("@direccion", user.direccion);
                lista_parametros.Add("@telefono", user.telefono);
                lista_parametros.Add("@codigo_postal", user.codigo_postal);
                lista_parametros.Add("@tipo_de_usuario", user.tipo_de_usuario);
                lista_parametros.Add("@estado", user.estado);
                lista_parametros.Add("@ciudad", user.ciudad);
                using (var conexion = new SqlConnection("Server=localhost;Database=CRUD;Trusted_Connection=True;"))
                {
                    conexion.Open();
                    conexion.Execute("CAMBIO_USUARIO", lista_parametros, commandType: System.Data.CommandType.StoredProcedure);
                    resultado = true;
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            return resultado;
        }
        public bool eliminar(int id)
        {
            bool resultado = false;
            try
            {
                var lista_parametros = new DynamicParameters();
                lista_parametros.Add("@id", id);
                using (var conexion = new SqlConnection("Server=localhost;Database=CRUD;Trusted_Connection=True;"))
                {
                    conexion.Open();
                    conexion.Execute("BAJA_USUARIO", lista_parametros, commandType: System.Data.CommandType.StoredProcedure);
                    resultado = true;

                }
            }
            catch (System.Exception ex)
            {
                resultado = false;
                throw ex;
            }
            return resultado;
        }

        public Usuario login(string username , string telefono)
        {
            Usuario resultado = null;
            try
            {
                var lista_parametros = new DynamicParameters();
                lista_parametros.Add("@username", username);
                using (var conexion = new SqlConnection("Server=localhost;Database=CRUD;Trusted_Connection=True;"))
                {
                    conexion.Open();
                    resultado = conexion.QuerySingle<Usuario>("LOGIN", lista_parametros, commandType: System.Data.CommandType.StoredProcedure);

                    string accountSid = ("AC34066e5809028f4f23135dfaaacd6274");
                    string authToken  = ("885871c531de833629848bf99f16661a");

                    TwilioClient.Init(accountSid, authToken);

                    var verification = VerificationResource.Create(
                        to: ("+52" + telefono),
                        channel: "sms",
                        pathServiceSid: "VA601dd2620006200bb8317a32c571e046"
                    );
                }
            }
            catch (System.Exception ex)
            {
                resultado = null;
                throw ex;
            }
            return resultado;
        }

    }

}