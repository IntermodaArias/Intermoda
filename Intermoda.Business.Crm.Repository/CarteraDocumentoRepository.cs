using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class CarteraDocumentoRepository
    {

        private static CrmContext _context;

        public static CarteraDocumento Insert(CarteraDocumento model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.CarteraDocumentoTipo = CarteraDocumentoTipoRepository.Get(model.CarteraDocumentoTipoId);
                    model.Cliente = ClienteRepository.Get(model.ClienteId);
                    model.Paquete = model.PaqueteId != null ? PaqueteRepository.Get(model.PaqueteId.Value) : null;
                    model.PedidoTipo = model.PedidoTipoId != null ? PedidoTipoRepository.Get(model.PedidoTipoId.Value) : null;
                    model.Moneda = MonedaRepository.Get(model.MonedaId);
                    model.Cai = model.CaiId != null ? CaiRepository.Get(model.CaiId.Value) : null;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoRepository / Insert", exception);
            }
        }

        public static CarteraDocumento Update(CarteraDocumento model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.CarteraDocumentoTipoId = model.CarteraDocumentoTipoId;
                        reg.ClienteId = model.ClienteId;
                        reg.PaqueteId = model.PaqueteId;
                        reg.PedidoTipoId = model.PedidoTipoId;
                        reg.MonedaId = model.MonedaId;
                        reg.CaiId = model.CaiId;
                        reg.Numero = model.Numero;
                        reg.FechaEmision = model.FechaEmision;
                        reg.FechaVencimiento = model.FechaVencimiento;
                        reg.FechaDespacho = model.FechaDespacho;
                        reg.SubTotal = model.SubTotal;
                        reg.Flete = model.Flete;
                        reg.OtrosCargos = model.OtrosCargos;
                        reg.Iva = model.Iva;
                        reg.Total = model.Total;
                        reg.Saldo = model.Saldo;
                        reg.Sincronizado = model.Sincronizado;

                        _context.SaveChanges();

                        model.CarteraDocumentoTipo = CarteraDocumentoTipoRepository.Get(model.CarteraDocumentoTipoId);
                        model.Cliente = ClienteRepository.Get(model.ClienteId);
                        model.Paquete = model.PaqueteId != null ? PaqueteRepository.Get(model.PaqueteId.Value) : null;
                        model.PedidoTipo = model.PedidoTipoId != null ? PedidoTipoRepository.Get(model.PedidoTipoId.Value) : null;
                        model.Moneda = MonedaRepository.Get(model.MonedaId);
                        model.Cai = model.CaiId != null ? CaiRepository.Get(model.CaiId.Value) : null;

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumento con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoRepository / Update", exception);
            }
        }

        public static void Delete(CarteraDocumento model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.CarteraDocumentoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumento con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int carteraDocumentoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoSet
                    .FirstOrDefault(r => r.Id == carteraDocumentoId);

                    if (reg != null)
                    {
                        _context.CarteraDocumentoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumento con Id: {carteraDocumentoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoRepository / Delete (id)", exception);
            }
        }

        public static CarteraDocumento Get(int carteraDocumentoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.CarteraDocumentoSet
                        .Include(r => r.CarteraDocumentoTipo)
                        .Include(r => r.Cliente)
                        .Include(r => r.Moneda)
                        .Include(r => r.Cai)
                        .Include(r => r.Paquete)
                        .Include(r => r.PedidoTipo)
                        .FirstOrDefault(r => r.Id == carteraDocumentoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumento con Id: {carteraDocumentoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoRepository / Get", exception);
            }
        }

        public static CarteraDocumento[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoSet
                        .Include(r => r.CarteraDocumentoTipo)
                        .Include(r => r.Cliente)
                        .Include(r => r.Moneda)
                        .Include(r => r.Cai)
                        .Include(r => r.Paquete)
                        .Include(r => r.PedidoTipo)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoRepository / GetAll", exception);
            }
        }

        public static CarteraDocumento[] GetByCliente(int clienteId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoSet
                        .Include(r => r.CarteraDocumentoTipo)
                        .Include(r => r.Cliente)
                        .Include(r => r.Moneda)
                        .Include(r => r.Cai)
                        .Include(r => r.Paquete)
                        .Include(r => r.PedidoTipo)
                        .Where(r => r.ClienteId == clienteId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoRepository / GetByCliente", exception);
            }
        }

        public static CarteraDocumento[] GetByPaquete(int paqueteId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoSet
                        .Include(r => r.CarteraDocumentoTipo)
                        .Include(r => r.Cliente)
                        .Include(r => r.Moneda)
                        .Include(r => r.Cai)
                        .Include(r => r.Paquete)
                        .Include(r => r.PedidoTipo)
                        .Where(r => r.PaqueteId == paqueteId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoRepository / GetByPaquete", exception);
            }
        }

        public static CarteraDocumento[] GetByPedidoTipo(int pedidoTipoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoSet
                        .Include(r => r.CarteraDocumentoTipo)
                        .Include(r => r.Cliente)
                        .Include(r => r.Moneda)
                        .Include(r => r.Cai)
                        .Include(r => r.Paquete)
                        .Include(r => r.PedidoTipo)
                        .Where(r => r.PedidoTipoId == pedidoTipoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoRepository / GetByPedidoTipo", exception);
            }
        }
    }
}