using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class Modulo : IModulo
    {
        public ModuloBusiness Update(ModuloBusiness modulo)
        {
            try
            {
                return modulo.Id == 0
                    ? ModuloBusiness.Insert(modulo)
                    : ModuloBusiness.Update(modulo);
            }
            catch (Exception exception)
            {
                throw new Exception("Modulo.Update", exception);
            }
        }

        public void Delete(int moduloId)
        {
            try
            {
                ModuloBusiness.Delete(moduloId);
            }
            catch (Exception exception)
            {
                throw new Exception("Modulo.Delete", exception);
            }
        }

        public ModuloBusiness Get(int moduloId)
        {
            try
            {
                return ModuloBusiness.Get(moduloId);
            }
            catch (Exception exception)
            {
                throw new Exception("Modulo.Get", exception);
            }
        }

        public ModuloBusiness[] GetAll()
        {
            try
            {
                return ModuloBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Modulo.GetAll", exception);
            }
        }

        public ModuloBusiness[] GetAllActivos()
        {
            try
            {
                return ModuloBusiness.GetAllActivos();
            }
            catch (Exception exception)
            {
                throw new Exception("Modulo.GetAllActivos", exception);
            }
        }

        public ModuloBusiness[] GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                return ModuloBusiness.GetByCentroTrabajo(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Modulo.sGetByCentroTrabajo", exception);
            }
        }

        public ModuloBusiness[] GetByCentroTrabajoActivos(int centroTrabajoId)
        {
            try
            {
                return ModuloBusiness.GetByCentroTrabajoActivos(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Modulo.GetByCentroTrabajoActivos", exception);
            }
        }
    }
}
