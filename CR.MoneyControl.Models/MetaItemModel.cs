using System;

namespace CR.MoneyControl.Models;

public class MetaItemModel
{
    public int id_meta { get; set; }
    public string nombre { get; set; } = string.Empty;
    public float monto { get; set; }
    public decimal porcentaje_avance { get; set; }
    public string url_image { get; set; } = string.Empty;
}
