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
    public class Factoria
    {
        [Key]
        public int FactoriaId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; } 
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuario { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresas Empresas { get; set; }
        public Factoria()
        {
            FactoriaId = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Fecha = DateTime.Now;
            UsuarioId = 0;
            EmpresaId = 0;
        }
        public Factoria(int factoriaId, string nombre, string direccion, string telefono, DateTime fecha, int usuarioId, int empresaId)
        {
            FactoriaId = factoriaId;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            Fecha = fecha;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }
    }
}
