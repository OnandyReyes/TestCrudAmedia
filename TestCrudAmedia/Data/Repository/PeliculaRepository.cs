using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TestCrudAmedia.Data.Interface;
using TestCrudAmedia.Models;

namespace TestCrudAmedia.Data.Repository
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private readonly TestCrudContext context;

        public PeliculaRepository(TestCrudContext context)
        {
            this.context = context;
        }

        public int Insert(TPelicula pelicula)
        {
            var parametroId = new SqlParameter("@cod_genero", System.Data.SqlDbType.Int);
            parametroId.Direction = System.Data.ParameterDirection.Output;

            context.Database
                .ExecuteSqlInterpolated($@"EXEC PeliculaInsert
                                        @cod_pelicula={parametroId} OUTPUT,
                                        @txt_desc={pelicula.TxtDesc},
                                        @cant_disponibles_alquiler={pelicula.CantDisponiblesAlquiler},
                                        @cant_disponibles_venta={pelicula.CantDisponiblesVenta},
                                        @precio_alquiler={pelicula.PrecioAlquiler},
                                        @precio_venta={pelicula.PrecioVenta}");

            var id = (int)parametroId.Value;
            return id;
        }

        public bool Update(TPelicula pelicula)
        {
            var result = context.Database
                .ExecuteSqlInterpolated($@"EXEC PeliculaUpdate
                                        @cod_pelicula={pelicula.CodPelicula},
                                        @txt_desc={pelicula.TxtDesc},
                                        @cant_disponibles_alquiler={pelicula.CantDisponiblesAlquiler},
                                        @cant_disponibles_venta={pelicula.CantDisponiblesVenta},
                                        @precio_alquiler={pelicula.PrecioAlquiler},
                                        @precio_venta={pelicula.PrecioVenta}");

            bool status = false;

            if (result > 0)
                status = true;


            return status;
        }

        public bool Delete(int id)
        {
            var result = context.Database
                .ExecuteSqlInterpolated($@"EXEC GeneroInsert
                                        @cod_pelicula={id}");

            bool status = false;

            if (result > 0)
                status = true;


            return status;
        }

        public TPelicula GetById(int id)
        {
            TPelicula pelicula = new TPelicula();

            var result = context.TPeliculas
                                 .FromSqlInterpolated($"EXEC PeliculaGetByID @@cod_pelicula={id}")
                                 .AsEnumerable();

            if (result.Count() > 0)
            {
                pelicula = result.FirstOrDefault();
            }

            return pelicula;
        }

        public IEnumerable<TPelicula> GetAll()
        {
            var result = context.TPeliculas
                                 .FromSqlInterpolated($"EXEC PeliculaList ")
                                 .AsEnumerable();

            return result;
        }
        
    }
}
