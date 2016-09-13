using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IInventarioFisicoDataService
    {
        void Update(InventarioFisico invenatrioFisico, Action<InventarioFisico, Exception> action);

        void Delete(int invenatrioFisicoId, Action<Exception> action);

        void Get(int invenatrioFisicoId, Action<InventarioFisico, Exception> action);

        void GetAll(Action<List<InventarioFisico>, Exception> action);

        void GetByCliente(int clienteId, Action<List<InventarioFisico>, Exception> action);
    }
}
