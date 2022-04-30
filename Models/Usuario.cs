using System;

namespace login_crud_server{

    public class Usuario{
        public int id { get; set; }
        public string  username { get; set; }
        
        public string password { get; set; }
        public string  direccion { get; set; }
        public string telefono { get; set; }

        public string  codigo_postal { get; set; }
        public string  tipo_de_usuario { get; set; }

        public string   estado { get; set; }
        public string   ciudad  { get; set; }

        public DateTime create_date  { get; set; }
        public DateTime update_date { get; set; }

    } 

}