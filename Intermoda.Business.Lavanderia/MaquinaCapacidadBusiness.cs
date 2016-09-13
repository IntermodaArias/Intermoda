using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Common.Enum;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class MaquinaCapacidadBusiness
    {
        #region Properties

        [DataMember]
        public MaquinaTipo Tipo { get; set; }

        [DataMember]
        public short Id { get; set; }

        [DataMember]
        public decimal CapacidadMaximaKg { get; set; }

        [DataMember]
        public decimal? CapacidadMinimaKg { get; set; }

        [DataMember]
        public decimal? CapacidadCanastaLitro { get; set; }

        #endregion

        #region Methods

        public static MaquinaCapacidadBusiness Insert(MaquinaCapacidadBusiness model)
        {
            try
            {
                switch (model.Tipo)
                {
                    case MaquinaTipo.Lavadora:
                        var lav = new LavadoraCapacidadBusiness
                        {
                            Id = model.Id,
                            CapacidadMinimaKg = model.CapacidadMinimaKg,
                            CapacidadMaximaKg = model.CapacidadMaximaKg,
                            CapacidadCanastaLitro = model.CapacidadCanastaLitro
                        };
                        lav = LavadoraCapacidadBusiness.Insert(lav);
                        model.Id = lav.Id;
                        return model;
                    case MaquinaTipo.Secadora:
                        var sec = new SecadoraCapacidadBusiness
                        {
                            Id = model.Id,
                            CapacidadMinimaKg = model.CapacidadMinimaKg ?? 0,
                            CapacidadMaximaKg = model.CapacidadMaximaKg
                        };
                        sec = SecadoraCapacidadBusiness.Insert(sec);
                        model.Id = sec.Id;
                        return model;
                    default:
                        throw new Exception("Error Tipo de Máquina no definido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / Insert", exception);
            }
        }

        public static MaquinaCapacidadBusiness Update(MaquinaCapacidadBusiness model)
        {
            try
            {
                switch (model.Tipo)
                {
                    case MaquinaTipo.Lavadora:
                        var lav = new LavadoraCapacidadBusiness
                        {
                            Id = model.Id,
                            CapacidadMinimaKg = model.CapacidadMinimaKg,
                            CapacidadMaximaKg = model.CapacidadMaximaKg,
                            CapacidadCanastaLitro = model.CapacidadCanastaLitro
                        };
                        lav = LavadoraCapacidadBusiness.Update(lav);
                        return model;
                    case MaquinaTipo.Secadora:
                        var sec = new SecadoraCapacidadBusiness
                        {
                            Id = model.Id,
                            CapacidadMinimaKg = model.CapacidadMinimaKg ?? 0,
                            CapacidadMaximaKg = model.CapacidadMaximaKg
                        };
                        sec = SecadoraCapacidadBusiness.Update(sec);
                        return model;
                    default:
                        throw new Exception("Error Tipo de Máquina no definido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / Update", exception);
            }
        }

        public static void Delete(MaquinaTipo tipo, int capacidadId)
        {
            try
            {
                switch (tipo)
                {
                    case MaquinaTipo.Lavadora:
                        LavadoraBusiness.Delete(capacidadId);
                        return;
                    case MaquinaTipo.Secadora:
                        SecadoraBusiness.Delete(capacidadId);
                        return;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / Delete (model)", exception);
            }
        }
        
        public static void Delete(MaquinaCapacidadBusiness model)
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
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / Delete (model)", exception);
            }
        }

        public static MaquinaCapacidadBusiness Get(MaquinaTipo tipo, int capacidadId)
        {
            try
            {
                switch (tipo)
                {
                    case MaquinaTipo.Lavadora:
                        var lav = LavadoraCapacidadBusiness.Get(capacidadId);
                        return new MaquinaCapacidadBusiness
                        {
                            Id = lav.Id,
                            CapacidadMinimaKg = lav.CapacidadMinimaKg,
                            CapacidadMaximaKg = lav.CapacidadMaximaKg,
                            CapacidadCanastaLitro = lav.CapacidadCanastaLitro,
                            Tipo = tipo
                        };
                    case MaquinaTipo.Secadora:
                        var sec = SecadoraCapacidadBusiness.Get(capacidadId);
                        return new MaquinaCapacidadBusiness
                        {
                            Id = sec.Id,
                            CapacidadMinimaKg = sec.CapacidadMinimaKg,
                            CapacidadMaximaKg = sec.CapacidadMaximaKg,
                            Tipo = tipo
                        };
                    default:
                        throw new Exception("Tipo de máquina es inválido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / Get", exception);
            }
        }

        public static MaquinaCapacidadBusiness[] GetAll()
        {
            try
            {
                var maquinaCapacidad = new List<MaquinaCapacidadBusiness>();

                var lav = LavadoraCapacidadBusiness.GetAll();
                maquinaCapacidad.AddRange(lav.Select(r => new MaquinaCapacidadBusiness
                {
                    Id = r.Id,
                    CapacidadMinimaKg = r.CapacidadMinimaKg,
                    CapacidadMaximaKg = r.CapacidadMaximaKg,
                    CapacidadCanastaLitro = r.CapacidadCanastaLitro,
                    Tipo = MaquinaTipo.Lavadora
                }).ToList());

                var sec = SecadoraCapacidadBusiness.GetAll();
                maquinaCapacidad.AddRange(sec.Select(r => new MaquinaCapacidadBusiness
                {
                    Id = r.Id,
                    CapacidadMinimaKg = r.CapacidadMinimaKg,
                    CapacidadMaximaKg = r.CapacidadMaximaKg,
                    Tipo = MaquinaTipo.Secadora
                }).ToList());

                return maquinaCapacidad.ToArray();
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / GetAll", exception);
            }
        }

        public static MaquinaCapacidadBusiness[] GetByTipo(MaquinaTipo tipo)
        {
            try
            {
                switch (tipo)
                {
                    case MaquinaTipo.Lavadora:
                        var lav = LavadoraCapacidadBusiness.GetAll();
                        return lav.Select(r => new MaquinaCapacidadBusiness
                        {
                            Id = r.Id,
                            CapacidadMinimaKg = r.CapacidadMinimaKg,
                            CapacidadMaximaKg = r.CapacidadMaximaKg,
                            CapacidadCanastaLitro = r.CapacidadCanastaLitro,
                            Tipo = tipo
                        }).ToArray();
                    case MaquinaTipo.Secadora:
                        var sec = SecadoraCapacidadBusiness.GetAll();
                        return sec.Select(r => new MaquinaCapacidadBusiness
                        {
                            Id = r.Id,
                            CapacidadMinimaKg = r.CapacidadMinimaKg,
                            CapacidadMaximaKg = r.CapacidadMaximaKg,
                            Tipo = tipo
                        }).ToArray();
                    default:
                        throw new Exception("Tipo de máquina es inválido");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / GetByTipo", exception);
            }
        }

        #endregion 
    }
}