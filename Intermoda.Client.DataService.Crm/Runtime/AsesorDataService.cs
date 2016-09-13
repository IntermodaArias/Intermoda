using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class AsesorDataService : IAsesorDataService
    {
        public void Update(Asesor asesor, Action<Asesor, Exception> action)
        {
            try
            {
                var reg = asesor.Id == 0
                    ? AsesorRepository.Insert(asesor)
                    : AsesorRepository.Update(asesor);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int asesorId, Action<Exception> action)
        {
            try
            {
                AsesorRepository.Delete(asesorId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int asesorId, Action<Asesor, Exception> action)
        {
            try
            {
                var reg = AsesorRepository.Get(asesorId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Asesor>, Exception> action)
        {
            try
            {
                var lista = AsesorRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByZona(int zonaId, Action<List<Asesor>, Exception> action)
        {
            try
            {
                var lista = AsesorRepository.GetByZona(zonaId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}