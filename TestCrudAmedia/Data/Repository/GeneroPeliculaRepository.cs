using Microsoft.EntityFrameworkCore;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Repository
{
    public class GeneroPeliculaRepository : IGeneroPeliculaRepository
    {
        private readonly TestCrudContext context;

        public GeneroPeliculaRepository(TestCrudContext context)
        {
            this.context = context;
        }

        public bool GeneroPeliculaCheck(int code_pelicula, int code_genero)
        {
            var result = context.TGeneros
                                .FromSqlInterpolated($"EXEC GeneroPeliculaCheck @cod_pelicula={code_pelicula}, @cod_genero={code_genero}")
                                .AsEnumerable();

            bool status = false;

            if (result.Count() > 0)
                status = true;

            return status;
        }

        public IEnumerable<TGenero> GetAllByCodePelicula(int code_pelicula)
        {
            var result = context.TGeneros
                                 .FromSqlInterpolated($"EXEC GeneroListByCodePelicula @cod_pelicula={code_pelicula}")
                                 .AsEnumerable();

            return result;
        }

        public bool Insert(int code_pelicula, int code_genero)
        {
            var result = context.Database
                .ExecuteSqlInterpolated($@"EXEC GeneroPeliculaInsert
                                        @cod_pelicula={code_pelicula},
                                        @cod_genero={code_genero}");

            bool status = false;

            if (result > 0)
                status = true;


            return status;
        }
    }
}
