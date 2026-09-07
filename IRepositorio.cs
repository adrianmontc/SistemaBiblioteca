using System.Collections.Generic;

public interface IRepositorio<T>
{
    void Agregar(T elemento);
    List<T> Listar();
    void Eliminar(T elemento);
}