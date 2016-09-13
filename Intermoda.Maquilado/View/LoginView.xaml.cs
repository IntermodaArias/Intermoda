using System;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Intermoda.Client.LbDatPro;
using Intermoda.Common;
using Intermoda.Maquilado.Helpers;
using Intermoda.Maquilado.Messages;

namespace Intermoda.Maquilado.View
{
    public partial class LoginView 
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                ((dynamic) DataContext).Clave = ((PasswordBox) sender).SecurePassword;
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var planta = Planta.GetByUsuario(Usuario.Text, Clave.Password);

                Messenger.Default.Send(new LoginMessage { Planta = planta });

                Close();
            }
            catch (Exception exception)
            {
                var msg = Tools.ExceptionMessage(exception);
                MessageBox.Show(msg, "ERROR!");
            }
        }
    }
}
