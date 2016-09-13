using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IUsuarioDataService
    {
        void Update(Usuario usuario, Action<Usuario, Exception> action);

        void Delete(int usuarioId, Action<Exception> action);

        void Get(int usuarioId, Action<Usuario, Exception> action);

        void GetAll(Action<List<Usuario>, Exception> action);
    }
}