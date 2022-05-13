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
                                       "FROM Cliente INNER JOIN Vehiculo ON Cliente.ClienteId = Vehiculo.ClienteId " +
                                       "WHERE Cliente.Estado <> 2 AND Vehiculo.Estado <> 2";

        string queryGuardar = "INSERT INTO Vehiculo(Placa, Mt3, ClienteId, Estado, Observaciones, UsuarioLog) " +
                              "VALUES(@Placa, @Mt3, @ClienteId, @Estado, @Observaciones, @UsuarioLog)";

        string querySeleccionarPorId = "SELECT VehiculoId, Placa, Mt3, Cliente.ClienteId, Cliente.Nombre, Vehiculo.Estado, Vehiculo.Observaciones, Vehiculo.FechaLog, Vehiculo.UsuarioLog " +
                                       "FROM Cliente INNER JOIN Vehiculo ON Cliente.ClienteId = Vehiculo.ClienteId " +
                                       "AND VehiculoId = @VehiculoId";

        string QueryActualizar = "UPDATE Vehiculo SET Placa=@Placa, Mt3=@Mt3, ClienteId=@ClienteId, Estado=@Estado, Observaciones=@Observaciones " +
                                 "WHERE VehiculoId=@VehiculoId";
        #endregion

        public VehiculoDat(IConfiguration configuration)
        {
            _cadena = configuration.GetConnectionString("CadenaConexion");
        }

        public async Task<int> Actualizar(VehiculoModel element)
        {
            using (conexion = new SqlConnection(_cadena))
            {
                using (comando = new SqlCommand(QueryActualizar ,conexion))
                {
                    comando.Parameters.AddWithValue("@Placa", element.Placa);
                    comando.Parameters.AddWithValue("@Mt3", element.Mt3) ;
                    comando.Parameters.AddWithValue("@ClienteId", element.ClienteId);
                    comando.Parameters.AddWithValue("@Estado", element.Estado);
                    comando.Parameters.AddWithValue("@Observaciones", element.Observaciones);
                    comando.Parameters.AddWithValue("@VehiculoId", element.VehiculoId);

                    await conexion.OpenAsync();
                    result = await comando.ExecuteNonQueryAsync();
                    await conexion.CloseAsync();
                }
            }

            return result;
        }

        public async Task<int> Guardar(VehiculoModel element)
        {
            using (conexion = new SqlConnection(_cadena))
            {
                using (comando = new SqlCommand(queryGuardar, conexion))
                {
                    comando.Parameters.AddWithValue("@Placa", element.Placa);
                    comando.Parameters.AddWithValue("@Mt3", element.Mt3);
                    comando.Parameters.AddWithValue("@ClienteId", element.ClienteId);
                    comando.Parameters.AddWithValue("@Estado", element.Estado);
                    comando.Parameters.AddWithValue("@Observaciones", element.Observaciones);
                    comando.Parameters.AddWithValue("@UsuarioLog", element.UsuarioLog);

                    await conexion.OpenAsync();
                    result = await comando.ExecuteNonQueryAsync();
                    await conexion.CloseAsync();
                }
            }

            return result;
        }

        public async Task<VehiculoDto> SeleccionarPorId(int id)
        {
            VehiculoDto vehiculoDto = new VehiculoDto();

            using (conexion = new SqlConnection(_cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand(querySeleccionarPorId, conexion))
                {
                    comando.Parameters.AddWithValue("@VehiculoId", id);
                    lector = await comando.ExecuteReaderAsync();

                    while (await lector.ReadAsync())
                    {
                        vehiculoDto.VehiculoId = Convert.ToInt16(lector["VehiculoId"]);
                        vehiculoDto.Placa = Convert.ToString(lector["Placa"]);
                        vehiculoDto.Mt3 = Convert.ToDouble(lector["Mt3"]);
                        vehiculoDto.ClienteId = Convert.ToInt16(lector["ClienteId"]);
                        vehiculoDto.Nombre = Convert.ToString(lector["Nombre"]);

                        vehiculoDto.Estado = Convert.ToInt16(lector["Estado"]);
                        vehiculoDto.Observaciones = Convert.ToString(lector["Observaciones"]);
                        vehiculoDto.FechaLog = Convert.ToDateTime(lector["FechaLog"]);
                        vehiculoDto.UsuarioLog = Convert.ToString(lector["UsuarioLog"]);
                    }
                }
            }

            return vehiculoDto;
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

        Task<VehiculoModel> IData<VehiculoModel>.SeleccionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable> IData<VehiculoModel>.SeleccionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
