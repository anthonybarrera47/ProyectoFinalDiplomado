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
    public class TipoArroz
    {
        [Key]
        public int TipoArrozId { get; set; }
        public string Descripcion { get; set; }
        public decimal Kilos { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; } 
        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuario { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresas Empresas { get; set; }
        public TipoArroz()
        {
            TipoArrozId = 0;
            Descripcion = string.Empty;
            Kilos = 0;
            UsuarioId = 0;
            Fecha = DateTime.Now;
            EmpresaId = 0;
        }
        public TipoArroz(int tipoArrozId, string descripcion, decimal kilos, DateTime fecha, int usuarioId, int empresaId)
        {
            TipoArrozId = tipoArrozId;
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            Kilos = kilos;
            Fecha = fecha;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }
    }
}
