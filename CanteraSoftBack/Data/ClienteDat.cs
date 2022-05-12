using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CanteraSoftBack.Contracts;
using CanteraSoftBack.Models;
using Microsoft.Extensions.Configuration;

namespace CanteraSoftBack.Data
{
    public class ClienteDat : ICliente
    {
        private readonly string _cadena;
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        int result;

        #region querys
        string querySeleccionarTodos = "SELECT * FROM Cliente WHERE Estado <> 2";
        string querySeleccionarPorId = "SELECT * FROM Cliente WHERE ClienteId=@ClienteId";
        string queryGuardar = "INSERT INTO Cliente(Nombre, NitCc, Contacto, Telefono, Celular, Correo, Estado, Observaciones, UsuarioLog) " +
                                "VALUES(@Nombre, @NitCc, @Contacto, @Telefono, @Celular, @Correo, @Estado, @Observaciones, @UsuarioLog)";
        string queryActualizar = "UPDATE Cliente SET Nombre=@Nombre, NitCc=@NitCc, Contacto=@Contacto, Telefono=@Telefono, Celular=@Celular, Correo=@Correo, Estado=@Estado, Observaciones=@Observaciones " +
                                    "WHERE ClienteId=@ClienteId";
        #endregion

        public ClienteDat(IConfiguration configuration)
        {
            _cadena = configuration.GetConnectionString("CadenaConexion");
        }

        public async Task<int> Actualizar(ClienteModel element)
        {
            using (conexion = new SqlConnection(_cadena))
            {
                using (comando = new SqlCommand(queryActualizar, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", element.Nombre);
                    comando.Parameters.AddWithValue("@NitCc", element.NitCc);
                    comando.Parameters.AddWithValue("@Contacto", element.Contacto);
                    comando.Parameters.AddWithValue("@Telefono", element.Telefono);
                    comando.Parameters.AddWithValue("@Celular", element.Celular);
                    comando.Parameters.AddWithValue("@Correo", element.Correo);
                    comando.Parameters.AddWithValue("@Estado", element.Estado);
                    comando.Parameters.AddWithValue("@Observaciones", element.Observaciones);
                    comando.Parameters.AddWithValue("@ClienteId", element.ClienteId);

                    await conexion.OpenAsync();
                    result = await comando.ExecuteNonQueryAsync();
                    await conexion.CloseAsync();
                }
            }

            return result;
        }

        public async Task<int> Guardar(ClienteModel element)
        {
            using (conexion = new SqlConnection(_cadena))
            {
                using (comando = new SqlCommand(queryGuardar, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", element.Nombre);
                    comando.Parameters.AddWithValue("@NitCc", element.NitCc);
                    comando.Parameters.AddWithValue("@Contacto", element.Contacto);
                    comando.Parameters.AddWithValue("@Telefono", element.Telefono);
                    comando.Parameters.AddWithValue("@Celular", element.Celular);
                    comando.Parameters.AddWithValue("@Correo", element.Correo);
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

        public async Task<ClienteModel> SeleccionarPorId(int id)
        {
            ClienteModel clienteModel = new ClienteModel();

            using (conexion = new SqlConnection(_cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand(querySeleccionarPorId, conexion))
                {
                    comando.Parameters.AddWithValue("@ClienteId", id);
                    lector = await comando.ExecuteReaderAsync();

                    while (await lector.ReadAsync())
                    {
                        clienteModel.ClienteId = Convert.ToInt16(lector["ClienteId"]);
                        clienteModel.Nombre = Convert.ToString(lector["Nombre"]);
                        clienteModel.NitCc = Convert.ToString(lector["NitCc"]);
                        clienteModel.Contacto = Convert.ToString(lector["Contacto"]);
                        clienteModel.Telefono = Convert.ToString(lector["Telefono"]);
                        clienteModel.Celular = Convert.ToString(lector["Celular"]);
                        clienteModel.Correo = Convert.ToString(lector["Correo"]);

                        clienteModel.Estado = Convert.ToInt16(lector["Estado"]);
                        clienteModel.Observaciones = Convert.ToString(lector["Observaciones"]);
                        clienteModel.FechaLog = Convert.ToDateTime(lector["FechaLog"]);
                        clienteModel.UsuarioLog = Convert.ToString(lector["UsuarioLog"]);
                    }
                }
            }

            return clienteModel;
        }

        public async Task<IEnumerable> SeleccionarTodos()
        {
            List<ClienteModel> lst = new List<ClienteModel>();

            using (conexion = new SqlConnection(_cadena))
            {
                await conexion.OpenAsync();

                using (comando = new SqlCommand(querySeleccionarTodos, conexion))
                {
                    lector = comando.ExecuteReader();

                    while (await lector.ReadAsync())
                    { 
                        ClienteModel clienteModel = new ClienteModel
                        {
                            ClienteId = Convert.ToInt16(lector["ClienteId"]),
                            Nombre = Convert.ToString(lector["Nombre"]),
                            NitCc = Convert.ToString(lector["NitCc"]),
                            Contacto = Convert.ToString(lector["Contacto"]),
                            Telefono = Convert.ToString(lector["Telefono"]),
                            Celular = Convert.ToString(lector["Celular"]),
                            Correo = Convert.ToString(lector["Correo"]),

                            Estado = Convert.ToInt16(lector["Estado"]),
                            Observaciones = Convert.ToString(lector["Observaciones"]),
                            FechaLog = Convert.ToDateTime(lector["FechaLog"]),
                            UsuarioLog = Convert.ToString(lector["UsuarioLog"])
                        };

                        lst.Add(clienteModel);
                    }
                }
            }

            return lst;
        }

    }
}
