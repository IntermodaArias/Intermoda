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
        public int? DireccionFacturacionId { get; set; }

        [DataMember]
        public int? DireccionEntregaId { get; set; }

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
        public bool SincronizadoProxy { get; set; }

        [DataMember]
        public DateTime SincronizadoProxyDate { get; set; }

        [DataMember]
        public bool SincronizadoCentral { get; set; }
        
        [DataMember]
        public DateTime SincronizadoCentralDate { get; set; }

        [DataMember]
        public int? BancoId { get; set; }

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

        [DataMember]
        public virtual ClienteDireccion DireccionFacturacion { get; set; }

        [DataMember]
        public virtual ClienteDireccion DireccionEntrega { get; set; }

        public virtual ICollection<CarteraDocumentoDetalleProducto> CarteraDocumentoDetalleProductoSet { get; set; }

        public virtual ICollection<CarteraDocumentoDetallePago> CarteraDocumentoDetallePagoSet { get; set; }

        public virtual ICollection<CarteraDocumentoDetalleAplicacion> CarteraDocumentoDetallePagoDebitoSet { get; set; }

        public virtual ICollection<CarteraDocumentoDetalleAplicacion> CarteraDocumentoDetallePagoCreditoSet { get; set; }

        [DataMember]
        public virtual DebitoCredito TipoCxC => CarteraDocumentoTipo.TipoCxC;

        [DataMember]
        public virtual DebitoCredito TipoCaja => CarteraDocumentoTipo.TipoCaja;

        [DataMember]
        public virtual DebitoCredito TipoInventario => CarteraDocumentoTipo.TipoInventario;

        [DataMember]
        public virtual Banco Banco { get; set; }

        //[DataMember]
        //public virtual decimal CxCTotalDebito => TipoCxC == DebitoCredito.Debito ? Total : 0;

        //[DataMember]
        //public virtual decimal CxCTotalCredito => TipoCxC == DebitoCredito.Credito ? Total : 0;

        //[DataMember]
        //public virtual decimal CxCSaldoDebito => TipoCxC == DebitoCredito.Debito ? Saldo : 0;

        //[DataMember]
        //public virtual decimal CxCSaldoCredito => TipoCxC == DebitoCredito.Credito ? Saldo : 0;
    }
}