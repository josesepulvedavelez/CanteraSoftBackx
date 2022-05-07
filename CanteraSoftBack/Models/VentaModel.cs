using System;
namespace CanteraSoftBack.Models
{
    public class VentaModel
    {
        public VentaModel()
        {
        }

        public int VentaId { get; set; }
        public double? Cantidad { get; set; }
        public double? Precio { get; set; }
        public double? Subtotal { get; set; }
        public int? ContratoId { get; set; }
        public int? MaterialId { get; set; }
        public int? Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaLog { get; set; }
        public string UsuarioLog { get; set; }
    }
}
