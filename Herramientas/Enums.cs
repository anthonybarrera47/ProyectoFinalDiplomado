using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    public enum TipoAlerta
    {
        SuccessAlert,
        ErrorAlert,
        ErrorAlertUser,
        ErrorAlertClave
    }
    public enum IconType
    {
        success,
        error,
        warning,
        info,
        question
    }
    public enum TiposMensajes
    {
        [Description("¡Registro Guardado!")]
        RegistroGuardado,
        [Description("¡No Se Guardo Su Registro")]
        RegistroNoGuardado,
        [Description("¡No Puede Modificar Un Registro Inexistente!")]
        RegistroInexistente,
        [Description("¡Registro Eliminado Correctamente!")]
        RegistroEliminado,
        [Description("¡Registro Modificado")]
        RegistroModificado,
        [Description("Usuario Existente")]
        UsuarioExistente,
        [Description("¡Registro No Encontrado!")]
        RegistroNoEncontrado,
        [Description("¡Revise los campos!")]
        RevisarCampos,
        [Description("¡Usuario o contraseña incorrecta!")]
        LoginIncorrecto,
        [Description("¡Las claves no coinciden!")]
        ClaveNoCoincide,
        [Description("Espere confirmacion del Administrador")]
        EsperarConfirmacion,
        [Description("Algo ha fallado, comuniquese con el administrador")]
        ComunicarseConAdmi,
        [Description("Solicitud en espera!")]
        SolicitudEspera,
        [Description("Solicitud denegada, No puede iniciar Sesion!")]
        SolicitudDenegada,
        [Description("Empresa No Existe, verifique el codigo")]
        EmpresaNoExiste,
        [Description("No tiene solicitudes!")]
        SinSolicitud,
        [Description("Estad solicitud ya fue denegada o aprobada!")]
        YaFueDenegadaOAprobada,
        [Description("Solicitud Aceptada, ya puede iniciar Sesion!")]
        SolicitudAceptada,
        [Description("Correo existente!")]
        CorreExistente
    }
    public enum TipoTitulo
    {
        [Description("¡Operacion Exitosa!")]
        OperacionExitosa,
        [Description("!Operacion Fallida!")]
        OperacionFallida,
        [Description("!Informacion!")]
        Informacion
    }
    public enum TipoUsuario
    {
        Administrador = 0,
        UsuarioNormal = 1
    }

}
