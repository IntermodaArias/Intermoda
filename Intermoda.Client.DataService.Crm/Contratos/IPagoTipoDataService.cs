using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IPagoTipoDataService
    {
        void Update(PagoTipo pagoTipo, Action<PagoTipo, Exception> action);

        void Delete(int pagoTipoId, Action<Exception> action);

        void Get(int pagoTipoId, Action<PagoTipo, Exception> action);

        void GetAll(Action<List<PagoTipo>, Exception> action);
    }
}