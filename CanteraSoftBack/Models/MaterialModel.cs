using System;
namespace CanteraSoftBack.Models
{
    public class MaterialModel
    {
        public MaterialModel()
        {
        }

        public int MaterialId { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Medida { get; set; }
        public int? Estado { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaLog { get; set; }
        public string UsuarioLog { get; set; }
    }
}
