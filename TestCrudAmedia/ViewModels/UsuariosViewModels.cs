using System.Collections;
using TestCrudAmedia.Models;

namespace TestCrudAmedia.ViewModels
{
    public class UsuariosViewModels
    {
        public UsuariosViewModels()
        {

        }
        public int cod_usuario { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string password_old { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nro_doc { get; set; }

        public int cod_rol { get; set; }
           
        public TUser tuser { get; set; }

        public IEnumerable<TUser> listUsers { get; set; }

        public IEnumerable<TRol> listRoles { get; set; }

        public String getRolDescById(int id)
        {
            String desc = "";

            TRol rol = listRoles.FirstOrDefault(x => x.CodRol == id);

            if (rol != null && rol.TxtDesc.Length > 0)
            {
                desc = rol.TxtDesc;
            }

            return desc;
        }

        public String getEstado(int estado)
        {
            if (estado == 1)
            {
                return "ACTIVO";
            }
            else
            {
                return "INACTIVO";
            }
        }
    }
}
