using System;
using System.Runtime.Serialization;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class PasoRutaBusiness 
    {
        #region Properties

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public string Planta { get; set; }

        [DataMember]
        public short Ano { get; set; }

        [DataMember]
        public short Numero { get; set; }

        [DataMember]
        public string CentroTrabajoId { get; set; }

        [DataMember]
        public string CentroTrabajo { get; set; }

        [DataMember]
        public string PlantaId { get; set; }

        [DataMember]
        public short Secuencia { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public DateTime? LecturaEntrada { get; set; }

        [DataMember]
        public DateTime? LecturaSalida { get; set; }

        [DataMember]
        public TimeSpan? TiempoEnProceso { get; set; }

        [DataMember]
        public TimeSpan? TiempoEnPlanta { get; set; }

        #endregion

        #region Methods



        #endregion
    }
}