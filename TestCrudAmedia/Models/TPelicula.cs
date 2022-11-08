using System;
using System.Collections.Generic;

namespace TestCrudAmedia.Models;

public partial class TPelicula
{
    public int CodPelicula { get; set; }

    public string? TxtDesc { get; set; }

    public int? CantDisponiblesAlquiler { get; set; }

    public int? CantDisponiblesVenta { get; set; }

    public decimal? PrecioAlquiler { get; set; }

    public decimal? PrecioVenta { get; set; }

    public virtual ICollection<TPeliculaAlquiladum> TPeliculaAlquilada { get; } = new List<TPeliculaAlquiladum>();

    public virtual ICollection<TPeliculaVendidum> TPeliculaVendida { get; } = new List<TPeliculaVendidum>();

    public virtual ICollection<TGenero> CodGeneros { get; } = new List<TGenero>();
}
