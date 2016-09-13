using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class CaiRepository
    {

        private static CrmContext _context;

        public static Cai Insert(Cai model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CaiSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.CarteraDocumentoTipo = CarteraDocumentoTipoRepository.Get(model.CarterDocumentoTipoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CaiRepository / Insert", exception);
            }
        }

        public static Cai Update(Cai model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CaiSet
                        .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.CarterDocumentoTipoId = model.CarterDocumentoTipoId;
                        reg.Codigo = model.Codigo;
                        reg.Descripcion = model.Descripcion;
                        reg.FechaMaximaEmision = model.FechaMaximaEmision;
                        reg.Establecimiento = model.Establecimiento;
                        reg.PuntoEmision = model.PuntoEmision;
                        reg.TipoDocumento = model.TipoDocumento;
                        reg.NumeroInicial = model.NumeroInicial;
                        reg.NumeroFinal = model.NumeroFinal;

                        _context.SaveChanges();

                        model.CarteraDocumentoTipo = CarteraDocumentoTipoRepository.Get(model.CarterDocumentoTipoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Cai con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CaiRepository / Update", exception);
            }
        }

        public static void Delete(Cai model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CaiSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.CaiSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Cai con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CaiRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int caiId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CaiSet
                    .FirstOrDefault(r => r.Id == caiId);

                    if (reg != null)
                    {
                        _context.CaiSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Cai con Id: {caiId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CaiRepository / Delete (id)", exception);
            }
        }

        public static Cai Get(int caiId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.CaiSet
                        .Include(r => r.CarteraDocumentoTipo)
                        .FirstOrDefault(r => r.Id == caiId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Cai con Id: {caiId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CaiRepository / Get", exception);
            }
        }

        public static Cai[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CaiSet
                        .Include(r => r.CarteraDocumentoTipo)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CaiRepository / GetAll", exception);
            }
        }

        public static Cai[] GetByCarteraDocumentoTipo(int carteraDocumentoTipoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CaiSet
                        .Include(r => r.CarteraDocumentoTipo)
                        .Where(r => r.CarterDocumentoTipoId == carteraDocumentoTipoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CaiRepository / GetAll", exception);
            }
        }
    }
}