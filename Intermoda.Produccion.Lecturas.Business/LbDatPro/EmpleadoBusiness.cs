using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Produccion.Lecturas.Business.LbDatPro
{
    [DataContract]
    public class EmpleadoBusiness
    {
        private static LBDATPROEntities _context;
        private const short Compania = 1;

        #region Properties

        [DataMember]
        public short CompaniaCodigo { get; set; }
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string Apellidos { get; set; }
        [DataMember]
        public string Alias { get; set; }
        [DataMember]
        public string Estado { get; set; }

        #endregion

        #region Methods

        public static EmpleadoBusiness Insert(EmpleadoBusiness model)
        {
            try
            {
                //using (_context = new LbDatProEntities())
                //{
                    //var reg = new MAEAR6
                    //{
                    //};
                    //_context.MAEAR6Set.Add(reg);
                    //_context.SaveChanges();

                    //model.Id = reg.Id;

                    //return model;
                //}

                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                throw new Exception("EmpleadoBusiness / Insert", exception);
            }
        }

        public static EmpleadoBusiness Update(EmpleadoBusiness model)
        {
            try
            {
                //using (_context = new LbDatProEntities())
                //{
                //    var reg = (from r in _context.MAEAR6Set
                //               where r.Id == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.SaveChanges();
                //        return model;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Empleado con Id: {model.Id}");
                //}

                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                throw new Exception("EmpleadoBusiness / Update", exception);
            }
        }

        public static void Delete(EmpleadoBusiness model)
        {
            try
            {
                //using (_context = new LbDatProEntities())
                //{
                //    var reg = (from r in _context.MAEAR6Set
                //               where r.Id == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.MAEAR6Set.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Empleado con Id: {model.Id}");
                //}

                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                throw new Exception("EmpleadoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int empleadoId)
        {
            try
            {
                //using (_context = new LbDatProEntities())
                //{
                //    var reg = (from r in _context.MAEAR6Set
                //               where r.Id == empleadoId
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.MAEAR6Set.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Empleado con Id: {empleadoId}");
                //}

                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                throw new Exception("EmpleadoBusiness / Delete (id)", exception);
            }
        }

        public static EmpleadoBusiness Get(short companiaCodigo, int empleadoCodigo)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.MAEAR6Set
                        where r.CIACOD == companiaCodigo &&
                              r.AdpCodEmp == empleadoCodigo
                        select new EmpleadoBusiness
                        {
                            CompaniaCodigo = r.CIACOD,
                            Codigo = r.AdpCodEmp,
                            Nombres = r.AdpNomEmp,
                            Apellidos = r.AdpAplEmp,
                            Alias = r.AdpAlias,
                            Estado = r.AdpStsEmp
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception(
                        $"No se ha encontrado registro de Empleado con Id: {companiaCodigo.ToString("000")}-{empleadoCodigo.ToString("000000")}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EmpleadoBusiness / Get", exception);
            }
        }

        public static EmpleadoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var lista = (from r in _context.MAEAR6Set
                            where r.CIACOD == Compania
                            select new EmpleadoBusiness
                            {
                                CompaniaCodigo = r.CIACOD,
                                Codigo = r.AdpCodEmp,
                                Nombres = r.AdpNomEmp,
                                Apellidos = r.AdpAplEmp,
                                Alias = r.AdpAlias,
                                Estado = r.AdpStsEmp
                            }).ToArray();
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EmpleadoBusiness / GetAll", exception);
            }
        }

        public static EmpleadoBusiness[] GetAllActivos()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var lista = (from r in _context.MAEAR6Set
                        where r.CIACOD == Compania &&
                              r.AdpStsEmp == "A" 
                        select new EmpleadoBusiness
                        {
                            CompaniaCodigo = r.CIACOD,
                            Codigo = r.AdpCodEmp,
                            Nombres = r.AdpNomEmp,
                            Apellidos = r.AdpAplEmp,
                            Alias = r.AdpAlias,
                            Estado = r.AdpStsEmp
                        }).ToArray();
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EmpleadoBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}