using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class InasistenciaBusiness
    {
        private static LBDATPROEntities _context;
        private const short Compania = 1;

        #region Properties

        [DataMember]
        public short CompaniaCodigo { get; set; }
        [DataMember]
        public int EmpleadoCodigo { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }
        [DataMember]
        public int MinutosConPermiso { get; set; }
        [DataMember]
        public int MinutosSinPermiso { get; set; }

        #endregion

        #region Methods

        public static InasistenciaBusiness[] GetByFecha(DateTime fecha)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var semana = (from r in _context.CNTPERIOSet
                        where r.CntPFei <= fecha && r.CntPFef >= fecha
                        select r).FirstOrDefault();
                    if (semana == null)
                        throw new Exception($"No existe semana definida para la fecha: {fecha}");

                    var dia = (fecha - semana.CntPFei).Days + 1;

                    var lista = from r in _context.MAEAUSSet
                        where r.CiaCod == Compania &&
                              r.PlsAnoSes == semana.CntPANO &&
                              r.PlsNumSes == semana.CntPSEM &&
                              r.PlsCodDia == dia
                        select new
                        {
                            CompaniaCodigo = r.CiaCod,
                            EmpleadoCodigo = r.AdpCodEmp,
                            FechaInicio = semana.CntPFei,
                            Dia = r.PlsCodDia,
                            Horas = r.PlsValTem,
                            ConPermiso = r.PlsCodCon == 2050
                        };

                    var retorno = new List<InasistenciaBusiness>();
                    foreach (var item in lista)
                    {
                        var minutos = Convert.ToInt32(decimal.Round(item.Horas.Value*60, 0));
                        retorno.Add(new InasistenciaBusiness
                        {
                            CompaniaCodigo = item.CompaniaCodigo,
                            EmpleadoCodigo = item.EmpleadoCodigo,
                            Fecha = fecha,
                            MinutosConPermiso = item.ConPermiso
                                ? minutos
                                : 0,
                            MinutosSinPermiso = item.ConPermiso
                                ? 0
                                : minutos
                        });

                    }

                    return retorno.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InasistenciaBusiness / GetFecha", exception);
            }
        }

        public static InasistenciaBusiness[] GetByFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var retorno = new List<InasistenciaBusiness>();

                    for (var fecha = fechaInicio; fecha <= fechaFinal; fecha = fecha.AddDays(1))
                    {
                        var semana = (from r in _context.CNTPERIOSet
                            where r.CntPFei <= fecha && r.CntPFef >= fecha
                            select r).FirstOrDefault();
                        if (semana == null)
                            throw new Exception($"No existe semana definida para la fecha: {fecha}");

                        var dia = (fecha - semana.CntPFei).Days + 1;

                        var lista = from r in _context.MAEAUSSet
                            where r.CiaCod == Compania &&
                                  r.PlsAnoSes == semana.CntPANO &&
                                  r.PlsNumSes == semana.CntPSEM &&
                                  r.PlsCodDia == dia
                            select new
                            {
                                CompaniaCodigo = r.CiaCod,
                                EmpleadoCodigo = r.AdpCodEmp,
                                FechaInicio = semana.CntPFei,
                                Dia = r.PlsCodDia,
                                Horas = r.PlsValTem,
                                ConPermiso = r.PlsCodCon == 2050
                            };

                        foreach (var item in lista)
                        {
                            var minutos = Convert.ToInt32(decimal.Round(item.Horas.Value*60, 0));
                            retorno.Add(new InasistenciaBusiness
                            {
                                CompaniaCodigo = item.CompaniaCodigo,
                                EmpleadoCodigo = item.EmpleadoCodigo,
                                Fecha = fecha,
                                MinutosConPermiso = item.ConPermiso
                                    ? minutos
                                    : 0,
                                MinutosSinPermiso = item.ConPermiso
                                    ? 0
                                    : minutos
                            });

                        }
                    }
                    return retorno.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InasistenciaBusiness / GetFecha", exception);
            }
        }

        public static InasistenciaBusiness[] GetByEmpleadoFecha(short companiaCodigo, int empleadoCodigo, DateTime fecha)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var semana = (from r in _context.CNTPERIOSet
                                  where r.CntPFei <= fecha && r.CntPFef >= fecha
                                  select r).FirstOrDefault();
                    if (semana == null)
                        throw new Exception($"No existe semana definida para la fecha: {fecha}");

                    var dia = (fecha - semana.CntPFei).Days + 1;

                    var lista = from r in _context.MAEAUSSet
                        where r.CiaCod == Compania &&
                              r.AdpCodEmp == empleadoCodigo &&
                              r.AdpCodEmp == empleadoCodigo &&
                              r.PlsAnoSes == semana.CntPANO &&
                              r.PlsNumSes == semana.CntPSEM &&
                              r.PlsCodDia == dia
                        select new
                        {
                            CompaniaCodigo = r.CiaCod,
                            EmpleadoCodigo = r.AdpCodEmp,
                            FechaInicio = semana.CntPFei,
                            Dia = r.PlsCodDia,
                            Horas = r.PlsValTem,
                            ConPermiso = r.PlsCodCon == 2050
                        };

                    var retorno = new List<InasistenciaBusiness>();
                    foreach (var item in lista)
                    {
                        var minutos = Convert.ToInt32(decimal.Round(item.Horas.Value * 60, 0));
                        retorno.Add(new InasistenciaBusiness
                        {
                            CompaniaCodigo = item.CompaniaCodigo,
                            EmpleadoCodigo = item.EmpleadoCodigo,
                            Fecha = fecha,
                            MinutosConPermiso = item.ConPermiso
                                ? minutos
                                : 0,
                            MinutosSinPermiso = item.ConPermiso
                                ? 0
                                : minutos
                        });

                    }

                    return retorno.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InasistenciaBusiness / GetFecha", exception);
            }
        }

        public static InasistenciaBusiness[] GetByEmpleadoFecha(short companiaCodigo, int empleadoCodigo, DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var retorno = new List<InasistenciaBusiness>();

                    for (var fecha = fechaInicio; fecha <= fechaFinal; fecha = fecha.AddDays(1))
                    {
                        var semana = (from r in _context.CNTPERIOSet
                            where r.CntPFei <= fecha && r.CntPFef >= fecha
                            select r).FirstOrDefault();
                        if (semana == null)
                            throw new Exception($"No existe semana definida para la fecha: {fecha}");

                        var dia = (fecha - semana.CntPFei).Days + 1;

                        var lista = from r in _context.MAEAUSSet
                            where r.CiaCod == Compania &&
                                  r.AdpCodEmp == empleadoCodigo &&
                                  r.PlsAnoSes == semana.CntPANO &&
                                  r.PlsNumSes == semana.CntPSEM &&
                                  r.PlsCodDia == dia
                            select new
                            {
                                CompaniaCodigo = r.CiaCod,
                                EmpleadoCodigo = r.AdpCodEmp,
                                FechaInicio = semana.CntPFei,
                                Dia = r.PlsCodDia,
                                Horas = r.PlsValTem,
                                ConPermiso = r.PlsCodCon == 2050
                            };

                        foreach (var item in lista)
                        {
                            var minutos = Convert.ToInt32(decimal.Round(item.Horas.Value*60, 0));
                            retorno.Add(new InasistenciaBusiness
                            {
                                CompaniaCodigo = item.CompaniaCodigo,
                                EmpleadoCodigo = item.EmpleadoCodigo,
                                Fecha = fecha,
                                MinutosConPermiso = item.ConPermiso
                                    ? minutos
                                    : 0,
                                MinutosSinPermiso = item.ConPermiso
                                    ? 0
                                    : minutos
                            });

                        }
                    }
                    return retorno.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InasistenciaBusiness / GetFecha", exception);
            }
        }

        #endregion
    }
}