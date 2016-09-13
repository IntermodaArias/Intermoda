using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IClienteDataService
    {
        void Update(Cliente cliente, Action<Cliente, Exception> action);

        void Delete(int clienteId, Action<Exception> action);

        void Get(int clienteId, Action<Cliente, Exception> action);

        void GetAll(Action<List<Cliente>, Exception> action);

        void GetByEmpresa(int empresaId, Action<List<Cliente>, Exception> action);

        void GetByRuta(int rutaId, Action<List<Cliente>, Exception> action);

        void GetByGrupoEconomico(int grupoEconomicoId, Action<List<Cliente>, Exception> action);
    }
}