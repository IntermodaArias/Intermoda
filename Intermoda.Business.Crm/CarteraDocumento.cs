using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Intermoda.Common.Enum;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class CarteraDocumento
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CarteraDocumentoTipoId { get; set; }

        [DataMember]
        public int ClienteId { get; set; }

        [DataMember]
        public int? PaqueteId { get; set; }

        [DataMember]
        public int? PedidoTipoId { get; set; }

        [DataMember]
        public int MonedaId { get; set; }

        [DataMember]
        public int? CaiId { get; set; }

        [DataMember]
        public string Numero { get; set; }

        [DataMember]
        public DateTime FechaEmision { get; set; }

        [DataMember]
        public DateTime FechaVencimiento { get; set; }

        [DataMember]
        public DateTime? FechaDespacho { get; set; }

        [DataMember]
        public decimal SubTotal { get; set; }

        [DataMember]
        public decimal Flete { get; set; }

        [DataMember]
        public decimal OtrosCargos { get; set; }

        [DataMember]
        public decimal Iva { get; set; }

        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        public decimal Saldo { get; set; }

        [DataMember]
        public bool Sincronizado { get; set; }

        [DataMember]
        public virtual CarteraDocumentoTipo CarteraDocumentoTipo { get; set; }
        
        [DataMember]
        public virtual Cliente Cliente { get; set; }

        [DataMember]
        public virtual Moneda Moneda { get; set; }

        [DataMember]
        public virtual Cai Cai { get; set; }

        [DataMember]
        public virtual Paquete Paquete { get; set; }

        [DataMember]
        public virtual PedidoTipo PedidoTipo { get; set; }

        public virtual ICollection<CarteraDocumentoDetalleProducto> CarteraDocumentoDetalleProductoSet { get; set; }

        public virtual ICollection<CarteraDocumentoDetallePago> CarteraDocumentoDetallePagoSet { get; set; }

        public virtual ICollection<CarteraDocumentoDetalleAplicacion> CarteraDocumentoDetallePagoDebitoSet { get; set; }

        public virtual ICollection<CarteraDocumentoDetalleAplicacion> CarteraDocumentoDetallePagoCreditoSet { get; set; }

        [DataMember]
        public virtual DebitoCredito Tipo => CarteraDocumentoTipo.Tipo;

        [DataMember]
        public virtual decimal TotalDebito => Tipo == DebitoCredito.Debito ? Total : 0;

        [DataMember]
        public virtual decimal TotalCredito => Tipo == DebitoCredito.Credito ? Total : 0;

        [DataMember]
        public virtual decimal SaldoDebito => Tipo == DebitoCredito.Debito ? Saldo : 0;

        [DataMember]
        public virtual decimal SaldoCredito => Tipo == DebitoCredito.Credito ? Saldo : 0;
    }
}