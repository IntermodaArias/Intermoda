using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class EdadDataService : IEdadDataService
    {
        public void Update(Edad edad, Action<Edad, Exception> action)
        {
            try
            {
                var reg = edad.Id == 0
                    ? EdadRepository.Insert(edad)
                    : EdadRepository.Update(edad);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int edadId, Action<Exception> action)
        {
            try
            {
                EdadRepository.Delete(edadId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int edadId, Action<Edad, Exception> action)
        {
            try
            {
                var reg = EdadRepository.Get(edadId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Edad>, Exception> action)
        {
            try
            {
                var lista = EdadRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}