using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class ModuloSemana : IModuloSemana
    {
        public ModuloSemanaBusiness Update(ModuloSemanaBusiness moduloSemana)
        {
            try
            {
                return moduloSemana.Id == 0
                    ? ModuloSemanaBusiness.Insert(moduloSemana)
                    : ModuloSemanaBusiness.Update(moduloSemana);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana.Update", exception);
            }
        }

        public void Delete(int moduloSemanaId)
        {
            try
            {
                ModuloSemanaBusiness.Delete(moduloSemanaId);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana.Delete", exception);
            }
        }

        public ModuloSemanaBusiness Get(int moduloSemanaId)
        {
            try
            {
                return ModuloSemanaBusiness.Get(moduloSemanaId);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana.Get", exception);
            }
        }

        public ModuloSemanaBusiness[] GetAll()
        {
            try
            {
                return ModuloSemanaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana.GetAll", exception);
            }
        }

        public ModuloSemanaBusiness[] GetByFecha(DateTime fechaInicio)
        {
            try
            {
                return ModuloSemanaBusiness.GetByFecha(fechaInicio);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana.GetByFecha", exception);
            }
        }

        public ModuloSemanaBusiness[] GetByFechaCentroTrabajo(DateTime fechaInicio, int centroTrabajoId)
        {
            try
            {
                return ModuloSemanaBusiness.GetbyFechaCentroTrabajo(fechaInicio, centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana.GetByFechaCentroTrabajo", exception);
            }
        }

        public ModuloSemanaBusiness[] GetByFechaModulo(DateTime fechaInicio, int moduloId)
        {
            try
            {
                return ModuloSemanaBusiness.GetbyFechaModulo(fechaInicio, moduloId);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana.GetByFechaModulo", exception);
            }
        }
    }
}
