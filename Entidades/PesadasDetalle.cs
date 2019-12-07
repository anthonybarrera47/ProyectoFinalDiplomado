using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class PesadasDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int PesadasId { get; set; }
        public int TipoArrozId { get; set; }
        [NotMapped]
        public string Descripcion { get; set; }
        public decimal Kilos { get; set; }
        public decimal CantidadDeSacos { get; set; } 
        [ForeignKey("TipoArrozId")]
        public virtual TipoArroz TipoArroz { get; set; }
        [ForeignKey("PesadasId")]
        public virtual Pesadas Pesadas { get; set; }
        public PesadasDetalle()
        {
            DetalleId = 0;
            PesadasId = 0;
            TipoArrozId = 0;
            Descripcion = string.Empty;
            Kilos = 0;
            CantidadDeSacos = 0; 
        } 
        public PesadasDetalle(int pesadaDetalleID, int pesadasID, int tipoArrozID,string descripcion, decimal kilos, decimal cantidadDeSacos )
        {
            DetalleId = pesadaDetalleID;
            PesadasId = pesadasID;
            TipoArrozId = tipoArrozID;
            Descripcion = descripcion;
            Kilos = kilos;
            CantidadDeSacos = cantidadDeSacos; 
        }
    }
}
