using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class CarteraDocumentoDetallePagoRepository
    {

        private static CrmContext _context;

        public static CarteraDocumentoDetallePago Insert(CarteraDocumentoDetallePago model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetallePagoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.CarteraDocumento = CarteraDocumentoRepository.Get(model.CarteraDocumentoId);
                    model.PagoTipo = PagoTipoRepository.Get(model.PagoTipoId);
                    model.Moneda = MonedaRepository.Get(model.MonedaId);
                    model.Banco = model.BancoId != null ? BancoRepository.Get(model.BancoId.Value) : null;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetallePagoRepository / Insert", exception);
            }
        }

        public static CarteraDocumentoDetallePago Update(CarteraDocumentoDetallePago model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetallePagoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.CarteraDocumentoId = model.CarteraDocumentoId;
                        reg.Linea = model.Linea;
                        reg.PagoTipoId = model.PagoTipoId;
                        reg.MonedaId = model.MonedaId;
                        reg.BancoId = model.BancoId;
                        reg.Referencia = model.Referencia;
                        reg.Monto = model.Monto;

                        _context.SaveChanges();

                        model.CarteraDocumento = CarteraDocumentoRepository.Get(model.CarteraDocumentoId);
                        model.PagoTipo = PagoTipoRepository.Get(model.PagoTipoId);
                        model.Moneda = MonedaRepository.Get(model.MonedaId);
                        model.Banco = model.BancoId != null ? BancoRepository.Get(model.BancoId.Value) : null;

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetallePago con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetallePagoRepository / Update", exception);
            }
        }

        public static void Delete(CarteraDocumentoDetallePago model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetallePagoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.CarteraDocumentoDetallePagoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetallePago con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetallePagoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int carteraDocumentoDetallePagoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetallePagoSet
                    .FirstOrDefault(r => r.Id == carteraDocumentoDetallePagoId);

                    if (reg != null)
                    {
                        _context.CarteraDocumentoDetallePagoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetallePago con Id: {carteraDocumentoDetallePagoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetallePagoRepository / Delete (id)", exception);
            }
        }

        public static CarteraDocumentoDetallePago Get(int carteraDocumentoDetallePagoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.CarteraDocumentoDetallePagoSet
                        .Include(r => r.CarteraDocumento)
                        .Include(r => r.PagoTipo)
                        .Include(r => r.Moneda)
                        .FirstOrDefault(r => r.Id == carteraDocumentoDetallePagoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetallePago con Id: {carteraDocumentoDetallePagoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetallePagoRepository / Get", exception);
            }
        }

        public static CarteraDocumentoDetallePago[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoDetallePagoSet
                        .Include(r => r.CarteraDocumento)
                        .Include(r => r.PagoTipo)
                        .Include(r => r.Moneda)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetallePagoRepository / GetAll", exception);
            }
        }

        public static CarteraDocumentoDetallePago[] GetByCarteraDocumento(int carteraDocumentoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoDetallePagoSet
                        .Include(r => r.CarteraDocumento)
                        .Include(r => r.PagoTipo)
                        .Include(r => r.Moneda)
                        .Where(r => r.CarteraDocumentoId == carteraDocumentoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetallePagoRepository / GetByCarteraDocumento", exception);
            }
        }
    }
}