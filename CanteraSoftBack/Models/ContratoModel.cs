using System;
namespace CanteraSoftBack.Models
{
    public class ContratoModel
    {
        public ContratoModel()
        {
        }

        public int ContratoId { get; set; }
        public DateTime? FechaCelebracion { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string Descripcion { get; set; }
        public double? SubTotal { get; set; }
        public double? Iva { get; set; }
        public double? TotalPagar { get; set; }
        public double? TotalPagos { get; set; }
        public double? Saldo { get; set; }
        public int? ClienteId { get; set; }
        public int? Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaLog { get; set; }
        public string UsuarioLog { get; set; }
    }
}
