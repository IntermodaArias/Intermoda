using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class AcuerdoComercialRepository
    {
        private static CrmContext _context;

        public static AcuerdoComercial Insert(AcuerdoComercial model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AcuerdoComercialSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Cliente = ClienteRepository.Get(model.ClienteId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialRepository / Insert", exception);
            }
        }

        public static AcuerdoComercial Update(AcuerdoComercial model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AcuerdoComercialSet
                        .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.ClienteId = model.ClienteId;
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.FechaInicial = model.FechaInicial;
                        reg.FechaFinal = model.FechaFinal;
                        _context.SaveChanges();

                        model.Cliente = ClienteRepository.Get(model.ClienteId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de AcuerdoComercial con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialRepository / Update", exception);
            }
        }

        public static void Delete(AcuerdoComercial model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AcuerdoComercialSet
                        .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.AcuerdoComercialSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de AcuerdoComercial con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int acuerdoComercialId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AcuerdoComercialSet
                        .FirstOrDefault(r => r.Id == acuerdoComercialId);

                    if (reg != null)
                    {
                        _context.AcuerdoComercialSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de AcuerdoComercial con Id: {acuerdoComercialId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialRepository / Delete (id)", exception);
            }
        }

        public static AcuerdoComercial Get(int acuerdoComercialId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.AcuerdoComercialSet
                        .Include(r=>r.Cliente)
                        .FirstOrDefault(r => r.Id == acuerdoComercialId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de AcuerdoComercial con Id: {acuerdoComercialId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialRepository / Get", exception);
            }
        }

        public static AcuerdoComercial[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.AcuerdoComercialSet
                        .Include(r => r.Cliente)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialRepository / GetAll", exception);
            }
        }

        public static AcuerdoComercial[] GetByCliente(int clienteId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.AcuerdoComercialSet
                        .Include(r => r.Cliente)
                        .Where(r=>r.ClienteId == clienteId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AcuerdoComercialRepository / GetByCliente", exception);
            }
        }
    }
}