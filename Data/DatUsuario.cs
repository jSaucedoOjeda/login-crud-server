using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace login_crud_server
{

    public class DatUsuario
    {
        public Usuario prueba()
        {
            Usuario a = new Usuario();
            a.username = "Yisus";
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

                using (var conexion = new SqlConnection("Server=tcp:proyect25.database.windows.net,1433;Initial Catalog=Crud;Persist Security Info=False;User ID=administrador;Password=Hola123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    conexion.Open();
                    conexion.Execute("ALTA_USUARIO", lista_parametros, commandType: System.Data.CommandType.StoredProcedure);
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

        public List<Usuario> consulta()
        {
            List<Usuario> lista = null;
            try
            {
                using (var conexion = new SqlConnection("Server=tcp:proyect25.database.windows.net,1433;Initial Catalog=Crud;Persist Security Info=False;User ID=administrador;Password=Hola123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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
                using (var conexion = new SqlConnection("Server=tcp:proyect25.database.windows.net,1433;Initial Catalog=Crud;Persist Security Info=False;User ID=administrador;Password=Hola123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
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
                using (var conexion = new SqlConnection("Server=tcp:proyect25.database.windows.net,1433;Initial Catalog=Crud;Persist Security Info=False;User ID=administrador;Password=Hola123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    conexion.Open();
                    conexion.Execute("BAJA_USUARIO" ,lista_parametros, commandType: System.Data.CommandType.StoredProcedure);
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

        public Usuario login(string username)
        {
            Usuario resultado = null;
            try
            {
                var lista_parametros = new DynamicParameters();
                lista_parametros.Add("@username", username);
                using (var conexion = new SqlConnection("Server=tcp:proyect25.database.windows.net,1433;Initial Catalog=Crud;Persist Security Info=False;User ID=administrador;Password=Hola123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    conexion.Open();
                    resultado = conexion.QuerySingle<Usuario>("LOGIN",lista_parametros,  commandType: System.Data.CommandType.StoredProcedure);
                    

                }

            }
            catch (System.Exception ex )
            {
                resultado = null;
                throw ex;
            }
            return resultado ;
        }

    }

}