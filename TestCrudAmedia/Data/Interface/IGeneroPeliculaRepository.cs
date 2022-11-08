using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Interface
{
    public interface IGeneroPeliculaRepository
    {
        IEnumerable<TGenero> GetAllByCodePelicula(int code_pelicula);

        bool GeneroPeliculaCheck(int code_pelicula, int code_genero);

        bool Insert(int code_pelicula, int code_genero);
    }
}
