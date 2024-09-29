using System;
using CR.MoneyControl.Models;

namespace CR.MoneyControl.Repositories;

public interface MetaRepository
{
    IEnumerable<MetaItemModel> ListarPorUsuario(string id_usuario);
}
