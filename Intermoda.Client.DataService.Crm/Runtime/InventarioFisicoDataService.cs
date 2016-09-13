using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class InventarioFisicoDataService : IInventarioFisicoDataService
    {
        public void Update(InventarioFisico invenatrioFisico, Action<InventarioFisico, Exception> action)
        {
            try
            {
                var reg = invenatrioFisico.Id == 0
                    ? InventarioFisicoRepository.Insert(invenatrioFisico)
                    : InventarioFisicoRepository.Update(invenatrioFisico);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int invenatrioFisicoId, Action<Exception> action)
        {
            try
            {
                InventarioFisicoRepository.Delete(invenatrioFisicoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int invenatrioFisicoId, Action<InventarioFisico, Exception> action)
        {
            try
            {
                var reg = InventarioFisicoRepository.Get(invenatrioFisicoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<InventarioFisico>, Exception> action)
        {
            try
            {
                var lista = InventarioFisicoRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByCliente(int clienteId, Action<List<InventarioFisico>, Exception> action)
        {
            try
            {
                var lista = InventarioFisicoRepository.GetByCliente(clienteId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}