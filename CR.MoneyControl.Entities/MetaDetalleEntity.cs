using System;

namespace CR.MoneyControl.Entities;

public class MetaDetalleEntity
{
    public int id_meta { get; set; }
    public int id_deposito { get; set; }
    public float monto_depositado { get; set; }
    public float procentaje_avance { get; set; }
    public float monto_pendiente { get; set; }
    public DateTime fecha { get; set; }
    public bool activo { get; set; }
}
