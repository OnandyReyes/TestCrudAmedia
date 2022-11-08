using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Interface
{
    public interface IRolRepository
    {
        #region Métodos Síncronos

        TRol GetById(int id);

        IEnumerable<TRol> GetAll();

        #endregion

        #region Métodos Asíncronos

        Task<TRol> GetByIdAsync(int id);

        #endregion
    }
}
