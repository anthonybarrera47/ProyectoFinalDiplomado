using Enums;
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
    public class Usuarios
    {

        [Key]
        public int UsuarioId { get; set; }
        public string UserName { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Direccion { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        [NotMapped]
        public string NombreTipoUsuario { get; set; }
        public bool EsPropietarioEmpresa { get; set; }
        public int Empresa { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Usuarios()
        {
            UsuarioId = 0;
            UserName = string.Empty;
            Correo = string.Empty;
            Direccion = string.Empty;
            Nombre = string.Empty;
            Password = string.Empty;
            TipoUsuario = TipoUsuario.UsuarioNormal;
            EsPropietarioEmpresa = false;
            Empresa = 0;
            NombreTipoUsuario = string.Empty;
            Fecha = DateTime.Now;
            FechaNacimiento = DateTime.Now;
        }
        public Usuarios(int usuarioId, string userName, string correo, string nombre, string password, string direccion, TipoUsuario tipoUsuario, bool esPropietarioEmpresa, int empresa, DateTime fecha,DateTime fechaNacimiento)
        {
            UsuarioId = usuarioId;
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Correo = correo ?? throw new ArgumentNullException(nameof(correo));
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            TipoUsuario = tipoUsuario;
            EsPropietarioEmpresa = esPropietarioEmpresa;
            Empresa = empresa;
            Fecha = fecha;
            FechaNacimiento = fechaNacimiento;
        }
    }
}
