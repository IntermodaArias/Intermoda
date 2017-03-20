using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Intermoda.Client.DataService.LecturaEnPlanta;
using Intermoda.Produccion.LecturaEnPlanta.Helpers;
using Microsoft.Practices.ServiceLocation;

namespace Intermoda.Produccion.LecturaEnPlanta.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataServiceLecturaPlanta, DesignDataServiceLecturaPlanta>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataServiceLecturaPlanta, DataServiceLecturaPlanta>();
            }

            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}