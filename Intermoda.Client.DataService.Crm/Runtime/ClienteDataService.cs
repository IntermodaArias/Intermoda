using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class ClienteDataService : IClienteDataService
    {
        public void Update(Cliente cliente, Action<Cliente, Exception> action)
        {
            try
            {
                var reg = cliente.Id == 0
                    ? ClienteRepository.Insert(cliente)
                    : ClienteRepository.Update(cliente);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int clienteId, Action<Exception> action)
        {
            try
            {
                ClienteRepository.Delete(clienteId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int clienteId, Action<Cliente, Exception> action)
        {
            try
            {
                var reg = ClienteRepository.Get(clienteId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Cliente>, Exception> action)
        {
            try
            {
                var lista = ClienteRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByEmpresa(int empresaId, Action<List<Cliente>, Exception> action)
        {
            try
            {
                var lista = ClienteRepository.GetByEmpresa(empresaId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByRuta(int rutaId, Action<List<Cliente>, Exception> action)
        {
            try
            {
                var lista = ClienteRepository.GetByRuta(rutaId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByGrupoEconomico(int grupoEconomicoId, Action<List<Cliente>, Exception> action)
        {
            try
            {
                var lista = ClienteRepository.GetByGrupoEconomico(grupoEconomicoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}