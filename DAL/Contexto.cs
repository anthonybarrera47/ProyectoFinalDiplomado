using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Factoria> Factorias { get; set; }

        public DbSet<Productores> Productores { get; set; }
        public DbSet<Pesadas> Pesadas { get; set; }
        public DbSet<TipoArroz> TiposArroz { get; set; }
        public DbSet<Usuarios> Usuario { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<SolicitudUsuarios> SolicitudUsuarios { get; set; }
        public Contexto() : base("ConStr")
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pesadas>().HasRequired(c => c.Usuario).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<TipoArroz>().HasRequired(c => c.Usuario).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Factoria>().HasRequired(c => c.Usuario).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Productores>().HasRequired(c => c.Usuario).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudUsuarios>().HasRequired(c => c.Usuario).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Empresas>().HasRequired(c => c.Usuario).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<Pesadas>().HasRequired(c => c.Empresas).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<TipoArroz>().HasRequired(c => c.Empresas).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Factoria>().HasRequired(c => c.Empresas).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Productores>().HasRequired(c => c.Empresas).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<SolicitudUsuarios>().HasRequired(c => c.Empresas).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
