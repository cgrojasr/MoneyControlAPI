using System;
using System.Data.SqlClient;
using CR.MoneyControl.Models;
using Dapper;

namespace CR.MoneyControl.DataAccess;

public class MedioFinancieroDA
{
    private readonly SqlConnection conn;

    public MedioFinancieroDA(string? sqlConnection)
    {
        conn = new SqlConnection(sqlConnection);
    }

    public IEnumerable<MedioFinancieroItemModel> ListarPorUsuario(string id_usuario)
    {
        try
        {
            using(conn){
                var query = $"SELECT MED.id_medio_financiero, MED.nombre "+
                            $"FROM medio_financiero MED "+
                            $"WHERE MED.id_usuario = '{id_usuario}'"+
                            $"ORDER BY MED.orden";

                return conn.Query<MedioFinancieroItemModel>(query);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
