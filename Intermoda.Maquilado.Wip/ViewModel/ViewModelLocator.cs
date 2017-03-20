using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Maquilado.Wip.Helpers;
using Microsoft.Practices.ServiceLocation;

namespace Intermoda.Maquilado.Wip.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<IDataServiceLbDatPro, DesignDataServiceLbDatPro>();
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<IDataServiceLbDatPro, DataServiceLbDatPro>();
            }

            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<Main2ViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public Main2ViewModel Main2 => ServiceLocator.Current.GetInstance<Main2ViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}