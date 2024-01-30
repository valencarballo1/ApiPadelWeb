using System;
using System.Collections.Generic;

namespace ApiWeb.Models;

public partial class Horario
{
    public int Id { get; set; }

    public DateTime? HorarioDesde { get; set; }

    public DateTime? HorarioHasta { get; set; }

    public int? Duracion { get; set; }

    //public virtual ICollection<CanchasReservada> CanchasReservada { get; set; } = new List<CanchasReservada>();
}
