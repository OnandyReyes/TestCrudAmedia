using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Interface
{
    public interface IPeliculaRepository
    {

        #region Métodos Síncronos
        int Insert(TPelicula pelicula);

        bool Update(TPelicula pelicula);

        bool Delete(int id);

        TPelicula GetById(int id);

        IEnumerable<TPelicula> GetAll();

        #endregion
    }
}
