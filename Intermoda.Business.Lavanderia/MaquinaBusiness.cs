using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Common.Enum;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class MaquinaBusiness
    {

        #region Properties

        [DataMember]
        public MaquinaTipo Tipo { get; set; }

        [DataMember]
        public short Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public short CapacidadId { get; set; }

        [DataMember]
        public string Marca { get; set; }

        [DataMember]
        public string Modelo { get; set; }

        [DataMember]
        public short Estado { get; set; }

        [DataMember]
        public string NumeroSerie { get; set; }

        [DataMember]
        public string DireccionIp { get; set; }

        [DataMember]
        public string DireccionMac { get; set; }

        // --

        [DataMember]
        public MaquinaCapacidadBusiness Capacidad { get; private set; }

        #endregion

        #region Methods

        public static MaquinaBusiness Insert(MaquinaBusiness model)
        {
            try
            {
                switch (model.Tipo)
                {
                    case MaquinaTipo.Lavadora:
                        var lavadoraModel = new LavadoraBusiness
                        {
                            Id = model.Id,
                            Nombre = model.Nombre,
                            LavadoraCapacidadId = model.CapacidadId,
                            Marca = model.Marca,
                            Modelo = model.Modelo,
                            Estado = model.Estado,
                            NumeroSerie = model.NumeroSerie,
                            DireccionIp = model.DireccionIp,
                            DireccionMac = model.DireccionMac
                        };
                        var lav = LavadoraBusiness.Insert(lavadoraModel);
                        return new MaquinaBusiness
                        {
                            Tipo = MaquinaTipo.Lavadora,
                            Id = lav.Id,
                            Nombre = lav.Nombre,
                            CapacidadId = lav.LavadoraCapacidadId,
                            Marca = lav.Marca,
                            Modelo = lav.Modelo,
                            Estado = lav.Estado,
                            NumeroSerie = lav.NumeroSerie,
                            DireccionIp = lav.DireccionIp,
                            DireccionMac = lav.DireccionMac,
                            Capacidad = new MaquinaCapacidadBusiness
                            {
                                Tipo = MaquinaTipo.Lavadora,
                                Id = lav.LavadoraCapacidad.Id,
                                CapacidadMinimaKg = lav.LavadoraCapacidad.CapacidadMinimaKg,
                                CapacidadMaximaKg = lav.LavadoraCapacidad.CapacidadMaximaKg,
                                CapacidadCanastaLitro = lav.LavadoraCapacidad.CapacidadCanastaLitro
                            }
                        };
                    case MaquinaTipo.Secadora:
                        var secadoraModel = new SecadoraBusiness
                        {
                            Id = model.Id,
                            Nombre = model.Nombre,
                            SecadoraCapacidadId = model.CapacidadId,
                            Marca = model.Marca,
                            Modelo = model.Modelo,
                            Estado = model.Estado,
                            NumeroSerie = model.NumeroSerie,
                            DireccionIp = model.DireccionIp,
                            DireccionMac = model.DireccionMac
                        };
                        var sec = SecadoraBusiness.Insert(secadoraModel);
                        return new MaquinaBusiness
                        {
                            Tipo = MaquinaTipo.Secadora,
                            Id = sec.Id,
                            Nombre = sec.Nombre,
                            CapacidadId = sec.SecadoraCapacidadId,
                            Marca = sec.Marca,
                            Modelo = sec.Modelo,
                            Estado = sec.Estado ?? 0,
                            NumeroSerie = sec.NumeroSerie,
                            DireccionIp = sec.DireccionIp,
                            DireccionMac = sec.DireccionMac,
                            Capacidad = new MaquinaCapacidadBusiness
                            {
                                Tipo = MaquinaTipo.Lavadora,
                                Id = sec.SecadoraCapacidad.Id,
                                CapacidadMinimaKg = sec.SecadoraCapacidad.CapacidadMinimaKg,
                                CapacidadMaximaKg = sec.SecadoraCapacidad.CapacidadMaximaKg
                            }
                        };
                    default:
                        throw new Exception("Tipo de Máquina es inválido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaBusiness / Insert", exception);
            }
        }

        public static MaquinaBusiness Update(MaquinaBusiness model)
        {
            try
            {
                switch (model.Tipo)
                {
                    case MaquinaTipo.Lavadora:
                        var lavadoraModel = new LavadoraBusiness
                        {
                            Id = model.Id,
                            Nombre = model.Nombre,
                            LavadoraCapacidadId = model.CapacidadId,
                            Marca = model.Marca,
                            Modelo = model.Modelo,
                            Estado = model.Estado,
                            NumeroSerie = model.NumeroSerie,
                            DireccionIp = model.DireccionIp,
                            DireccionMac = model.DireccionMac
                        };
                        var lav = LavadoraBusiness.Update(lavadoraModel);
                        return new MaquinaBusiness
                        {
                            Tipo = MaquinaTipo.Lavadora,
                            Id = lav.Id,
                            Nombre = lav.Nombre,
                            CapacidadId = lav.LavadoraCapacidadId,
                            Marca = lav.Marca,
                            Modelo = lav.Modelo,
                            Estado = lav.Estado,
                            NumeroSerie = lav.NumeroSerie,
                            DireccionIp = lav.DireccionIp,
                            DireccionMac = lav.DireccionMac,
                            Capacidad = new MaquinaCapacidadBusiness
                            {
                                Tipo = MaquinaTipo.Lavadora,
                                Id = lav.LavadoraCapacidad.Id,
                                CapacidadMinimaKg = lav.LavadoraCapacidad.CapacidadMinimaKg,
                                CapacidadMaximaKg = lav.LavadoraCapacidad.CapacidadMaximaKg,
                                CapacidadCanastaLitro = lav.LavadoraCapacidad.CapacidadCanastaLitro
                            }
                        };
                    case MaquinaTipo.Secadora:
                        var secadoraModel = new SecadoraBusiness
                        {
                            Id = model.Id,
                            Nombre = model.Nombre,
                            SecadoraCapacidadId = model.CapacidadId,
                            Marca = model.Marca,
                            Modelo = model.Modelo,
                            Estado = model.Estado,
                            NumeroSerie = model.NumeroSerie,
                            DireccionIp = model.DireccionIp,
                            DireccionMac = model.DireccionMac
                        };
                        var sec = SecadoraBusiness.Update(secadoraModel);
                        return new MaquinaBusiness
                        {
                            Tipo = MaquinaTipo.Secadora,
                            Id = sec.Id,
                            Nombre = sec.Nombre,
                            CapacidadId = sec.SecadoraCapacidadId,
                            Marca = sec.Marca,
                            Modelo = sec.Modelo,
                            Estado = sec.Estado ?? 0,
                            NumeroSerie = sec.NumeroSerie,
                            DireccionIp = sec.DireccionIp,
                            DireccionMac = sec.DireccionMac,
                            Capacidad = new MaquinaCapacidadBusiness
                            {
                                Tipo = MaquinaTipo.Lavadora,
                                Id = sec.SecadoraCapacidad.Id,
                                CapacidadMinimaKg = sec.SecadoraCapacidad.CapacidadMinimaKg,
                                CapacidadMaximaKg = sec.SecadoraCapacidad.CapacidadMaximaKg
                            }
                        };
                    default:
                        throw new Exception("Tipo de Máquina es inválido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaBusiness / Update", exception);
            }
        }

        public static void Delete(MaquinaBusiness model)
        {
            try
            {
                switch (model.Tipo)
                {
                    case MaquinaTipo.Lavadora:
                        LavadoraBusiness.Delete(model.Id);
                        return;
                    case MaquinaTipo.Secadora:
                        SecadoraBusiness.Delete(model.Id);
                        return;
                    default:
                        throw new Exception("Tipo de máquina es inválido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(MaquinaTipo tipo, int maquinaId)
        {
            try
            {
                switch (tipo)
                {
                    case MaquinaTipo.Lavadora:
                        LavadoraBusiness.Delete(maquinaId);
                        return;
                    case MaquinaTipo.Secadora:
                        SecadoraBusiness.Delete(maquinaId);
                        return;
                    default:
                        throw new Exception("Tipo de máquina es inválido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaBusiness / Delete (id)", exception);
            }
        }

        public static MaquinaBusiness Get(MaquinaTipo tipo, int maquinaId)
        {
            try
            {
                switch (tipo)
                {
                    case MaquinaTipo.Lavadora:
                        var lav = LavadoraBusiness.Get(maquinaId);
                        return new MaquinaBusiness
                        {
                            Tipo = tipo,
                            Id = lav.Id,
                            Nombre = lav.Nombre,
                            CapacidadId = lav.LavadoraCapacidadId,
                            Marca = lav.Marca,
                            Modelo = lav.Modelo,
                            Estado = lav.Estado,
                            NumeroSerie = lav.NumeroSerie,
                            DireccionIp = lav.DireccionIp,
                            DireccionMac = lav.DireccionMac,
                            Capacidad = new MaquinaCapacidadBusiness
                            {
                                Tipo = MaquinaTipo.Lavadora,
                                Id = lav.LavadoraCapacidad.Id,
                                CapacidadMinimaKg = lav.LavadoraCapacidad.CapacidadMinimaKg,
                                CapacidadMaximaKg = lav.LavadoraCapacidad.CapacidadMaximaKg,
                                CapacidadCanastaLitro = lav.LavadoraCapacidad.CapacidadCanastaLitro
                            }
                        };
                    case MaquinaTipo.Secadora:
                        var sec = SecadoraBusiness.Get(maquinaId);
                        return new MaquinaBusiness
                        {
                            Tipo = tipo,
                            Id = sec.Id,
                            Nombre = sec.Nombre,
                            CapacidadId = sec.SecadoraCapacidadId,
                            Marca = sec.Marca,
                            Modelo = sec.Modelo,
                            Estado = sec.Estado ?? 0,
                            NumeroSerie = sec.NumeroSerie,
                            DireccionIp = sec.DireccionIp,
                            DireccionMac = sec.DireccionMac,
                            Capacidad = new MaquinaCapacidadBusiness
                            {
                                Tipo = MaquinaTipo.Secadora,
                                Id = sec.SecadoraCapacidad.Id,
                                CapacidadMinimaKg = sec.SecadoraCapacidad.CapacidadMinimaKg,
                                CapacidadMaximaKg = sec.SecadoraCapacidad.CapacidadMaximaKg
                            }
                        };
                    default:
                        throw new Exception("Tipo de máquina es inválido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaBusiness / Get", exception);
            }
        }

        public static MaquinaBusiness[] GetAll()
        {
            try
            {
                var maquinas = new List<MaquinaBusiness>();
                var lavadoras = LavadoraBusiness.GetAll();
                maquinas.AddRange(lavadoras.Select(lav => new MaquinaBusiness
                {
                    Tipo = MaquinaTipo.Lavadora,
                    Id = lav.Id,
                    Nombre = lav.Nombre,
                    CapacidadId = lav.LavadoraCapacidadId,
                    Marca = lav.Marca,
                    Modelo = lav.Modelo,
                    Estado = lav.Estado,
                    NumeroSerie = lav.NumeroSerie,
                    DireccionIp = lav.DireccionIp,
                    DireccionMac = lav.DireccionMac,
                    Capacidad = new MaquinaCapacidadBusiness
                    {
                        Tipo = MaquinaTipo.Lavadora,
                        Id = lav.LavadoraCapacidad.Id,
                        CapacidadMinimaKg = lav.LavadoraCapacidad.CapacidadMinimaKg,
                        CapacidadMaximaKg = lav.LavadoraCapacidad.CapacidadMaximaKg,
                        CapacidadCanastaLitro = lav.LavadoraCapacidad.CapacidadCanastaLitro
                    }
                }).ToList());

                var secadoras = SecadoraBusiness.GetAll();
                maquinas.AddRange(secadoras.Select(sec => new MaquinaBusiness
                {
                    Tipo = MaquinaTipo.Secadora,
                    Id = sec.Id,
                    Nombre = sec.Nombre,
                    CapacidadId = sec.SecadoraCapacidadId,
                    Marca = sec.Marca,
                    Modelo = sec.Modelo,
                    Estado = sec.Estado ?? 0,
                    NumeroSerie = sec.NumeroSerie,
                    DireccionIp = sec.DireccionIp,
                    DireccionMac = sec.DireccionMac,
                    Capacidad = new MaquinaCapacidadBusiness
                    {
                        Tipo = MaquinaTipo.Secadora,
                        Id = sec.SecadoraCapacidad.Id,
                        CapacidadMinimaKg = sec.SecadoraCapacidad.CapacidadMinimaKg,
                        CapacidadMaximaKg = sec.SecadoraCapacidad.CapacidadMaximaKg
                    }
                }).ToList());

                return maquinas.ToArray();
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaBusiness / GetAll", exception);
            }
        }

        public static MaquinaBusiness[] GetByTipo(MaquinaTipo tipo)
        {
            try
            {
                switch (tipo)
                {
                    case MaquinaTipo.Lavadora:
                        var lavadoras = LavadoraBusiness.GetAll();
                        return lavadoras.Select(lav => new MaquinaBusiness
                        {
                            Tipo = tipo,
                            Id = lav.Id,
                            Nombre = lav.Nombre,
                            CapacidadId = lav.LavadoraCapacidadId,
                            Marca = lav.Marca,
                            Modelo = lav.Modelo,
                            Estado = lav.Estado,
                            NumeroSerie = lav.NumeroSerie,
                            DireccionIp = lav.DireccionIp,
                            DireccionMac = lav.DireccionMac,
                            Capacidad = new MaquinaCapacidadBusiness
                            {
                                Tipo = MaquinaTipo.Lavadora,
                                Id = lav.LavadoraCapacidad.Id,
                                CapacidadMinimaKg = lav.LavadoraCapacidad.CapacidadMinimaKg,
                                CapacidadMaximaKg = lav.LavadoraCapacidad.CapacidadMaximaKg,
                                CapacidadCanastaLitro = lav.LavadoraCapacidad.CapacidadCanastaLitro
                            }
                        }).ToArray();
                    case MaquinaTipo.Secadora:
                        var secadoras = SecadoraBusiness.GetAll();
                        return secadoras.Select(sec => new MaquinaBusiness
                        {
                            Tipo = tipo,
                            Id = sec.Id,
                            Nombre = sec.Nombre,
                            CapacidadId = sec.SecadoraCapacidadId,
                            Marca = sec.Marca,
                            Modelo = sec.Modelo,
                            Estado = sec.Estado ?? 0,
                            NumeroSerie = sec.NumeroSerie,
                            DireccionIp = sec.DireccionIp,
                            DireccionMac = sec.DireccionMac,
                            Capacidad = new MaquinaCapacidadBusiness
                            {
                                Tipo = MaquinaTipo.Secadora,
                                Id = sec.SecadoraCapacidad.Id,
                                CapacidadMinimaKg = sec.SecadoraCapacidad.CapacidadMinimaKg,
                                CapacidadMaximaKg = sec.SecadoraCapacidad.CapacidadMaximaKg
                            }
                        }).ToArray();
                    default:
                        throw new Exception("Tipo de máquina es inválido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaBusiness / GetByTipo", exception);
            }
        }

        public static MaquinaBusiness[] GetByTipoCapacidad(MaquinaTipo tipo, int capacidadId)
        {
            try
            {
                switch (tipo)
                {
                    case MaquinaTipo.Lavadora:
                        var lavadoras = LavadoraBusiness.GetByCapacidad(capacidadId);
                        return lavadoras.Select(lav => new MaquinaBusiness
                        {
                            Tipo = MaquinaTipo.Lavadora,
                            Id = lav.Id,
                            Nombre = lav.Nombre,
                            CapacidadId = lav.LavadoraCapacidadId,
                            Marca = lav.Marca,
                            Modelo = lav.Modelo,
                            Estado = lav.Estado,
                            NumeroSerie = lav.NumeroSerie,
                            DireccionIp = lav.DireccionIp,
                            DireccionMac = lav.DireccionMac,
                            Capacidad = new MaquinaCapacidadBusiness
                            {
                                Tipo = MaquinaTipo.Lavadora,
                                Id = lav.LavadoraCapacidad.Id,
                                CapacidadMinimaKg = lav.LavadoraCapacidad.CapacidadMinimaKg,
                                CapacidadMaximaKg = lav.LavadoraCapacidad.CapacidadMaximaKg,
                                CapacidadCanastaLitro = lav.LavadoraCapacidad.CapacidadCanastaLitro
                            }
                        }).ToArray();
                    case MaquinaTipo.Secadora:
                        var secadoras = SecadoraBusiness.GetByCapacidad(capacidadId);
                        return secadoras.Select(sec => new MaquinaBusiness
                        {
                            Tipo = MaquinaTipo.Secadora,
                            Id = sec.Id,
                            Nombre = sec.Nombre,
                            CapacidadId = sec.SecadoraCapacidadId,
                            Marca = sec.Marca,
                            Modelo = sec.Modelo,
                            Estado = sec.Estado ?? 0,
                            NumeroSerie = sec.NumeroSerie,
                            DireccionIp = sec.DireccionIp,
                            DireccionMac = sec.DireccionMac,
                            Capacidad = new MaquinaCapacidadBusiness
                            {
                                Tipo = MaquinaTipo.Secadora,
                                Id = sec.SecadoraCapacidad.Id,
                                CapacidadMinimaKg = sec.SecadoraCapacidad.CapacidadMinimaKg,
                                CapacidadMaximaKg = sec.SecadoraCapacidad.CapacidadMaximaKg
                            }
                        }).ToArray();
                    default:
                        throw new Exception("Tipo de máquina es inválido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaBusiness / GetByCapacidad", exception);
            }
        }

        #endregion
    }
}