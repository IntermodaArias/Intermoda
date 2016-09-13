using System;
using Intermoda.Business.Lavanderia;
using Intermoda.Common.Enum;

namespace Intermoda.DataService.Lavanderia
{
    public class Maquina : IMaquina
    {
        public MaquinaBusiness Update(MaquinaBusiness maquina)
        {
            try
            {
                return MaquinaBusiness.Update(maquina);
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / Update", exception);
            }
        }

        public void Delete(MaquinaTipo tipo, int maquinaId)
        {
            try
            {
                MaquinaBusiness.Delete(tipo, maquinaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / Delete", exception);
            }
        }

        public MaquinaBusiness Get(MaquinaTipo tipo, int maquinaId)
        {
            try
            {
                return MaquinaBusiness.Get(tipo, maquinaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / Get", exception);
            }
        }

        public MaquinaBusiness[] GetAll()
        {
            try
            {
                return MaquinaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / GetAll", exception);
            }
        }

        public MaquinaBusiness[] GetByTipo(MaquinaTipo tipo)
        {
            try
            {
                return MaquinaBusiness.GetByTipo(tipo);
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / GetByTipo", exception);
            }
        }

        public MaquinaBusiness[] GetByTipoCapacidad(MaquinaTipo tipo, int capacidadId)
        {
            try
            {
                return MaquinaBusiness.GetByTipoCapacidad(tipo, capacidadId);
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / GetByTipoCapacidad", exception);
            }
        }
    }
}
