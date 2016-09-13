using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class UsuarioDataService : IUsuarioDataService
    {
        public void Update(Usuario usuario, Action<Usuario, Exception> action)
        {
            try
            {
                var reg = usuario.Id == 0
                    ? UsuarioRepository.Insert(usuario)
                    : UsuarioRepository.Update(usuario);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int usuarioId, Action<Exception> action)
        {
            try
            {
                UsuarioRepository.Delete(usuarioId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int usuarioId, Action<Usuario, Exception> action)
        {
            try
            {
                var reg = UsuarioRepository.Get(usuarioId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Usuario>, Exception> action)
        {
            try
            {
                var lista = UsuarioRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}