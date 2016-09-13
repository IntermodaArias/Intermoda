using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class ModuloSemanaOperario : IModuloSemanaOperario
    {
        public ModuloSemanaOperarioBusiness Update(ModuloSemanaOperarioBusiness moduloSemanaOperario)
        {
            try
            {
                return moduloSemanaOperario.Id == 0
                    ? ModuloSemanaOperarioBusiness.Insert(moduloSemanaOperario)
                    : ModuloSemanaOperarioBusiness.Update(moduloSemanaOperario);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperario.Update", exception);
            }
        }

        public void Delete(int moduloSemanaOperarioId)
        {
            try
            {
                ModuloSemanaOperarioBusiness.Delete(moduloSemanaOperarioId);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperario.Delete", exception);
            }
        }

        public ModuloSemanaOperarioBusiness Get(int moduloSemanaOperarioId)
        {
            try
            {
                return ModuloSemanaOperarioBusiness.Get(moduloSemanaOperarioId);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperario.Get", exception);
            }
        }

        public ModuloSemanaOperarioBusiness[] GetAll()
        {
            try
            {
                return ModuloSemanaOperarioBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperario.GetAll", exception);
            }
        }

        public ModuloSemanaOperarioBusiness[] GetByModuloSemana(int moduloSemanaId)
        {
            try
            {
                return ModuloSemanaOperarioBusiness.GetByModuloSemana(moduloSemanaId);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperario.GetByModuloSemana", exception);
            }
        }
    }
}
