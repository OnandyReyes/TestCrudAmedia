using System;
using System.Collections.Generic;

namespace TestCrudAmedia.Models;

public partial class TRol
{
    public int CodRol { get; set; }

    public string? TxtDesc { get; set; }

    public int? SnActivo { get; set; }

    public virtual ICollection<TUser> TUsers { get; } = new List<TUser>();
}
