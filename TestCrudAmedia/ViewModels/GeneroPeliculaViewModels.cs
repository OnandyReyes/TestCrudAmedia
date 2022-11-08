using TestCrudAmedia.Models;

namespace TestCrudAmedia.ViewModels
{
    public class GeneroPeliculaViewModels
    {
        public GeneroPeliculaViewModels()
        {

        }

        public int cod_pelicula { get; set; }
        public int cod_genero { get; set; }
        
        public TPelicula pelicula { get; set; }
        public IEnumerable<TGenero> listGeneros { get; set; }
    }
}
