using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Interface
{
    public interface IUsersRepository
    {
        #region Métodos Síncronos

        TUser Validate(string user, string password);
        
        #endregion

        #region Métodos Asíncronos

        Task<TUser> ValidateAsync(string user, string password);

        #endregion
    }
}
