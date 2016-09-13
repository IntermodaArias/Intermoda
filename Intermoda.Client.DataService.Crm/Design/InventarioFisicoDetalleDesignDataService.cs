using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class InventarioFisicoDetalleDesignDataService : IInventarioFisicoDetalleDataService
    {
        public void Update(InventarioFisicoDetalle inventarioFisicoDetalle, Action<InventarioFisicoDetalle, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int inventarioFisicoDetalleId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int inventarioFisicoDetalleId, Action<InventarioFisicoDetalle, Exception> action)
        {
            var reg = MockData.InventarioFisicoDetalle();
            action(reg, null);
        }

        public void GetAll(Action<List<InventarioFisicoDetalle>, Exception> action)
        {
            var lista = new List<InventarioFisicoDetalle>();
            var reg = MockData.InventarioFisicoDetalle();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByInventarioFisico(int inventarioFisicoId, Action<List<InventarioFisicoDetalle>, Exception> action)
        {
            var lista = new List<InventarioFisicoDetalle>();
            var reg = MockData.InventarioFisicoDetalle();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}