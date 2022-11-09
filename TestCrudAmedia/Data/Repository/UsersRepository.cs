using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TestCrudContext context;

        public UsersRepository(TestCrudContext context)
        {
            this.context = context;
        }

        #region Métodos Síncronos

        public int Insert(TUser user)
        {
            var parametroId = new SqlParameter("@cod_usuario", System.Data.SqlDbType.Int);
            parametroId.Direction = System.Data.ParameterDirection.Output;

            context.Database
                .ExecuteSqlInterpolated($@"EXEC UsersInsert
                                        @cod_usuario={parametroId} OUTPUT,
                                        @txt_user={user.TxtUser},
                                        @txt_password={user.TxtPassword},
                                        @txt_nombre={user.TxtNombre},
                                        @txt_apellido={user.TxtApellido},
                                        @nro_doc={user.NroDoc},
                                        @cod_rol={user.CodRol},
                                        @sn_activo={user.SnActivo}");

            var id = (int)parametroId.Value;
            return id;
        }

        public bool Update(TUser user)
        {
            var result = context.Database
                .ExecuteSqlInterpolated($@"EXEC UsersUpdate
                                        @cod_usuario={user.CodUsuario},
                                        @txt_user={user.TxtUser},
                                        @txt_password={user.TxtPassword},
                                        @txt_nombre={user.TxtNombre},
                                        @txt_apellido={user.TxtApellido},
                                        @nro_doc={user.NroDoc},
                                        @cod_rol={user.CodRol},
                                        @sn_activo={user.SnActivo}");

            bool status = false;

            if (result > 0)
                status = true;

            return status;
        }

        public bool Delete(int id)
        {
            var result = context.Database
                .ExecuteSqlInterpolated($@"EXEC UsersDelete
                                        @cod_usuario={id}");

            bool status = false;

            if (result > 0)
                status = true;


            return status;
        }

        public bool ValidateNroDoc(string nro_doc)
        {
            bool status = false;

            var userResult = context.TUsers
                                 .FromSqlInterpolated($"EXEC UsersValidateDoc @nro_doc={nro_doc}")
                                 .AsEnumerable();

            if (userResult.Count() > 0)
            {
                status = true;
            }

            return status;
        }

        public bool ValidateNroDocUpdate(string nro_doc, int cod_usuario)
        {
            bool status = false;

            var userResult = context.TUsers
                                 .FromSqlInterpolated($"EXEC UsersValidateDocUpdate @nro_doc={nro_doc}, @cod_usuario={cod_usuario} ")
                                 .AsEnumerable();

            if (userResult.Count() > 0)
            {
                status = true;
            }

            return status;
        }

        public TUser Validate(string user, string password)
        {
            TUser tuser = new TUser();

            var userResult = context.TUsers
                                 .FromSqlInterpolated($"EXEC UsersValidate @txt_user={user}, @txt_password={password}")
                                 .AsEnumerable();

            if (userResult.Count() > 0)
            {
                tuser = userResult.FirstOrDefault();
            }

            return tuser;
        }

        public TUser GetById(int id)
        {
            
            TUser tuser = context.TUsers.FirstOrDefault(x => x.CodUsuario == id);

            return tuser;
        }

        public IEnumerable<TUser> GetAll()
        {
            var userResult = context.TUsers
                                 .FromSqlInterpolated($"EXEC UsersList ")
                                 .AsEnumerable();

            return userResult;
        }

        #endregion

        #region Métodos Asíncronos
        public async Task<TUser> ValidateAsync(string user, string password)
        {
            TUser tuser = new TUser();

            var userResult = context.TUsers
                                 .FromSqlInterpolated($"EXEC UsersValidate @txt_user={user}, @txt_password={password}")
                                 .AsAsyncEnumerable();

            await foreach (var userResultObject in userResult)
            {
                return userResultObject;
            }

            return tuser;
        }

        #endregion
    }
}
