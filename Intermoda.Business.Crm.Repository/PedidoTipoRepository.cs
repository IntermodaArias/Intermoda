using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class PedidoTipoRepository
    {
        private static CrmContext _context;

        public static PedidoTipo Insert(PedidoTipo model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PedidoTipoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PedidoTipoRepository / Insert", exception);
            }
        }

        public static PedidoTipo Update(PedidoTipo model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PedidoTipoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de PedidoTipo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PedidoTipoRepository / Update", exception);
            }
        }

        public static void Delete(PedidoTipo model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PedidoTipoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.PedidoTipoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de PedidoTipo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PedidoTipoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int pedidoTipoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PedidoTipoSet
                    .FirstOrDefault(r => r.Id == pedidoTipoId);

                    if (reg != null)
                    {
                        _context.PedidoTipoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de PedidoTipo con Id: {pedidoTipoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PedidoTipoRepository / Delete (id)", exception);
            }
        }

        public static PedidoTipo Get(int pedidoTipoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.PedidoTipoSet
                    .FirstOrDefault(r => r.Id == pedidoTipoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de PedidoTipo con Id: {pedidoTipoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PedidoTipoRepository / Get", exception);
            }
        }

        public static PedidoTipo[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.PedidoTipoSet
                    .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PedidoTipoRepository / GetAll", exception);
            }
        } 
    }
}