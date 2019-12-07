using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioSolicitudes : RepositorioBase<SolicitudUsuarios>
    {
        public override SolicitudUsuarios Buscar(int id)
        {
            SolicitudUsuarios solicitud = new SolicitudUsuarios();
            Contexto db = new Contexto();
            RepositorioUsuarios repositorio = new RepositorioUsuarios();
            try
            {
                solicitud = db.SolicitudUsuarios.Where(x => x.SolicitudId == id).FirstOrDefault();

                if (solicitud != null)
                {
                    solicitud.NombreUsuario = repositorio.Buscar(solicitud.UsuarioId).UserName;
                }

            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();
                repositorio.Dispose();
            }
            return solicitud;
        }
        public override List<SolicitudUsuarios> GetList(Expression<Func<SolicitudUsuarios, bool>> expression)
        {
            List<SolicitudUsuarios> Lista = new List<SolicitudUsuarios>();
            List<SolicitudUsuarios> ListaRetornar = new List<SolicitudUsuarios>();
            RepositorioUsuarios repositorio = new RepositorioUsuarios();
            Contexto db = new Contexto();
            try
            {
                Lista = db.SolicitudUsuarios.Where(expression).ToList();
                if (Lista.Count > 0)
                {

                    foreach (var item in Lista)
                    {
                        ListaRetornar.Add(Buscar(item.SolicitudId));
                    }
                }


            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); repositorio.Dispose(); }
            return ListaRetornar;
        }
    }
}
