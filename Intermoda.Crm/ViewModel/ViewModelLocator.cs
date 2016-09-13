using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Intermoda.Client.DataService.Crm;
using Microsoft.Practices.ServiceLocation;

namespace Intermoda.Crm.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IAcuerdoComercialDataService, AcuerdoComercialDesignDataService>();
                SimpleIoc.Default.Register<IAcuerdoComercialDetalleDataService, AcuerdoComercialDetalleDesignDataService>();
                SimpleIoc.Default.Register<IAsesorDataService, AsesorDesignDataService>();
                SimpleIoc.Default.Register<IAsesorRutaDataService, AsesorRutaDesignDataService>();
                SimpleIoc.Default.Register<ICaiDataService, CaiDesignDataService>();
                SimpleIoc.Default.Register<ICarteraDocumentoDataService, CarteraDocumentoDesignDataService>();
                SimpleIoc.Default.Register<ICarteraDocumentoDetalleAplicacionDataService, CarteraDocumentoDetalleAplicacionDataService>();
                SimpleIoc.Default.Register<ICarteraDocumentoDetallePagoDataService, CarteraDocumentoDetallePagoDesignDataService>();
                SimpleIoc.Default.Register<ICarteraDocumentoDetalleProductoDataService, CarteraDocumentoDetalleProductoDesignDataService>();
                SimpleIoc.Default.Register<ICarteraDocumentoTipoDataService, CarteraDocumentoTipoDesignDataService>();
                SimpleIoc.Default.Register<ICiudadDataService, CiudadDesignDataService>();
                SimpleIoc.Default.Register<IClienteDataService, ClienteDesignDataService>();
                SimpleIoc.Default.Register<IEdadDataService, EdadDesignDataService>();
                SimpleIoc.Default.Register<IEmpresaDataService, EmpresaDesignDataService>();
                SimpleIoc.Default.Register<IGrupoEconomicoDataService, GrupoEconomicoDesignDataService>();
                SimpleIoc.Default.Register<IInventarioFisicoDataService, InventarioFisicoDesignDataService>();
                SimpleIoc.Default.Register<IInventarioFisicoDetalleDataService, InventarioFisicoDetalleDesignDataService>();
                SimpleIoc.Default.Register<IInventarioTrasladoDataService, InventarioTrasladoDesignDataService>();
                SimpleIoc.Default.Register<IInventarioTrasladoDetalleDataService, InventarioTrasladoDetalleDesignDataService>();
                SimpleIoc.Default.Register<IMonedaDataService, MonedaDesignDataService>();
                SimpleIoc.Default.Register<IPagoTipoDataService, PagoTipoDesignDataService>();
                SimpleIoc.Default.Register<IPaqueteDataService, PaqueteDesignDataService>();
                SimpleIoc.Default.Register<IPaqueteDetalleDataService, PaqueteDetalleDesignDataService>();
                SimpleIoc.Default.Register<IPedidoTipoDataService, PedidoTipoDesignDataService>();
                SimpleIoc.Default.Register<IProductoDataService, ProductoDesignDataService>();
                SimpleIoc.Default.Register<IProductoCategoriaDataService, ProductoCategoriaDesignDataService>();
                SimpleIoc.Default.Register<IProductoImagenDataService, ProductoImagenDesignDataService>();
                SimpleIoc.Default.Register<IRutaDataService, RutaDesignDataService>();
                SimpleIoc.Default.Register<ISupervisorDataService, SupervisorDesignDataService>();
                SimpleIoc.Default.Register<ISupervisorZonaDataService, SupervisorZonaDesignDataService>();
                SimpleIoc.Default.Register<IUsuarioDataService, UsuarioDesignDataService>();
                SimpleIoc.Default.Register<IZonaDataService, ZonaDesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IAcuerdoComercialDataService, AcuerdoComercialDataService>();
                SimpleIoc.Default.Register<IAcuerdoComercialDetalleDataService, AcuerdoComercialDetalleDataService>();
                SimpleIoc.Default.Register<IAsesorDataService, AsesorDataService>();
                SimpleIoc.Default.Register<IAsesorRutaDataService, AsesorRutaDataService>();
                SimpleIoc.Default.Register<ICaiDataService, CaiDataService>();
                SimpleIoc.Default.Register<ICarteraDocumentoDataService, CarteraDocumentoDataService>();
                SimpleIoc.Default.Register<ICarteraDocumentoDetalleAplicacionDataService, CarteraDocumentoDetalleAplicacionDataService>();
                SimpleIoc.Default.Register<ICarteraDocumentoDetallePagoDataService, CarteraDocumentoDetallePagoDataService>();
                SimpleIoc.Default.Register<ICarteraDocumentoDetalleProductoDataService, CarteraDocumentoDetalleProductoDataService>();
                SimpleIoc.Default.Register<ICarteraDocumentoTipoDataService, CarteraDocumentoTipoDataService>();
                SimpleIoc.Default.Register<ICiudadDataService, CiudadDataService>();
                SimpleIoc.Default.Register<IClienteDataService, ClienteDataService>();
                SimpleIoc.Default.Register<IEdadDataService, EdadDataService>();
                SimpleIoc.Default.Register<IEmpresaDataService, EmpresaDataService>();
                SimpleIoc.Default.Register<IGrupoEconomicoDataService, GrupoEconomicoDataService>();
                SimpleIoc.Default.Register<IInventarioFisicoDataService, InventarioFisicoDataService>();
                SimpleIoc.Default.Register<IInventarioFisicoDetalleDataService, InventarioFisicoDetalleDataService>();
                SimpleIoc.Default.Register<IInventarioTrasladoDataService, InventarioTrasladoDataService>();
                SimpleIoc.Default.Register<IInventarioTrasladoDetalleDataService, InventarioTrasladoDetalleDataService>();
                SimpleIoc.Default.Register<IMonedaDataService, MonedaDataService>();
                SimpleIoc.Default.Register<IPagoTipoDataService, PagoTipoDataService>();
                SimpleIoc.Default.Register<IPaqueteDataService, PaqueteDataService>();
                SimpleIoc.Default.Register<IPaqueteDetalleDataService, PaqueteDetalleDataService>();
                SimpleIoc.Default.Register<IPedidoTipoDataService, PedidoTipoDataService>();
                SimpleIoc.Default.Register<IProductoDataService, ProductoDataService>();
                SimpleIoc.Default.Register<IProductoCategoriaDataService, ProductoCategoriaDataService>();
                SimpleIoc.Default.Register<IProductoImagenDataService, ProductoImagenDataService>();
                SimpleIoc.Default.Register<IRutaDataService, RutaDataService>();
                SimpleIoc.Default.Register<ISupervisorDataService, SupervisorDataService>();
                SimpleIoc.Default.Register<ISupervisorZonaDataService, SupervisorZonaDataService>();
                SimpleIoc.Default.Register<IUsuarioDataService, UsuarioDataService>();
                SimpleIoc.Default.Register<IZonaDataService, ZonaDataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<TestViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public TestViewModel Test => ServiceLocator.Current.GetInstance<TestViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}