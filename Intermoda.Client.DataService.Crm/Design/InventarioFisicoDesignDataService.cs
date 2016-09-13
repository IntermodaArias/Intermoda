using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class InventarioFisicoDesignDataService : IInventarioFisicoDataService
    {
        public void Update(InventarioFisico invenatrioFisico, Action<InventarioFisico, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int invenatrioFisicoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int invenatrioFisicoId, Action<InventarioFisico, Exception> action)
        {
            var reg = MockData.InventarioFisico();
            action(reg, null);
        }

        public void GetAll(Action<List<InventarioFisico>, Exception> action)
        {
            var lista = new List<InventarioFisico>();
            var reg = MockData.InventarioFisico();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByCliente(int clienteId, Action<List<InventarioFisico>, Exception> action)
        {
            var lista = new List<InventarioFisico>();
            var reg = MockData.InventarioFisico();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}