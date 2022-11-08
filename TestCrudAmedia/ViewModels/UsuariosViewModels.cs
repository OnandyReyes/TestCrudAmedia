using System.Collections;
using TestCrudAmedia.Models;

namespace TestCrudAmedia.ViewModels
{
    public class UsuariosViewModels
    {
        public UsuariosViewModels()
        {

        }

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
