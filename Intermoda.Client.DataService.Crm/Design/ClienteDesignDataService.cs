using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class ClienteDesignDataService : IClienteDataService
    {
        public void Update(Cliente cliente, Action<Cliente, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int clienteId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int clienteId, Action<Cliente, Exception> action)
        {
            var reg = MockData.Cliente();
            action(reg, null);
        }

        public void GetAll(Action<List<Cliente>, Exception> action)
        {
            var lista = new List<Cliente>();
            var reg = MockData.Cliente();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByEmpresa(int empresaId, Action<List<Cliente>, Exception> action)
        {
            var lista = new List<Cliente>();
            var reg = MockData.Cliente();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByRuta(int rutaId, Action<List<Cliente>, Exception> action)
        {
            var lista = new List<Cliente>();
            var reg = MockData.Cliente();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByGrupoEconomico(int grupoEconomicoId, Action<List<Cliente>, Exception> action)
        {
            var lista = new List<Cliente>();
            var reg = MockData.Cliente();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}