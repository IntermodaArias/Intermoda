using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class OpcionLavadoOrdenBusiness
    {
        private static LavanderiaEntities _context;

        private const short CompaniaCodigo = 1;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int? LavadoId { get; set; }

        [DataMember]
        public string TelaId { get; set; }

        [DataMember]
        public int? IsDefault { get; set; }

        [DataMember]
        public int CompaniaId { get; set; }

        [DataMember]
        public int PlantaId { get; set; }

        [DataMember]
        public int OrdenAno { get; set; }

        [DataMember]
        public int OrdenNumero { get; set; }


        #endregion

        #region Methods

        public static OpcionLavadoOrdenBusiness Insert(OpcionLavadoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new OpcionLavadoOrden()
                    {
                        OpcionLavadoOrdenId = model.Id,
                        OpcionLavadoOrdenNombre = model.Nombre,
                        OpcionLavadoOrdenDescripcion = model.Descripcion,
                        OpcionLavadoOrdenLavadoId = model.LavadoId,
                        OpcionLavadoOrdenTelaId = model.TelaId,
                        OpcionLavadoOrdenIsDefault = model.IsDefault,
                        OpcionLavadoOrdenCompaniaId = model.CompaniaId,
                        OpcionLavadoOrdenPlantaId = model.PlantaId,
                        OpcionLavadoOrdenAnio = model.OrdenAno,
                        OpcionLavadoOrdenNumeroOrden = model.OrdenNumero
                    };
                    _context.OpcionLavadoOrdenSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.OpcionLavadoOrdenId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoOrdenBusiness / Insert", exception);
            }
        }

        public static OpcionLavadoOrdenBusiness Update(OpcionLavadoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OpcionLavadoOrdenSet
                               where r.OpcionLavadoOrdenId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.OpcionLavadoOrdenId = model.Id;
                        reg.OpcionLavadoOrdenNombre = model.Nombre;
                        reg.OpcionLavadoOrdenDescripcion = model.Descripcion;
                        reg.OpcionLavadoOrdenLavadoId = model.LavadoId;
                        reg.OpcionLavadoOrdenTelaId = model.TelaId;
                        reg.OpcionLavadoOrdenIsDefault = model.IsDefault;
                        reg.OpcionLavadoOrdenCompaniaId = model.CompaniaId;
                        reg.OpcionLavadoOrdenPlantaId = model.PlantaId;
                        reg.OpcionLavadoOrdenAnio = model.OrdenAno;
                        reg.OpcionLavadoOrdenNumeroOrden = model.OrdenNumero;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OpcionLavadoOrden con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoOrdenBusiness / Update", exception);
            }
        }

        public static void Delete(OpcionLavadoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OpcionLavadoOrdenSet
                               where r.OpcionLavadoOrdenId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OpcionLavadoOrdenSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OpcionLavadoOrden con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoOrdenBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int opcionLavadoOrdenId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OpcionLavadoOrdenSet
                               where r.OpcionLavadoOrdenId == opcionLavadoOrdenId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OpcionLavadoOrdenSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OpcionLavadoOrden con Id: {opcionLavadoOrdenId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoOrdenBusiness / Delete (id)", exception);
            }
        }

        public static OpcionLavadoOrdenBusiness Get(int opcionLavadoOrdenId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.OpcionLavadoOrdenSet
                                 where r.OpcionLavadoOrdenId == opcionLavadoOrdenId
                                 select new OpcionLavadoOrdenBusiness
                                 {
                                     Id = r.OpcionLavadoOrdenId,
                                     Nombre = r.OpcionLavadoOrdenNombre,
                                     Descripcion = r.OpcionLavadoOrdenDescripcion,
                                     LavadoId = r.OpcionLavadoOrdenLavadoId,
                                     TelaId = r.OpcionLavadoOrdenTelaId,
                                     IsDefault = r.OpcionLavadoOrdenIsDefault,
                                     CompaniaId = r.OpcionLavadoOrdenCompaniaId,
                                     PlantaId = r.OpcionLavadoOrdenPlantaId,
                                     OrdenAno = r.OpcionLavadoOrdenAnio,
                                     OrdenNumero = r.OpcionLavadoOrdenNumeroOrden
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OpcionLavadoOrden con Id: {opcionLavadoOrdenId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoOrdenBusiness / Get", exception);
            }
        }

        public static OpcionLavadoOrdenBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.OpcionLavadoOrdenSet
                            select new OpcionLavadoOrdenBusiness
                            {
                                Id = r.OpcionLavadoOrdenId,
                                Nombre = r.OpcionLavadoOrdenNombre,
                                Descripcion = r.OpcionLavadoOrdenDescripcion,
                                LavadoId = r.OpcionLavadoOrdenLavadoId,
                                TelaId = r.OpcionLavadoOrdenTelaId,
                                IsDefault = r.OpcionLavadoOrdenIsDefault,
                                CompaniaId = r.OpcionLavadoOrdenCompaniaId,
                                PlantaId = r.OpcionLavadoOrdenPlantaId,
                                OrdenAno = r.OpcionLavadoOrdenAnio,
                                OrdenNumero = r.OpcionLavadoOrdenNumeroOrden
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoOrdenBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}