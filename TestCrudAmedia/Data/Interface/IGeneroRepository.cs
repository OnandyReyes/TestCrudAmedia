using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Interface
{
    public interface IGeneroRepository
    {
        #region Métodos Síncronos
        int Insert(TGenero genero);

        #endregion
    }
}
