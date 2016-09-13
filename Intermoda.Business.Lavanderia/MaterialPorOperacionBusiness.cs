using System.Runtime.Serialization;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class MaterialPorOperacionBusiness
    {
        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int MaterialId { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public int OperacionId { get; set; }

        [DataMember]
        public int OperacionProcesoId { get; set; }

        [DataMember]
        public string ClaseId { get; set; }

        [DataMember]
        public string ClaseNombre { get; set; }

        [DataMember]
        public string SubClaseId { get; set; }

        [DataMember]
        public string SubClaseNombre { get; set; }

        [DataMember]
        public decimal Porcentaje { get; set; }

        [DataMember]
        public int IngredienteOrden { get; set; }

        [DataMember]
        public int IngredienteInstruccionesOperacionId { get; set; }

        [DataMember]
        public int InstruccionTemperatura { get; set; }

        [DataMember]
        public decimal InstruccionTiempoMinimo { get; set; }

        [DataMember]
        public decimal InstruccionTiempoMaximo { get; set; }

        #endregion
    }
}