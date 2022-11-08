using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Repository
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly TestCrudContext context;

        public GeneroRepository(TestCrudContext context)
        {
            this.context = context;
        }

        

        public int Insert(TGenero genero)
        {
            var parametroId = new SqlParameter("@cod_genero", System.Data.SqlDbType.Int);
            parametroId.Direction = System.Data.ParameterDirection.Output;

            context.Database
                .ExecuteSqlInterpolated($@"EXEC GeneroInsert
                                        @cod_genero={parametroId} OUTPUT,
                                        @txt_desc={genero.TxtDesc}");

            var id = (int)parametroId.Value;
            return id;
        }

        public IEnumerable<TGenero> GetAll()
        {
            var result = context.TGeneros
                                 .FromSqlInterpolated($"EXEC GeneroList ")
                                 .AsEnumerable();

            return result;
        }
    }
}
