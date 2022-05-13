using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CanteraSoftBack.Dto;
using CanteraSoftBack.Models;

namespace CanteraSoftBack.Contracts
{
    public interface IVehiculo : IData<VehiculoModel>
    {
        new Task<List<VehiculoDto>> SeleccionarTodos();
        new Task<VehiculoDto> SeleccionarPorId(int id);
    }
}
