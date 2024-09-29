using System;

namespace CR.MoneyControl.Repositories;

public interface CRUDRepository<T> where T : class
{
    int Registrar(T obj);
    bool Modificar(T obj);
    bool Eliminar(int id_obj);
    T BuscarPorId(int id_obj);
}
