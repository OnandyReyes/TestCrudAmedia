using Microsoft.EntityFrameworkCore;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Repository
{
    public class RolRepository : IRolRepository
    {
        public TRol GetById(int id)
        {
            TRol trol = new TRol();

            using (TestCrudContext db = new TestCrudContext())
            {
                var rolResult = db.TRols
                                 .FromSqlInterpolated($"EXEC RolGetByID @cod_rol={id}")
                                 .AsEnumerable();

                if (rolResult.Count() > 0)
                {
                    trol = rolResult.FirstOrDefault();
                }

            }

            return trol;
        }

        public async Task<TRol> GetByIdAsync(int id)
        {
            TRol trol = new TRol();

            using (TestCrudContext db = new TestCrudContext())
            {
                var rolResult = db.TRols
                                 .FromSqlInterpolated($"EXEC RolGetByID @cod_rol={id}")
                                 .AsAsyncEnumerable();

                await foreach (var rolResultObject in rolResult)
                {
                    return rolResultObject;
                }

            }

            return trol;
        }
    }
}
