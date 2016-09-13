using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface ICarteraDocumentoDataService
    {
        void Update(CarteraDocumento carteraDocumento, Action<CarteraDocumento, Exception> action);

        void Delete(int carteraDocumentoId, Action<Exception> action);

        void Get(int carteraDocumentoId, Action<CarteraDocumento, Exception> action);

        void GetAll(Action<List<CarteraDocumento>, Exception> action);

        void GetByCliente(int clienteId, Action<List<CarteraDocumento>, Exception> action);

        void GetByPaquete(int paqueteId, Action<List<CarteraDocumento>, Exception> action);

        void GetByPedidoTipo(int pedidoTipoId, Action<List<CarteraDocumento>, Exception> action);
    }
}