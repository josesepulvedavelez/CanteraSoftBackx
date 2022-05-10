using System;
using System.Collections;
using System.Threading.Tasks;

namespace CanteraSoftBack.Contracts
{
    public interface IData<T> where T : class
    {
        Task<IEnumerable> SeleccionarTodos();
        Task<T> SeleccionarPorId(int id);
        Task<int> Guardar(T element);
        Task<int> Actualizar(T element);
    }
}
