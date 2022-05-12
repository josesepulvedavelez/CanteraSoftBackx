using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CanteraSoftBack.Contracts;
using CanteraSoftBack.Dto;
using CanteraSoftBack.Models;
using Microsoft.Extensions.Configuration;

namespace CanteraSoftBack.Data
{
    public class VehiculoDat : IVehiculo
    {
        private readonly string _cadena;
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        int result;

        #region Querys
        string querySeleccionarTodos = "SELECT VehiculoId, Placa, Mt3, Cliente.ClienteId, Cliente.Nombre, Vehiculo.Estado, Vehiculo.Observaciones, Vehiculo.FechaLog, Vehiculo.UsuarioLog " +
                                       "FROM Cliente INNER JOIN Vehiculo ON Cliente.ClienteId = Vehiculo.ClienteId";
        #endregion

        public VehiculoDat(IConfiguration configuration)
        {
            _cadena = configuration.GetConnectionString("CadenaConexion");
        }

        public Task<int> Actualizar(VehiculoModel element)
        {
            throw new NotImplementedException();
        }

        public Task<int> Guardar(VehiculoModel element)
        {
            throw new NotImplementedException();
        }

        public Task<VehiculoModel> SeleccionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<VehiculoDto>> SeleccionarTodos()
        {
            List<VehiculoDto> lst = new List<VehiculoDto>();

            using (conexion = new SqlConnection(_cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand(querySeleccionarTodos, conexion))
                {
                    lector = await comando.ExecuteReaderAsync();

                    while (await lector.ReadAsync())
                    {
                        VehiculoDto vehiculoDto = new VehiculoDto
                        {
                            VehiculoId = Convert.ToInt16(lector["VehiculoId"]),
                            Placa = Convert.ToString(lector["Placa"]),
                            Mt3 = Convert.ToDouble(lector["Mt3"]),
                            ClienteId = Convert.ToInt16(lector["ClienteId"]),
                            Nombre = Convert.ToString(lector["Nombre"]),

                            Estado = Convert.ToInt16(lector["Estado"]),
                            Observaciones = Convert.ToString(lector["Observaciones"]),
                            FechaLog = Convert.ToDateTime(lector["FechaLog"]),
                            UsuarioLog = Convert.ToString(lector["UsuarioLog"])
                        };

                        lst.Add(vehiculoDto);
                    }
                }
            }

            return lst;
        }

        Task<IEnumerable> IData<VehiculoModel>.SeleccionarTodos()
        {
            throw new NotImplementedException();
        }

    }
}
