using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class CarteraDocumentoTipoDataService : ICarteraDocumentoTipoDataService
    {
        public void Update(CarteraDocumentoTipo carteraDocumentoTipo, Action<CarteraDocumentoTipo, Exception> action)
        {
            try
            {
                var reg = carteraDocumentoTipo.Id == 0
                    ? CarteraDocumentoTipoRepository.Insert(carteraDocumentoTipo)
                    : CarteraDocumentoTipoRepository.Update(carteraDocumentoTipo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int carteraDocumentoTipoId, Action<Exception> action)
        {
            try
            {
                CarteraDocumentoTipoRepository.Delete(carteraDocumentoTipoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int carteraDocumentoTipoId, Action<CarteraDocumentoTipo, Exception> action)
        {
            try
            {
                var reg = CarteraDocumentoTipoRepository.Get(carteraDocumentoTipoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<CarteraDocumentoTipo>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoTipoRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}