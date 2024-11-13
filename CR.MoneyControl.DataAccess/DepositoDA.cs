using System;
using System.Data.SqlClient;
using CR.MoneyControl.Entities;
using CR.MoneyControl.Repositories;

namespace CR.MoneyControl.DataAccess;

public class DepositoDA : CRUDRepository<DepositoEntity>
{
    private readonly SqlConnection conn;

    public DepositoDA(string? sqlConnection)
    {
        conn = new SqlConnection(sqlConnection);
    }

    public DepositoEntity BuscarPorId(int id_obj)
    {
        throw new NotImplementedException();
    }

    public bool Eliminar(int id_obj)
    {
        throw new NotImplementedException();
    }

    public bool Modificar(DepositoEntity obj)
    {
        throw new NotImplementedException();
    }

    public int Registrar(DepositoEntity obj)
    {
        throw new NotImplementedException();
    }
}
