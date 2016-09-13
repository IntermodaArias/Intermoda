using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class Tela : ITela
    {
        public TelaBusiness Get(string telaCodigo)
        {
            try
            {
                return TelaBusiness.Get(telaCodigo);
            }
            catch (Exception exception)
            {
                throw new Exception("Tela / Get", exception);
            }
        }

        public TelaBusiness[] GetAll()
        {
            try
            {
                return TelaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Tela / GetAll", exception);
            }
        }

        public TelaBusiness[] GetCombo()
        {
            try
            {
                return TelaBusiness.GetCombo();
            }
            catch (Exception exception)
            {
                throw new Exception("Tela / GetCombo", exception);
            }
        }

        public string GetComposicionCodigo(string telaCodigo)
        {
            try
            {
                return TelaBusiness.GetComposicionCodigo(telaCodigo);
            }
            catch (Exception exception)
            {
                throw new Exception("Tela / GetComposicionCodigo", exception);
            }
        }
    }
}
