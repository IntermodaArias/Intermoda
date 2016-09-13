using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class CarteraDocumentoDetalleAplicacionRepository
    {

        private static CrmContext _context;

        public static CarteraDocumentoDetalleAplicacion Insert(CarteraDocumentoDetalleAplicacion model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetalleAplicacionSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.CarteraDocumentoDebito = CarteraDocumentoRepository.Get(model.CarteraDocumentoDebitoId);
                    model.CarteraDocumentoCredito = CarteraDocumentoRepository.Get(model.CarteraDocumentoCreditoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleAplicacionRepository / Insert", exception);
            }
        }

        public static CarteraDocumentoDetalleAplicacion Update(CarteraDocumentoDetalleAplicacion model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetalleAplicacionSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.CarteraDocumentoDebitoId = model.CarteraDocumentoDebitoId;
                        reg.CarteraDocumentoCreditoId = model.CarteraDocumentoCreditoId;
                        reg.Fecha = model.Fecha;
                        reg.Aplicacion = model.Aplicacion;

                        _context.SaveChanges();

                        model.CarteraDocumentoDebito = CarteraDocumentoRepository.Get(model.CarteraDocumentoDebitoId);
                        model.CarteraDocumentoCredito = CarteraDocumentoRepository.Get(model.CarteraDocumentoCreditoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetalleAplicacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleAplicacionRepository / Update", exception);
            }
        }

        public static void Delete(CarteraDocumentoDetalleAplicacion model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetalleAplicacionSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.CarteraDocumentoDetalleAplicacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetalleAplicacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleAplicacionRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int carteraDocumentoDetalleAplicacionId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetalleAplicacionSet
                    .FirstOrDefault(r => r.Id == carteraDocumentoDetalleAplicacionId);

                    if (reg != null)
                    {
                        _context.CarteraDocumentoDetalleAplicacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetalleAplicacion con Id: {carteraDocumentoDetalleAplicacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleAplicacionRepository / Delete (id)", exception);
            }
        }

        public static CarteraDocumentoDetalleAplicacion Get(int carteraDocumentoDetalleAplicacionId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.CarteraDocumentoDetalleAplicacionSet
                        .Include("CarteraDocumentoDebito")
                        .Include("CarteraDocumentoCredito")
                        .FirstOrDefault(r => r.Id == carteraDocumentoDetalleAplicacionId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetalleAplicacion con Id: {carteraDocumentoDetalleAplicacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleAplicacionRepository / Get", exception);
            }
        }

        public static CarteraDocumentoDetalleAplicacion[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoDetalleAplicacionSet
                        .Include("CarteraDocumentoDebito")
                        .Include("CarteraDocumentoCredito")
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleAplicacionRepository / GetAll", exception);
            }
        }

        public static CarteraDocumentoDetalleAplicacion[] GetByCarteraDocumentoDebito(int carteraDocumentoDebitoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoDetalleAplicacionSet
                        .Include(r => r.CarteraDocumentoDebito)
                        .Include(r => r.CarteraDocumentoCredito)
                        .Where(r => r.CarteraDocumentoCreditoId == carteraDocumentoDebitoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleAplicacionRepository / GetByCarteraDocumentoDebito", exception);
            }
        }

        public static CarteraDocumentoDetalleAplicacion[] GetByCarteraDocumentoCredito(int carteraDocumentoCreditoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoDetalleAplicacionSet
                        .Include(r=>r.CarteraDocumentoDebito)
                        .Include(r=>r.CarteraDocumentoCredito)
                        .Where(r=>r.CarteraDocumentoCreditoId == carteraDocumentoCreditoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleAplicacionRepository / GetByCarteraDocumentoCredito", exception);
            }
        }
    }
}