using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Maquilado.Helpers;
using Microsoft.Practices.ServiceLocation;

namespace Intermoda.Maquilado.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataServiceLbDatPro, DesignDataServiceLbDatPro>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataServiceLbDatPro, DataServiceLbDatPro>();
            }

            SimpleIoc.Default.Register<IDialogService, DialogService>();

            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MessageWindowViewModel>();
        }

        public LoginViewModel LoginViewModel => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public MessageWindowViewModel MessageWindowViewModel
            => ServiceLocator.Current.GetInstance<MessageWindowViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}