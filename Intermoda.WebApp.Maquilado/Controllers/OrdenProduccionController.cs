using System.Collections.Generic;
using AutoMapper;
using Intermoda.Business.LbDatPro;
using Intermoda.WebApp.Maquilado.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Intermoda.WebApp.Maquilado.Controllers
{
    public class OrdenProduccionController : Controller
    {
        // GET: OrdenProduccion
        public ActionResult Index()
        {
            var ordenes = OrdenProduccionExternoBusiness.GetByUsuarioPlanta("arias");

            return View(Mapper.Map<IEnumerable<OrdenProduccionExternoViewModel>>(ordenes));
        }
    }
}