//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intermoda.Produccion.Lavanderia
{
    using System;
    using System.Collections.Generic;
    
    public partial class IngredientesOperacion
    {
        public int IngredienteOperacionId { get; set; }
        public int IngredienteId { get; set; }
        public int OperacionId { get; set; }
        public int OperacionProcesoId { get; set; }
        public Nullable<decimal> IngredienteOperacionPorcentaje { get; set; }
        public string IngredienteOperacionClaseId { get; set; }
        public string IngredienteOperacionSubClaseId { get; set; }
        public Nullable<int> IngredienteOperacionOrden { get; set; }
        public Nullable<int> IngredienteInstruccionesOperacionId { get; set; }
    
        public virtual InstruccionesOperacion InstruccionesOperacion { get; set; }
        public virtual OperacionesProceso OperacionesProceso { get; set; }
    }
}