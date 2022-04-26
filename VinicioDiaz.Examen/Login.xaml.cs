using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VinicioDiaz.Examen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrEmpty(usuario))
            {
                DisplayAlert("Inicio de sesión", "Ingrese usuario", "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(contrasena))
            {
                DisplayAlert("Inicio de sesión", "Ingrese contraseña", "Aceptar");
                return;
            }

            if ("estudiante2021".Equals(usuario) && "uisrael2021".Equals(contrasena))
            {
                await Navigation.PushAsync(new Registro(usuario));
            }
            else
            {
                DisplayAlert("Inicio de sesión", "Usuario o contraseña incorrecto", "Aceptar");
            }
        }
    }
}