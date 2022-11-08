using System;
using System.Collections.Generic;

namespace TestCrudAmedia.Models;

public partial class TUser
{
    public int CodUsuario { get; set; }

    public string? TxtUser { get; set; }

    public string? TxtPassword { get; set; }

    public string? TxtNombre { get; set; }

    public string? TxtApellido { get; set; }

    public string? NroDoc { get; set; }

    public int? CodRol { get; set; }

    public int? SnActivo { get; set; }

    public virtual TRol? CodRolNavigation { get; set; }

    public virtual ICollection<TPeliculaAlquiladum> TPeliculaAlquiladumCodUsuarioClienteNavigations { get; } = new List<TPeliculaAlquiladum>();

    public virtual ICollection<TPeliculaAlquiladum> TPeliculaAlquiladumCodUsuarioCreadorNavigations { get; } = new List<TPeliculaAlquiladum>();

    public virtual ICollection<TPeliculaVendidum> TPeliculaVendidumCodUsuarioClienteNavigations { get; } = new List<TPeliculaVendidum>();

    public virtual ICollection<TPeliculaVendidum> TPeliculaVendidumCodUsuarioCreadorNavigations { get; } = new List<TPeliculaVendidum>();
}
