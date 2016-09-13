using System.ComponentModel;

namespace Intermoda.Common.Enum
{
    public enum CentroTrabajoClasificacionTipo
    {
        [Description("Entrenamiento")]
        Entrenamiento = 1,
        [Description("Titular")]
        Titular = 2,
        [Description("Comodín")]
        Utilitario = 3
    }
}