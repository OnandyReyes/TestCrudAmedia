using TestCrudAmedia.Models;

namespace TestCrudAmedia.ViewModels
{
    public class PeliculaViewModels
    {
        public PeliculaViewModels()
        {

        }

        public int cod_pelicula { get; set; }

        public string descripcion { get; set; }

        public int cantidad_disponible_alquiler { get; set; }

        public int cantidad_disponible_venta { get; set; }

        public decimal precio_alquiler { get; set; }

        public decimal precio_venta { get; set; }

        public TPelicula pelicula { get; set; }

        public IEnumerable<TPelicula> listPeliculas { get; set; }
    }
}
