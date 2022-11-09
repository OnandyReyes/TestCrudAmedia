using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Interface
{
    public interface IUsersRepository
    {
        #region Métodos Síncronos
        int Insert(TUser user);

        bool Update(TUser user);

        bool Delete(int id);

        bool ValidateNroDoc(string nro_doc);

        bool ValidateNroDocUpdate(string nro_doc, int cod_usuario);

        TUser Validate(string user, string password);

        TUser GetById(int id);

        IEnumerable<TUser> GetAll();

        #endregion

        #region Métodos Asíncronos

        Task<TUser> ValidateAsync(string user, string password);


        #endregion
    }
}
