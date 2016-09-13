using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class PaqueteDetalleDesignDataService : IPaqueteDetalleDataService
    {
        public void Update(PaqueteDetalle paqueteDetalle, Action<PaqueteDetalle, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int paqueteDetalleId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int paqueteDetalleId, Action<PaqueteDetalle, Exception> action)
        {
            var reg = MockData.PaqueteDetalle();
            action(reg, null);
        }

        public void GetAll(Action<List<PaqueteDetalle>, Exception> action)
        {
            var lista = new List<PaqueteDetalle>();
            var reg = MockData.PaqueteDetalle();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByPaquete(int paqueteId, Action<List<PaqueteDetalle>, Exception> action)
        {
            var lista = new List<PaqueteDetalle>();
            var reg = MockData.PaqueteDetalle();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByProducto(int productoId, Action<List<PaqueteDetalle>, Exception> action)
        {
            var lista = new List<PaqueteDetalle>();
            var reg = MockData.PaqueteDetalle();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}