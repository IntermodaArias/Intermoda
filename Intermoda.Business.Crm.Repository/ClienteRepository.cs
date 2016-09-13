using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class ClienteRepository
    {

        private static CrmContext _context;

        public static Cliente Insert(Cliente model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ClienteSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Ciudad = CiudadRepository.Get(model.CiudadId);
                    model.Empresa = EmpresaRepository.Get(model.EmpresaId);
                    model.GrupoEconomico = model.GrupoEconomicoId != null
                        ? GrupoEconomicoRepository.Get(model.GrupoEconomicoId.Value)
                        : null;
                    model.Moneda = MonedaRepository.Get(model.MonedaId);
                    model.Pais = PaisRepository.Get(model.PaisId);
                    model.Ruta = RutaRepository.Get(model.RutaId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClienteRepository / Insert", exception);
            }
        }

        public static Cliente Update(Cliente model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ClienteSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.EmpresaId = model.EmpresaId;
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.Direccion = model.Direccion;
                        reg.Telefono = model.Telefono;
                        reg.InventarioDias = model.InventarioDias;
                        reg.InventarioUltimo = model.InventarioUltimo;
                        reg.InventarioProximo = model.InventarioProximo;
                        reg.GrupoEconomicoId = model.GrupoEconomicoId;
                        reg.PaisId = model.PaisId;
                        reg.CiudadId = model.CiudadId;
                        reg.RutaId = model.RutaId;
                        reg.MonedaId = model.MonedaId;

                        _context.SaveChanges();

                        model.Ciudad = CiudadRepository.Get(model.CiudadId);
                        model.Empresa = EmpresaRepository.Get(model.EmpresaId);
                        model.GrupoEconomico = model.GrupoEconomicoId != null
                        ? GrupoEconomicoRepository.Get(model.GrupoEconomicoId.Value)
                        : null;
                        model.Moneda = MonedaRepository.Get(model.MonedaId);
                        model.Pais = PaisRepository.Get(model.PaisId);
                        model.Ruta = RutaRepository.Get(model.RutaId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Cliente con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClienteRepository / Update", exception);
            }
        }

        public static void Delete(Cliente model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ClienteSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.ClienteSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Cliente con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClienteRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int clienteId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ClienteSet
                    .FirstOrDefault(r => r.Id == clienteId);

                    if (reg != null)
                    {
                        _context.ClienteSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Cliente con Id: {clienteId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClienteRepository / Delete (id)", exception);
            }
        }

        public static Cliente Get(int clienteId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.ClienteSet
                        .Include(r => r.Empresa)
                        .Include(r => r.GrupoEconomico)
                        .Include(r => r.Pais)
                        .Include(r => r.Ciudad)
                        .Include(r => r.Ruta)
                        .Include(r => r.Moneda)
                        .FirstOrDefault(r => r.Id == clienteId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Cliente con Id: {clienteId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClienteRepository / Get", exception);
            }
        }

        public static Cliente[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ClienteSet
                        .Include(r => r.Empresa)
                        .Include(r => r.GrupoEconomico)
                        .Include(r => r.Pais)
                        .Include(r => r.Ciudad)
                        .Include(r => r.Ruta)
                        .Include(r => r.Moneda)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClienteRepository / GetAll", exception);
            }
        }

        public static Cliente[] GetByEmpresa(int empresaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ClienteSet
                        .Include(r => r.Empresa)
                        .Include(r => r.GrupoEconomico)
                        .Include(r => r.Pais)
                        .Include(r => r.Ciudad)
                        .Include(r => r.Ruta)
                        .Include(r => r.Moneda)
                        .Where(r => r.EmpresaId == empresaId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClienteRepository / GetByEmpresa", exception);
            }
        }

        public static Cliente[] GetByRuta(int rutaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ClienteSet
                        .Include(r => r.Empresa)
                        .Include(r => r.GrupoEconomico)
                        .Include(r => r.Pais)
                        .Include(r => r.Ciudad)
                        .Include(r => r.Ruta)
                        .Include(r => r.Moneda)
                        .Where(r => r.RutaId == rutaId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClienteRepository / GetByRuta", exception);
            }
        }

        public static Cliente[] GetByGrupoEconomico(int grupoEconomicoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ClienteSet
                        .Include(r => r.Empresa)
                        .Include(r => r.GrupoEconomico)
                        .Include(r => r.Pais)
                        .Include(r => r.Ciudad)
                        .Include(r => r.Ruta)
                        .Include(r => r.Moneda)
                        .Where(r => r.GrupoEconomicoId == grupoEconomicoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClienteRepository / GetByGrupoEconomico", exception);
            }
        }
    }
}