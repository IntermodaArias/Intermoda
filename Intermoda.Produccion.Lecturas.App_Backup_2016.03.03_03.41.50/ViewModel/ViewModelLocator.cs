using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Intermoda.Produccion.Lecturas.App.Helpers;
using Intermoda.Produccion.Lecturas.Client.DataServices;
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
                SimpleIoc.Default.Register<IDataService, DesignDataService>();

                #region Dialogs

                SimpleIoc.Default.Register<MessageWindowViewModel>();
                SimpleIoc.Default.Register<CentroTrabajoEditViewModel>();
                SimpleIoc.Default.Register<CentroTrabajoClasificacionEditViewModel>();
                SimpleIoc.Default.Register<GrupoEditViewModel>();
                SimpleIoc.Default.Register<LineaEditViewModel>();
                SimpleIoc.Default.Register<LineaDetalleEditViewModel>();
                SimpleIoc.Default.Register<ModuloEditViewModel>();

                #endregion
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<MainViewModel>();

            SimpleIoc.Default.Register<CentroTrabajoViewModel>();
            SimpleIoc.Default.Register<CentroTrabajoClasificacionViewModel>();
            SimpleIoc.Default.Register<GrupoViewModel>();
            SimpleIoc.Default.Register<LineaViewModel>();
            SimpleIoc.Default.Register<LineaDetalleViewModel>();
            SimpleIoc.Default.Register<ModuloViewModel>();
            
        }

        #region Dialogs

        public MessageWindowViewModel MessageWindowViewModel
            => ServiceLocator.Current.GetInstance<MessageWindowViewModel>();


        public CentroTrabajoEditViewModel CentroTrabajoEditViewModel
            => ServiceLocator.Current.GetInstance<CentroTrabajoEditViewModel>();

        public CentroTrabajoClasificacionEditViewModel CentroTrabajoClasificacionEditViewModel
            => ServiceLocator.Current.GetInstance<CentroTrabajoClasificacionEditViewModel>();

        public GrupoEditViewModel GrupoEditViewModel => ServiceLocator.Current.GetInstance<GrupoEditViewModel>();

        public LineaEditViewModel LineaEditViewModel => ServiceLocator.Current.GetInstance<LineaEditViewModel>();

        public LineaDetalleEditViewModel LineaDetalleEditViewModel
            => ServiceLocator.Current.GetInstance<LineaDetalleEditViewModel>();

        public ModuloEditViewModel ModuloEditViewModel => ServiceLocator.Current.GetInstance<ModuloEditViewModel>();

        #endregion

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();


        public CentroTrabajoViewModel CentroTrabajoViewModel
            => ServiceLocator.Current.GetInstance<CentroTrabajoViewModel>();

        public CentroTrabajoClasificacionViewModel CentroTrabajoClasificacionViewModel
            => ServiceLocator.Current.GetInstance<CentroTrabajoClasificacionViewModel>();

        public GrupoViewModel GrupoViewModel => ServiceLocator.Current.GetInstance<GrupoViewModel>();

        public LineaViewModel LineaViewModel => ServiceLocator.Current.GetInstance<LineaViewModel>();

        public LineaDetalleViewModel LineaDetalleViewModel
            => ServiceLocator.Current.GetInstance<LineaDetalleViewModel>();

        public ModuloViewModel ModuloViewModel => ServiceLocator.Current.GetInstance<ModuloViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}