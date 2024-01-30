using System;
using System.Collections.Generic;

namespace ApiWeb.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public virtual ICollection<Perfil> Perfils { get; set; } = new List<Perfil>();
}
