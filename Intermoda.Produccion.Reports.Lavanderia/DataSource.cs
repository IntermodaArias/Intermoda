using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Intermoda.Produccion.Reports.Lavanderia
{
    [DataObject]
    public class DataSource
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public async Task<OpcionLavado> GetOpcionLavado(int opcionLavadoId)
        {
            try
            {
                var opcionLavado = await Client.Lavanderia.OpcionLavado.Get(opcionLavadoId);
                var resultado = new OpcionLavado
                {
                    OpcionLavadoId = opcionLavado.Id,
                    OpcionLavadoNombre = opcionLavado.Nombre,
                    OpcionLavadoDescripcion = opcionLavado.Descripcion,
                    LavadoId = opcionLavado.Lavado.LavadoId,
                    LavodoNombre = opcionLavado.Lavado.LavadoNombre,
                    LavadoDescripcion = opcionLavado.Lavado.LavadoDescripcion,
                    ColorId = opcionLavado.Lavado.ColorIntermoda.Id,
                    ColorNombre = opcionLavado.Lavado.ColorIntermoda.Nombre,
                    TelaCodigo = opcionLavado.Tela.TelaCodigo,
                    TelaNombre = opcionLavado.Tela.TelaNombre,
                    TelaComposicion = opcionLavado.Tela.ComposicionNombre,
                    IsDefault = opcionLavado.IsDefault == 1,
                };
                return resultado;
            }
            catch (Exception exception)
            {
                throw new Exception("DataSource / GetOpcionLavado", exception);
            }
        }
    }
}