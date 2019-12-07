using Extensores;
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
    public class Pesadas
    {
        [Key]
        public int PesadaId { get; set; }
        public int ProductorId { get; set; }
        [NotMapped]
        public string NombreProductor { get; set; }
        public int FactoriaId { get; set; }
        [NotMapped]
        public string NombreFactoria { get; set; }
        public int UsuarioId { get; set; }
        public decimal Humedad { get; set; }
        public decimal PrecioFanega { get; set; }
        public decimal SubTotalKiloGramos { get; set; }
        public decimal TotalSacos { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal DescuentoXSacos { get; set; }
        public decimal TotalKiloGramos { get; set; }
        public decimal Fanega { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("ProductorId")]
        public virtual Productores Productor { get; set; }
        [ForeignKey("FactoriaId")]
        public virtual Factoria Factoria { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuarios Usuario { get; set; }
        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]
        public virtual Empresas Empresas { get; set; }
        public virtual List<PesadasDetalle> Detalles { get; set; }

        public Pesadas(int pesadaId, int productorId, int factoriaId, int usuarioId, decimal fanega, decimal precioFanega,
            decimal totalKiloGramos, decimal totalSacos, decimal totalPagar, DateTime fecha,int empresaId)
        {
            PesadaId = pesadaId;
            ProductorId = productorId;
            FactoriaId = factoriaId;
            UsuarioId = usuarioId;
            Humedad = fanega;
            PrecioFanega = precioFanega;
            TotalKiloGramos = totalKiloGramos;
            TotalSacos = totalSacos;
            TotalPagar = totalPagar;
            Fecha = fecha;
            EmpresaId = empresaId;
            Detalles = new List<PesadasDetalle>();
        }
        public Pesadas()
        {
            PesadaId = 0;
            ProductorId = 0;
            FactoriaId = 0;
            UsuarioId = 0;
            Fecha = DateTime.Now;
            Humedad = 0;
            PrecioFanega = 0;
            TotalKiloGramos = 0;
            TotalSacos = 0;
            TotalPagar = 0;
            EmpresaId = 0;
            Detalles = new List<PesadasDetalle>();
        }
        public void AgregarDetalle(int DetalleId, int PesadaId, int TipoArrozId, string Descripcion, decimal Kilos, decimal CantidadSacos)
        {
            if (!Detalles.EsNulo())
                Detalles.Add(new PesadasDetalle(DetalleId, PesadaId, TipoArrozId, Descripcion, Kilos, CantidadSacos));
        }
        public void AgregarDetalle(PesadasDetalle detalle)
        {
            if (!Detalles.EsNulo())
                Detalles.Add(detalle);
        }
        public void RemoverDetalle(int index)
        {
            if (!Detalles.EsNulo())
                Detalles.RemoveAt(index);
        }
    }
}
