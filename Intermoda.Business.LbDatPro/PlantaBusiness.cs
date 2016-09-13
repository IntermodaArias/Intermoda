using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class PlantaBusiness
    {
        private static LBDATPROEntities _context;

        #region Properties

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Iniciales { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string ProveedorNombre { get; set; }

        [DataMember]
        public string GeneraTicket { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public short? BodegaId { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public short? Habilitar { get; set; }

        [DataMember]
        public int? NuevoId { get; set; }

        [DataMember]
        public short? CompaniaId { get; set; }

        [DataMember]
        public short? ProveedorId { get; set; }

        [DataMember]
        public string Usuario { get; set; }

        [DataMember]
        public string Clave { get; set; }

        #endregion

        #region Methods

        public static PlantaBusiness Insert(PlantaBusiness model)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    throw new NotImplementedException();
                    //var reg = new CORPLA
                    //{
                    //};
                    //_context.CORPLASet.Add(reg);
                    //_context.SaveChanges();

                    //model.Id = reg.PrdCorFab;

                    //return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / Insert", exception);
            }
        }

        public static PlantaBusiness Update(PlantaBusiness model)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    throw new NotImplementedException();
                    //var reg = (from r in _context.CORPLASet
                    //           where r.PrdCorFab == model.Id
                    //           select r).FirstOrDefault();
                    //if (reg != null)
                    //{

                    //    _context.SaveChanges();

                    //    return model;
                    //}
                    //throw new Exception($"No se ha encontrado registro de Planta con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / Update", exception);
            }
        }

        public static void Delete(PlantaBusiness model)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    throw new NotImplementedException();
                    //var reg = (from r in _context.CORPLASet
                    //           where r.PrdCorFab == model.Id
                    //           select r).FirstOrDefault();
                    //if (reg != null)
                    //{
                    //    _context.CORPLASet.Remove(reg);
                    //    _context.SaveChanges();

                    //    return;
                    //}
                    //throw new Exception($"No se ha encontrado registro de Planta con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(string plantaId)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    throw new NotImplementedException();
                    //var reg = (from r in _context.CORPLASet
                    //           where r.PrdCorFab == plantaId
                    //           select r).FirstOrDefault();
                    //if (reg != null)
                    //{
                    //    _context.CORPLASet.Remove(reg);
                    //    _context.SaveChanges();

                    //    return;
                    //}
                    //throw new Exception($"No se ha encontrado registro de Planta con Id: {plantaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / Delete (id)", exception);
            }
        }

        public static PlantaBusiness Get(string plantaId)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.CORPLASet
                        join p in _context.PRVMSTSet on
                            r.PrdCodPrv equals p.PrvCod
                        where r.PrdCorFab == plantaId
                        select new PlantaBusiness
                        {
                            Id = r.PrdCorFab,
                            Iniciales = r.PrdCorIni,
                            Descripcion = r.PrdCorDes,
                            GeneraTicket = r.PrdCorTck,
                            Tipo = r.PrdCorTip,
                            BodegaId = r.MprCodBod,
                            Estado = r.PrdFabSts,
                            Habilitar = r.PrdHabilit,
                            NuevoId = r.PrdFabNew,
                            CompaniaId = r.PrdCiaCod,
                            ProveedorId = r.PrdCodPrv,
                            ProveedorNombre = p.PrvNom,
                            Usuario = r.PrdPrvUsu
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Planta con Id: {plantaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / Get", exception);
            }
        }

        public static PlantaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.CORPLASet
                        join p in _context.PRVMSTSet on
                            r.PrdCodPrv equals p.PrvCod
                        select new PlantaBusiness
                        {
                            Id = r.PrdCorFab,
                            Iniciales = r.PrdCorIni,
                            Descripcion = r.PrdCorDes,
                            GeneraTicket = r.PrdCorTck,
                            Tipo = r.PrdCorTip,
                            BodegaId = r.MprCodBod,
                            Estado = r.PrdFabSts,
                            Habilitar = r.PrdHabilit,
                            NuevoId = r.PrdFabNew,
                            CompaniaId = r.PrdCiaCod,
                            ProveedorId = r.PrdCodPrv,
                            ProveedorNombre = p.PrvNom,
                            Usuario = r.PrdPrvUsu
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / GetAll", exception);
            }
        }

        public static PlantaBusiness[] GetExternas()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.CORPLASet
                        join p in _context.PRVMSTSet on
                            r.PrdCodPrv equals p.PrvCod
                        where r.PrdCodPrv != 0
                        select new PlantaBusiness
                        {
                            Id = r.PrdCorFab,
                            Iniciales = r.PrdCorIni,
                            Descripcion = r.PrdCorDes,
                            GeneraTicket = r.PrdCorTck,
                            Tipo = r.PrdCorTip,
                            BodegaId = r.MprCodBod,
                            Estado = r.PrdFabSts,
                            Habilitar = r.PrdHabilit,
                            NuevoId = r.PrdFabNew,
                            CompaniaId = r.PrdCiaCod,
                            ProveedorId = r.PrdCodPrv,
                            ProveedorNombre = p.PrvNom,
                            Usuario = r.PrdPrvUsu
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / GetExternas", exception);
            }
        }

        public static PlantaBusiness GetByUsuario(string usuario, string clave)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.CORPLASet
                        join p in _context.PRVMSTSet on
                            r.PrdCodPrv equals p.PrvCod
                        where r.PrdCorTip == "E" &&
                              r.PrdPrvUsu == usuario
                        select new PlantaBusiness
                        {
                            Id = r.PrdCorFab,
                            Iniciales = r.PrdCorIni,
                            Descripcion = r.PrdCorDes,
                            GeneraTicket = r.PrdCorTck,
                            Tipo = r.PrdCorTip,
                            BodegaId = r.MprCodBod,
                            Estado = r.PrdFabSts,
                            Habilitar = r.PrdHabilit,
                            NuevoId = r.PrdFabNew,
                            CompaniaId = r.PrdCiaCod,
                            ProveedorId = r.PrdCodPrv,
                            ProveedorNombre = p.PrvNom,
                            Usuario = r.PrdPrvUsu
                        }).FirstOrDefault();
                    if (model == null)
                    {
                        throw new Exception($"No se ha encontrado registro de Usuario: {usuario}");
                    }

                    //var claveDesencriptada = Tools.Desencriptar(clave);

                    //if (claveDesencriptada != model.Clave)
                    //{
                    //    throw new Exception($"La clave para el usuario: {usuario} es inválida.");
                    //}

                    return new PlantaBusiness
                    {
                        Id = model.Id,
                        Iniciales = model.Iniciales,
                        Descripcion = model.Descripcion,
                        Tipo = model.Tipo,
                        Estado = model.Estado,
                        Usuario = model.Usuario
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / GetByUsuario", exception);
            }
        }

        public static void UdpateClave(string plantaId, string claveOld, string claveNew)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = _context.CORPLASet.FirstOrDefault(r => r.PrdCorFab == plantaId);

                    if (reg == null)
                    {
                        throw new Exception($"No se ha encontrado registro para el código de planta: {plantaId}");
                    }

                    if (reg.PrdPrvCla != claveOld)
                    {
                        throw new Exception($"La clave del usuario no coincide");
                    }

                    reg.PrdPrvCla = claveNew;
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / UpdateClave", exception);
            }
        }

        #endregion
    }
}