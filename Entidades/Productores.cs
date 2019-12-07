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
    public class Productores
    {
        [Key]
        public int ProductorId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuario { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresas Empresas { get; set; }

        public Productores()
        {
            ProductorId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            FechaNacimiento = DateTime.Now;
            Fecha = DateTime.Now;
            Cedula = string.Empty;
            UsuarioId = 0;
            EmpresaId = 0;
        }
        public Productores(int productorId, string nombre, string telefono, string cedula, DateTime fechaNacimiento, DateTime fecha, int usuarioId, int empresaId)
        {
            ProductorId = productorId;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            Cedula = cedula ?? throw new ArgumentNullException(nameof(cedula));
            FechaNacimiento = fechaNacimiento;
            Fecha = fecha;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
        }
    }
}
