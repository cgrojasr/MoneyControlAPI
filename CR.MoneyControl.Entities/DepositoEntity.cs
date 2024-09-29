using System;

namespace CR.MoneyControl.Entities;

public class DepositoEntity
{
    public int id_deposito { get; set; }
    public string id_usuario { get; set; } = string.Empty;
    public DateTime fecha { get; set; }
    public float monto { get; set; }
}
