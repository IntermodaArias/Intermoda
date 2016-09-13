using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int EmpresaId { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Direccion { get; set; }

        [DataMember]
        [StringLength(32, MinimumLength = 7)]
        public string Telefono { get; set; }

        [DataMember]
        public int InventarioDias { get; set; }

        [DataMember]
        public DateTime? InventarioUltimo { get; set; }

        [DataMember]
        public DateTime? InventarioProximo { get; set; }

        [DataMember]
        public int? GrupoEconomicoId { get; set; }

        [DataMember]
        public int PaisId { get; set; }

        [DataMember]
        public int CiudadId { get; set; }

        [DataMember]
        public int RutaId { get; set; }

        [DataMember]
        public int MonedaId { get; set; }

        [DataMember]
        public virtual Empresa Empresa { get; set; }

        [DataMember]
        public virtual GrupoEconomico GrupoEconomico { get; set; }

        [DataMember]
        public virtual Pais Pais { get; set; }

        [DataMember]
        public virtual Ciudad Ciudad { get; set; }

        [DataMember]
        public virtual Ruta Ruta { get; set; }

        [DataMember]
        public virtual Moneda Moneda { get; set; }

        public virtual ICollection<InventarioFisico> InventarioFisicoSet { get; set; } = 
            new HashSet<InventarioFisico>();

        public virtual ICollection<InventarioTraslado> InventarioTrasladoClienteOrigenSet { get; set; }

        public virtual ICollection<InventarioTraslado> InventarioTrasladoClienteDestinoSet { get; set; }

        public virtual ICollection<AcuerdoComercial> AcuerdoComercialSet { get; set; } = 
            new HashSet<AcuerdoComercial>();

        public virtual ICollection<CarteraDocumento> CarteraDocumentoSet { get; set; } = 
            new HashSet<CarteraDocumento>();
    }
}