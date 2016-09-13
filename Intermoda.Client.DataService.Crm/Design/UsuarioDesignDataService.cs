using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class UsuarioDesignDataService : IUsuarioDataService
    {
        public void Update(Usuario usuario, Action<Usuario, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int usuarioId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int usuarioId, Action<Usuario, Exception> action)
        {
            var reg = MockData.Usuario();
            action(reg, null);
        }

        public void GetAll(Action<List<Usuario>, Exception> action)
        {
            var lista = new List<Usuario>();
            var reg = MockData.Usuario();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}