using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class AsesorRutaDataService : IAsesorRutaDataService
    {
        public void Update(AsesorRuta asesorRuta, Action<AsesorRuta, Exception> action)
        {
            try
            {
                var reg = asesorRuta.Id == 0
                    ? AsesorRutaRepository.Insert(asesorRuta)
                    : AsesorRutaRepository.Update(asesorRuta);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int asesorRutaId, Action<Exception> action)
        {
            try
            {
                AsesorRutaRepository.Delete(asesorRutaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int asesorRutaId, Action<AsesorRuta, Exception> action)
        {
            try
            {
                var reg = AsesorRutaRepository.Get(asesorRutaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<AsesorRuta>, Exception> action)
        {
            try
            {
                var lista = AsesorRutaRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByAsesor(int asesorId, Action<List<AsesorRuta>, Exception> action)
        {
            try
            {
                var lista = AsesorRutaRepository.GetByAsesor(asesorId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByRuta(int rutaId, Action<List<AsesorRuta>, Exception> action)
        {
            try
            {
                var lista = AsesorRutaRepository.GetByRuta(rutaId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}