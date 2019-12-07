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
    public class SolicitudUsuarios
    {
        [Key]
        public int SolicitudId { get; set; }
        [NotMapped]
        public string NombreUsuario { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoSolicitud Estado{ get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuario { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresas Empresas { get; set; }
        public SolicitudUsuarios()
        {
            SolicitudId = 0;
            NombreUsuario = string.Empty;
            Fecha = DateTime.Now;
            Estado = EstadoSolicitud.Pendiente;
            UsuarioId = 0;
            EmpresaId = 0;
        }
        public SolicitudUsuarios(int solicitudId, string nombreUsuario, DateTime fecha, EstadoSolicitud estado, int usuarioId, int empresaId)
        {
            SolicitudId = solicitudId;
            NombreUsuario = nombreUsuario ?? throw new ArgumentNullException(nameof(nombreUsuario));
            Fecha = fecha;
            Estado = estado;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }
    }
}
