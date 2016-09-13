using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class CarteraDocumentoTipoRepository
    {

        private static CrmContext _context;

        public static CarteraDocumentoTipo Insert(CarteraDocumentoTipo model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoTipoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoTipoRepository / Insert", exception);
            }
        }

        public static CarteraDocumentoTipo Update(CarteraDocumentoTipo model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoTipoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.Tipo = model.Tipo;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoTipo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoTipoRepository / Update", exception);
            }
        }

        public static void Delete(CarteraDocumentoTipo model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoTipoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.CarteraDocumentoTipoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoTipo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoTipoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int carteraDocumentoTipoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoTipoSet
                    .FirstOrDefault(r => r.Id == carteraDocumentoTipoId);

                    if (reg != null)
                    {
                        _context.CarteraDocumentoTipoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoTipo con Id: {carteraDocumentoTipoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoTipoRepository / Delete (id)", exception);
            }
        }

        public static CarteraDocumentoTipo Get(int carteraDocumentoTipoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.CarteraDocumentoTipoSet
                        .FirstOrDefault(r => r.Id == carteraDocumentoTipoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoTipo con Id: {carteraDocumentoTipoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoTipoRepository / Get", exception);
            }
        }

        public static CarteraDocumentoTipo[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoTipoSet
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoTipoRepository / GetAll", exception);
            }
        } 
    }
}