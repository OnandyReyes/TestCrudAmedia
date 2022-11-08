using TestCrudAmedia.Models;

namespace TestCrudAmedia.ViewModels
{
    public class GeneroViewModels
    {
        public GeneroViewModels()
        {

        }

        public string descripcion { get; set; }

        public IEnumerable<TGenero> listGeneros { get; set; }
    }
}
