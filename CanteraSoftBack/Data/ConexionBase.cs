using System;
using Microsoft.Extensions.Configuration;

namespace CanteraSoftBack.Data
{
    public class ConexionBase
    {
        private static string _cadena;

        public ConexionBase(IConfiguration configuration)
        {
            _cadena = configuration.GetConnectionString("CadenaConexion");
        }

        public static string Conectar()
        {
            return _cadena;
        }
    }
}
