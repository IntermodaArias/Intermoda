using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Intermoda.Produccion.Lecturas.App.Helpers;
using Intermoda.Client.DataService.Ax;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Client.DataService.Lectura;
using Microsoft.Practices.ServiceLocation;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataServiceAx, DesignDataServiceAx>();
                SimpleIoc.Default.Register<IDataServiceLavanderia, DesignDataServiceLavanderia>();
                SimpleIoc.Default.Register<IDataServiceLbDatPro, DesignDataServiceLbDatPro>();
                SimpleIoc.Default.Register<IDataServiceLectura, DesignDataServiceLectura>();

                #region Dialogs

                SimpleIoc.Default.Register<MessageWindowViewModel>();

                #region Lecturas

                SimpleIoc.Default.Register<CentroTrabajoEditViewModel>();
                SimpleIoc.Default.Register<CentroTrabajoClasificacionEditViewModel>();
                SimpleIoc.Default.Register<GrupoEditViewModel>();
                SimpleIoc.Default.Register<GrupoCopiaSemanaViewModel>();
                SimpleIoc.Default.Register<JornadaEditViewModel>();
                SimpleIoc.Default.Register<JornadaDetalleEditViewModel>();
                SimpleIoc.Default.Register<LineaEditViewModel>();
                SimpleIoc.Default.Register<LineaDetalleEditViewModel>();
                SimpleIoc.Default.Register<ModuloEditViewModel>();
                SimpleIoc.Default.Register<TurnoEditViewModel>();
                SimpleIoc.Default.Register<TurnoDetalleEditViewModel>();

                #endregion
                
                #region Lavanderia

                SimpleIoc.Default.Register<LavanderiaCentroTrabajoEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaCentroTrabajoOpcionEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaColoresEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaIngredientePredefinidoEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaIngredienteInstruccionEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaInstruccionEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaInstruccionOperacionEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaInstruccionPredefinidaEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaLavadoraCapacidadEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaLavadoraEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaLavadoEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaObservacionOperacionEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaOpcionLavadoEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaOperacionEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaOperacionCentroTrabajoEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaOperacionObservacionEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaOperacionProcesoEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaProcesoCentroTrabajoEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaProcesoEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaSecadoraEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaSecadoraCapacidadEditViewModel>();
                SimpleIoc.Default.Register<LavanderiaTelaColorIntermodaEditViewModel>();

                #endregion

                #endregion
            }
            else
            {
                SimpleIoc.Default.Register<IDataServiceAx, DataServiceAx>();
                SimpleIoc.Default.Register<IDataServiceLavanderia, DataServiceLavanderia>();
                SimpleIoc.Default.Register<IDataServiceLbDatPro, DataServiceLbDatPro>();
                SimpleIoc.Default.Register<IDataServiceLectura, DataServiceLectura>();

                SimpleIoc.Default.Register<MessageWindowViewModel>();
            }

            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<MainViewModel>();

            #region Lecturas

            SimpleIoc.Default.Register<CentroTrabajoViewModel>();
            SimpleIoc.Default.Register<CentroTrabajoClasificacionViewModel>();
            SimpleIoc.Default.Register<GrupoViewModel>();
            SimpleIoc.Default.Register<JornadaViewModel>();
            SimpleIoc.Default.Register<JornadaDetalleViewModel>();
            SimpleIoc.Default.Register<LineaViewModel>();
            SimpleIoc.Default.Register<LineaDetalleViewModel>();
            SimpleIoc.Default.Register<ModuloViewModel>();
            SimpleIoc.Default.Register<TurnoViewModel>();
            SimpleIoc.Default.Register<TurnoDetalleViewModel>();

            #endregion
            
            #region Lavandería

            SimpleIoc.Default.Register<LavanderiaCentroTrabajoViewModel>();
            SimpleIoc.Default.Register<LavanderiaColoresViewModel>();
            SimpleIoc.Default.Register<LavanderiaIngredientePredefinidoViewModel>();
            SimpleIoc.Default.Register<LavanderiaOperacionInstruccionViewModel>();
            SimpleIoc.Default.Register<LavanderiaLavadoViewModel>();
            SimpleIoc.Default.Register<LavanderiaLavadoraViewModel>();
            SimpleIoc.Default.Register<LavanderiaLavadoraCapacidadViewModel>();
            SimpleIoc.Default.Register<LavanderiaOpcionLavadoViewModel>();
            SimpleIoc.Default.Register<LavanderiaOperacionViewModel>();
            SimpleIoc.Default.Register<LavanderiaOperacionCentroTrabajoViewModel>();
            SimpleIoc.Default.Register<LavanderiaOperacionObservacionViewModel>();
            SimpleIoc.Default.Register<LavanderiaOrdenProduccionViewModel>();
            SimpleIoc.Default.Register<LavanderiaProcesoViewModel>();
            SimpleIoc.Default.Register<LavanderiaLavadoRecetaViewModel>();
            SimpleIoc.Default.Register<LavanderiaSecadoraViewModel>();
            SimpleIoc.Default.Register<LavanderiaSecadoraCapacidadViewModel>();
            SimpleIoc.Default.Register<LavanderiaTelaColorViewModel>();

            #endregion

            SimpleIoc.Default.Register<ReportTestViewModel>();
        }

        #region Dialogs

        #region Lecturas

        public MessageWindowViewModel MessageWindowViewModel
            => ServiceLocator.Current.GetInstance<MessageWindowViewModel>();


        public CentroTrabajoEditViewModel CentroTrabajoEditViewModel
            => ServiceLocator.Current.GetInstance<CentroTrabajoEditViewModel>();

        public CentroTrabajoClasificacionEditViewModel CentroTrabajoClasificacionEditViewModel
            => ServiceLocator.Current.GetInstance<CentroTrabajoClasificacionEditViewModel>();

        public GrupoEditViewModel GrupoEditViewModel => ServiceLocator.Current.GetInstance<GrupoEditViewModel>();

        public GrupoCopiaSemanaViewModel GrupoCopiaSemanaViewModel
            => ServiceLocator.Current.GetInstance<GrupoCopiaSemanaViewModel>();

        public JornadaEditViewModel JornadaEditViewModel => ServiceLocator.Current.GetInstance<JornadaEditViewModel>();

        public JornadaDetalleEditViewModel JornadaDetalleEditViewModel
            => ServiceLocator.Current.GetInstance<JornadaDetalleEditViewModel>();

        public LineaEditViewModel LineaEditViewModel => ServiceLocator.Current.GetInstance<LineaEditViewModel>();

        public LineaDetalleEditViewModel LineaDetalleEditViewModel
            => ServiceLocator.Current.GetInstance<LineaDetalleEditViewModel>();

        public ModuloEditViewModel ModuloEditViewModel => ServiceLocator.Current.GetInstance<ModuloEditViewModel>();

        public TurnoEditViewModel TurnoEditViewModel => ServiceLocator.Current.GetInstance<TurnoEditViewModel>();

        public TurnoDetalleEditViewModel TurnoDetalleEditViewModel
            => ServiceLocator.Current.GetInstance<TurnoDetalleEditViewModel>();

        #endregion


        #region Lavanderia

        public LavanderiaCentroTrabajoEditViewModel LavanderiaCentroTrabajoEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaCentroTrabajoEditViewModel>();

        public LavanderiaCentroTrabajoOpcionEditViewModel LavanderiaCentroTrabajoOpcionEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaCentroTrabajoOpcionEditViewModel>();

        public LavanderiaColoresEditViewModel LavanderiaColoresEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaColoresEditViewModel>();

        public LavanderiaIngredientePredefinidoEditViewModel LavanderiaIngredientePredefinidoEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaIngredientePredefinidoEditViewModel>();

        public LavanderiaIngredienteInstruccionEditViewModel LavanderiaIngredienteInstruccionEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaIngredienteInstruccionEditViewModel>();

        public LavanderiaInstruccionEditViewModel LavanderiaInstruccionEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaInstruccionEditViewModel>();

        public LavanderiaInstruccionOperacionEditViewModel LavanderiaInstruccionOperacionEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaInstruccionOperacionEditViewModel>();

        public LavanderiaInstruccionPredefinidaEditViewModel LavanderiaInstruccionPredefinidaEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaInstruccionPredefinidaEditViewModel>();

        public LavanderiaLavadoraEditViewModel LavanderiaLavadoraEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaLavadoraEditViewModel>();

        public LavanderiaLavadoraCapacidadEditViewModel LavanderiaLavadoraCapacidadEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaLavadoraCapacidadEditViewModel>();

        public LavanderiaLavadoEditViewModel LavanderiaLavadoEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaLavadoEditViewModel>();

        public LavanderiaObservacionOperacionEditViewModel LavanderiaObservacionOperacionEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaObservacionOperacionEditViewModel>();

        public LavanderiaOpcionLavadoEditViewModel LavanderiaOpcionLavadoEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOpcionLavadoEditViewModel>();

        public LavanderiaProcesoCentroTrabajoEditViewModel LavanderiaProcesoCentroTrabajoEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaProcesoCentroTrabajoEditViewModel>();

        public LavanderiaProcesoEditViewModel LavanderiaProcesoEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaProcesoEditViewModel>();

        public LavanderiaOperacionEditViewModel LavanderiaOperacionEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOperacionEditViewModel>();

        public LavanderiaOperacionCentroTrabajoEditViewModel LavanderiaOperacionCentroTrabajoEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOperacionCentroTrabajoEditViewModel>();

        public LavanderiaOperacionObservacionEditViewModel LavanderiaOperacionObservacionEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOperacionObservacionEditViewModel>();

        public LavanderiaOperacionProcesoEditViewModel LavanderiaOperacionProcesoEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOperacionProcesoEditViewModel>();

        public LavanderiaSecadoraEditViewModel LavanderiaSecadoraEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaSecadoraEditViewModel>();

        public LavanderiaSecadoraCapacidadEditViewModel LavanderiaSecadoraCapacidadEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaSecadoraCapacidadEditViewModel>();

        public LavanderiaTelaColorIntermodaEditViewModel LavanderiaTelaColorIntermodaEditViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaTelaColorIntermodaEditViewModel>();

        #endregion

        #endregion

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        

        //


        #region Lecturas

        public CentroTrabajoViewModel CentroTrabajoViewModel
            => ServiceLocator.Current.GetInstance<CentroTrabajoViewModel>();

        public CentroTrabajoClasificacionViewModel CentroTrabajoClasificacionViewModel
            => ServiceLocator.Current.GetInstance<CentroTrabajoClasificacionViewModel>();

        public GrupoViewModel GrupoViewModel => ServiceLocator.Current.GetInstance<GrupoViewModel>();

        public JornadaViewModel JornadaViewModel => ServiceLocator.Current.GetInstance<JornadaViewModel>();

        public JornadaDetalleViewModel JornadaDetalleViewModel
            => ServiceLocator.Current.GetInstance<JornadaDetalleViewModel>();

        public LineaViewModel LineaViewModel => ServiceLocator.Current.GetInstance<LineaViewModel>();

        public LineaDetalleViewModel LineaDetalleViewModel
            => ServiceLocator.Current.GetInstance<LineaDetalleViewModel>();

        public ModuloViewModel ModuloViewModel => ServiceLocator.Current.GetInstance<ModuloViewModel>();

        public TurnoViewModel TurnoViewModel => ServiceLocator.Current.GetInstance<TurnoViewModel>();

        public TurnoDetalleViewModel TurnoDetalleViewModel
            => ServiceLocator.Current.GetInstance<TurnoDetalleViewModel>();

        #endregion
        
        #region Lavandería

        public LavanderiaCentroTrabajoViewModel LavanderiaCentroTrabajoViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaCentroTrabajoViewModel>();

        public LavanderiaColoresViewModel LavanderiaColoresViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaColoresViewModel>();

        public LavanderiaIngredientePredefinidoViewModel LavanderiaIngredientePredefinidoViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaIngredientePredefinidoViewModel>();

        public LavanderiaOperacionInstruccionViewModel LavanderiaOperacionInstruccionViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOperacionInstruccionViewModel>();

        public LavanderiaLavadoViewModel LavanderiaLavadoViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaLavadoViewModel>();

        public LavanderiaOpcionLavadoViewModel LavanderiaOpcionLavadoViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOpcionLavadoViewModel>();

        public LavanderiaLavadoraViewModel LavanderiaLavadoraViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaLavadoraViewModel>();

        public LavanderiaLavadoraCapacidadViewModel LavanderiaLavadoraCapacidadViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaLavadoraCapacidadViewModel>();

        public LavanderiaOperacionViewModel LavanderiaOperacionViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOperacionViewModel>();

        public LavanderiaOperacionCentroTrabajoViewModel LavanderiaOperacionCentroTrabajoViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOperacionCentroTrabajoViewModel>();

        public LavanderiaOperacionObservacionViewModel LavanderiaOperacionObservacionViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOperacionObservacionViewModel>();

        public LavanderiaOrdenProduccionViewModel LavanderiaOrdenProduccionViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaOrdenProduccionViewModel>();

        public LavanderiaProcesoViewModel LavanderiaProcesoViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaProcesoViewModel>();

        public LavanderiaLavadoRecetaViewModel LavanderiaLavadoRecetaViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaLavadoRecetaViewModel>();

        public LavanderiaSecadoraCapacidadViewModel LavanderiaSecadoraCapacidadViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaSecadoraCapacidadViewModel>();

        public LavanderiaSecadoraViewModel LavanderiaSecadoraViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaSecadoraViewModel>();

        public LavanderiaTelaColorViewModel LavanderiaTelaColorViewModel
            => ServiceLocator.Current.GetInstance<LavanderiaTelaColorViewModel>();

        #endregion

        public ReportTestViewModel ReportTestViewModel => ServiceLocator.Current.GetInstance<ReportTestViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}