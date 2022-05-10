using System;
namespace CanteraSoftBack.Models
{
    public class ClienteModel
    {
        public ClienteModel()
        {
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string NitCc { get; set; }
        public string Contacto { get; set; }
        public string? Telefono { get; set; }
        public string Celular { get; set; }
        public string? Correo { get; set; }
        public int Estado { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaLog { get; set; }
        public string? UsuarioLog { get; set; }
    }
}
