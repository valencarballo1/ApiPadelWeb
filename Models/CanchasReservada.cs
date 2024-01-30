using System;
using System.Collections.Generic;

namespace ApiWeb.Models;

public partial class CanchasReservada
{
    public int Id { get; set; }

    public int? IdCancha { get; set; }

    public int? IdHorario { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Cancha? IdCanchaNavigation { get; set; }

    public virtual Horario? IdHorarioNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    //public virtual ICollection<PartidosCreadosUsuario> PartidosCreadosUsuarios { get; set; } = new List<PartidosCreadosUsuario>();
}
