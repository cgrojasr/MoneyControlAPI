using System;
using System.Data.SqlClient;
using CR.MoneyControl.Entities;
using CR.MoneyControl.Models;
using CR.MoneyControl.Repositories;
using Dapper;

namespace CR.MoneyControl.DataAccess;

public class MetaDA : CRUDRepository<MetaEntity>, MetaRepository
{
    private readonly SqlConnection conn;
    public MetaDA(string? sqlConnection)
    {
        conn = new SqlConnection(sqlConnection);
    }

    public MetaEntity BuscarPorId(int id_obj)
    {
        try
        {
            using(conn){
                var query = $"SELECT * "+
                            $"FROM Meta WHERE id_meta = {id_obj}";

                return conn.Query<MetaEntity>(query).Single();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Eliminar(int id_obj)
    {
        try
        {
            using(conn){
                var query = $"DELETE "+
                            $"FROM Meta WHERE id_meta = {id_obj}";

                conn.Query(query);
                return true;
            }
        }
        catch(SqlException) {
            return false;
        }
        catch (Exception) {
            throw;
        }
    }

    public IEnumerable<MetaItemModel> ListarPorUsuario(string id_usuario)
    {
        try
        {
            using(conn){
                var query = $"SELECT MET.id_meta, MET.nombre, MET.monto, DET.porcentaje_avance, MET.url_image "+
                            $"FROM meta MET "+
                            $"LEFT JOIN meta_detalle DET ON MET.id_meta = DET.id_meta AND DET.activo = 1 "+
                            $"WHERE MET.id_usuario = '{id_usuario}'";

                return conn.Query<MetaItemModel>(query);
            }
        }
        catch (Exception) {
            throw;
        }
    }

    public bool Modificar(MetaEntity obj)
    {
        try
        {
            using(conn){
                var query = $"UPDATE Meta SET "+
                            $"nombre = '{obj.nombre}', "+
                            $"monto = {obj.monto}, "+
                            $"fecha_inicio = '{obj.fecha_inicio}', "+
                            $"fecha_final = '{obj.fecha_final}', "+
                            $"url_image = '{obj.url_image}' "+
                            $"FROM Meta "+
                            $"WHERE id_meta = {obj.id_meta}";
                conn.Execute(query);

                return true;
            }
        }
        catch(SqlException) {
            return false;
        }
        catch (Exception) {
            throw;
        }
    }

    public int Registrar(MetaEntity obj)
    {
        try
        {
            using(conn){
                var query = $"INSERT Meta VALUES ( "+
                            $"'{obj.nombre}', "+
                            $"'{obj.id_usuario}', "+
                            $"{obj.monto}, "+
                            $"'{obj.fecha_inicio}', "+
                            $"'{obj.fecha_final}', "+
                            $"'{obj.url_image}') "+
                            $"SELECT SCOPE_IDENTITY()";

                return conn.Query<int>(query).Single();
            }
        }
        catch (Exception) {
            throw;
        }
    }
}
