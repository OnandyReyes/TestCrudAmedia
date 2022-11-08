using Microsoft.EntityFrameworkCore;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Repository
{
    public class RolRepository : IRolRepository
    {

        private readonly TestCrudContext context;

        public RolRepository(TestCrudContext context)
        {
            this.context = context;
        }

        #region Métodos Síncronos

        public TRol GetById(int id)
        {
            TRol trol = new TRol();

            
            var rolResult = context.TRols
                                     .FromSqlInterpolated($"EXEC RolGetByID @cod_rol={id}")
                                     .AsEnumerable();

            if (rolResult.Count() > 0)
            {
                trol = rolResult.FirstOrDefault();
            }
            
            return trol;
        }

        public IEnumerable<TRol> GetAll()
        {

            var rolResult = context.TRols
                                 .FromSqlInterpolated($"EXEC RolList ")
                                 .AsEnumerable();

            return rolResult;
        }

        #endregion

        #region Métodos Asíncronos
        public async Task<TRol> GetByIdAsync(int id)
        {
            TRol trol = new TRol();

            var rolResult = context.TRols
                                 .FromSqlInterpolated($"EXEC RolGetByID @cod_rol={id}")
                                 .AsAsyncEnumerable();

            await foreach (var rolResultObject in rolResult)
            {
                return rolResultObject;
            }

            return trol;
        }


        #endregion
    }
}
