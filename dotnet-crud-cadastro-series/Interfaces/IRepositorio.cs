using System.Collections.Generic;

namespace dotnet_crud_cadastro_series.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista(); //lista que aceita generico
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}
