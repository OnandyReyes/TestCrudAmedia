using System;
using System.Collections.Generic;

namespace TestCrudAmedia.Models;

public partial class TPeliculaAlquiladum
{
    public int CodPeliculaAlquilada { get; set; }

    public int? CodPelicula { get; set; }

    public int? CodUsuarioCliente { get; set; }

    public int? CodUsuarioCreador { get; set; }

    public decimal? Precio { get; set; }

    public DateTime? FechaTomada { get; set; }

    public DateTime? FechaDevuelta { get; set; }

    public int? Devuelta { get; set; }

    public int? Cantidad { get; set; }

    public virtual TPelicula? CodPeliculaNavigation { get; set; }

    public virtual TUser? CodUsuarioClienteNavigation { get; set; }

    public virtual TUser? CodUsuarioCreadorNavigation { get; set; }
}
