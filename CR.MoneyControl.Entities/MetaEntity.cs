using System;

namespace CR.MoneyControl.Entities;

public class MetaEntity
{
    public int id_meta { get; set; }
    public string nombre { get; set; } = string.Empty;
    public string id_usuario { get; set; } = string.Empty;
    public float monto { get; set; }
    public DateTime fecha_inicio { get; set; }
    public DateTime fecha_final { get; set; }
    public string url_image { get; set; } = string.Empty;
}
