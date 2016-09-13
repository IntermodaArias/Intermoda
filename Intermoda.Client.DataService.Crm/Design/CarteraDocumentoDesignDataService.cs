using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class CarteraDocumentoDesignDataService : ICarteraDocumentoDataService
    {
        public void Update(CarteraDocumento carteraDocumento, Action<CarteraDocumento, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int carteraDocumentoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int carteraDocumentoId, Action<CarteraDocumento, Exception> action)
        {

            var reg = MockData.CarteraDocumento();
            action(reg, null);
        }

        public void GetAll(Action<List<CarteraDocumento>, Exception> action)
        {

            var lista = new List<CarteraDocumento>();
            var reg = MockData.CarteraDocumento();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByCliente(int clienteId, Action<List<CarteraDocumento>, Exception> action)
        {
            var lista = new List<CarteraDocumento>();
            var reg = MockData.CarteraDocumento();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByPaquete(int paqueteId, Action<List<CarteraDocumento>, Exception> action)
        {
            var lista = new List<CarteraDocumento>();
            var reg = MockData.CarteraDocumento();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByPedidoTipo(int pedidoTipoId, Action<List<CarteraDocumento>, Exception> action)
        {
            var lista = new List<CarteraDocumento>();
            var reg = MockData.CarteraDocumento();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}