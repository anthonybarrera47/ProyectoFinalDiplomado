using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioPesadas : RepositorioBase<Pesadas>
    {
        private static readonly Usuarios Usuario = new Usuarios();

        public override bool Guardar(Pesadas entity)
        {
            bool paso = false;
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            Contexto db = new Contexto();
            try
            {
                if (db.Pesadas.Add(entity) != null)
                {
                    foreach (var item in entity.Detalles)
                    {
                        var TipoArroz = repositorio.Buscar(item.TipoArrozId);
                        TipoArroz.Kilos += item.Kilos;
                        repositorio.Modificar(TipoArroz);
                    }
                    paso = (db.SaveChanges() > 0);
                }

            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();
                repositorio.Dispose();
            }
            return paso;
        }
        public override bool Modificar(Pesadas entity)
        {
            bool paso = false;
            var Anterior = Buscar(entity.PesadaId);
            Contexto db = new Contexto();
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            try
            {
                using (Contexto contexto = new Contexto())
                {
                    foreach (var item in Anterior.Detalles.ToList())
                    {
                        if (!entity.Detalles.Exists(d => d.DetalleId == item.DetalleId))
                        {
                            var TipoArroz = repositorio.Buscar(item.TipoArrozId);
                            TipoArroz.Kilos -= item.Kilos;
                            repositorio.Modificar(TipoArroz);
                            contexto.Entry(item).State = EntityState.Deleted;
                        }
                    }
                    contexto.SaveChanges();
                }
                foreach (var item in entity.Detalles.ToList())
                {
                    var estado = System.Data.Entity.EntityState.Unchanged;
                    if (item.DetalleId == 0)
                    {
                        var TipoArroz = repositorio.Buscar(item.TipoArrozId);
                        TipoArroz.Kilos += item.Kilos;
                        repositorio.Modificar(TipoArroz);
                        estado = EntityState.Added;
                    }
                    db.Entry(item).State = estado;
                }
                db.Entry(entity).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;

        }
        public override bool Eliminar(int Id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            try
            {
                var entity = Buscar(Id);
                if (entity != null)
                {
                    foreach (var item in entity.Detalles)
                    {
                        var TipoArroz = repositorio.Buscar(item.TipoArrozId);
                        TipoArroz.Kilos -= item.Kilos;
                        repositorio.Modificar(TipoArroz);
                    }
                    entity.Detalles.RemoveAll(x => true);
                    db.Entry(entity).State = EntityState.Deleted;
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return paso;
        }
        public override Pesadas Buscar(int Id)
        {
            Pesadas pesadas = new Pesadas();
            Contexto db = new Contexto();
            RepositorioBase<TipoArroz> repositorio = new RepositorioBase<TipoArroz>();
            RepositorioBase<Productores> repositorioProductor = new RepositorioBase<Productores>();
            RepositorioBase<Factoria> repositorioFactoria = new RepositorioBase<Factoria>();
            try
            {
                pesadas = db.Pesadas.Include(x => x.Detalles).Where(x => x.PesadaId == Id).FirstOrDefault();
                
                if (pesadas != null)
                {
                    pesadas.NombreFactoria = repositorioFactoria.Buscar(pesadas.FactoriaId).Nombre;
                    pesadas.NombreProductor = repositorioProductor.Buscar(pesadas.ProductorId).Nombre;
                    pesadas.Detalles.ForEach(x => x.Descripcion = repositorio.Buscar(x.TipoArrozId).Descripcion);
                }
                    
            }
            catch (Exception)
            { throw; }
            finally
            {
                db.Dispose();
                repositorio.Dispose();
            }
            return pesadas;
        }
        public override List<Pesadas> GetList(Expression<Func<Pesadas, bool>> pesadas)
        {
            List<Pesadas> Pesada = new List<Pesadas>();
            List<Pesadas> PesadaParaCargarDetalle = new List<Pesadas>();
            Contexto db = new Contexto();
            try
            {
                Pesada = db.Pesadas.Include(x => x.Detalles).Where(pesadas).ToList();
                if (Pesada.Count > 0)
                {
                    
                    foreach (var item in Pesada)
                    {
                        PesadaParaCargarDetalle.Add(Buscar(item.PesadaId));
                    }
                }


            }
            catch (Exception)
            { throw; }
            finally
            { db.Dispose(); }
            return PesadaParaCargarDetalle;
        }
    }
}
