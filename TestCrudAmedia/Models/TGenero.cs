using System;
using System.Collections.Generic;

namespace TestCrudAmedia.Models;

public partial class TGenero
{
    public int CodGenero { get; set; }

    public string? TxtDesc { get; set; }

    public virtual ICollection<TPelicula> CodPeliculas { get; } = new List<TPelicula>();
}
