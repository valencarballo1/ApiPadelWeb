using System;
using System.Collections.Generic;

namespace ApiWeb.Models;

public partial class Cancha
{
    public int Id { get; set; }

    public int? NumeroCancha { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<CanchasReservada> CanchasReservada { get; set; } = new List<CanchasReservada>();
}
