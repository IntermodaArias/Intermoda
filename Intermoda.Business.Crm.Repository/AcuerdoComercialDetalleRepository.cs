using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class AcuerdoComercialDetalleReporitory
    {

        private static CrmContext _context;

        public static AcuerdoComercialDetalle Insert(AcuerdoComercialDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AcuerdoComercialDetalleSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.AcuerdoComercial = AcuerdoComercialRepository.Get(model.AcuerdoComercialId);
                    model.Producto = ProductoRepository.Get(model.ProductoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialDetalleRepository / Insert", exception);
            }
        }

        public static AcuerdoComercialDetalle Update(AcuerdoComercialDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AcuerdoComercialDetalleSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.AcuerdoComercialId = model.AcuerdoComercialId;
                        reg.ProductoId = model.ProductoId;
                        reg.Precio = model.Precio;

                        _context.SaveChanges();

                        model.AcuerdoComercial = AcuerdoComercialRepository.Get(model.AcuerdoComercialId);
                        model.Producto = ProductoRepository.Get(model.ProductoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de AcuerdoComercialDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialDetalleRepository / Update", exception);
            }
        }

        public static void Delete(AcuerdoComercialDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AcuerdoComercialDetalleSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.AcuerdoComercialDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de AcuerdoComercialDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialDetalleRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int acuerdoComercialDetalleId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AcuerdoComercialDetalleSet
                    .FirstOrDefault(r => r.Id == acuerdoComercialDetalleId);

                    if (reg != null)
                    {
                        _context.AcuerdoComercialDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de AcuerdoComercialDetalle con Id: {acuerdoComercialDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialDetalleRepository / Delete (id)", exception);
            }
        }

        public static AcuerdoComercialDetalle Get(int acuerdoComercialDetalleId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.AcuerdoComercialDetalleSet
                        .Include(r => r.AcuerdoComercial)
                        .Include(r => r.Producto)
                        .FirstOrDefault(r => r.Id == acuerdoComercialDetalleId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de AcuerdoComercialDetalle con Id: {acuerdoComercialDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialDetalleRepository / Get", exception);
            }
        }

        public static AcuerdoComercialDetalle[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.AcuerdoComercialDetalleSet
                        .Include(r => r.AcuerdoComercial)
                        .Include(r => r.Producto)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialDetalleRepository / GetAll", exception);
            }
        }

        public static AcuerdoComercialDetalle[] GetByAcuerdoComercial(int acuerdoComercialId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.AcuerdoComercialDetalleSet
                        .Include(r => r.AcuerdoComercial)
                        .Include(r => r.Producto)
                        .Where(r => r.AcuerdoComercialId == acuerdoComercialId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialDetalleRepository / GetByAcuerdoComercial", exception);
            }
        }
    }
}