using Microsoft.EntityFrameworkCore;
using System.Collections;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public TUser Validate(string user, string password)
        {
            TUser tuser = new TUser();

            using (TestCrudContext db = new TestCrudContext())
            {
                var userResult = db.TUsers
                                 .FromSqlInterpolated($"EXEC UsersValidate @txt_user={user}, @txt_password={password}")
                                 .AsEnumerable();

                if (userResult.Count() > 0)
                {
                    tuser = userResult.FirstOrDefault();
                }

            }
               
            return tuser;
        }

        public async Task<TUser> ValidateAsync(string user, string password)
        {
            TUser tuser = new TUser();

            using (TestCrudContext db = new TestCrudContext())
            {
                var userResult = db.TUsers
                                 .FromSqlInterpolated($"EXEC UsersValidate @txt_user={user}, @txt_password={password}")
                                 .AsAsyncEnumerable();

                await foreach (var userResultObject in userResult)
                {
                    return userResultObject;
                }

            }

            return tuser;
        }
    }
}
