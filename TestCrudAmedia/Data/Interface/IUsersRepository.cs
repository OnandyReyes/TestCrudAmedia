using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Interface
{
    public interface IUsersRepository
    {
        #region Métodos Síncronos

        TUser Validate(string user, string password);

        #region Métodos Asíncronos

        Task<TUser> ValidateAsync(string user, string password);
    }
}
