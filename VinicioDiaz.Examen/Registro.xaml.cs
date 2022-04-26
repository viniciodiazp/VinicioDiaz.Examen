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
    public partial class Registro : ContentPage
    {
        private double saldo;
        private double interes;
        private double cuota;
        private double total;
        private double pagoInicial;
        private String usuarioConectado;
        private Boolean calculado = false;

        public Registro(string usuario)
        {
            InitializeComponent();
            this.usuarioConectado = usuario;
            lblUsuarioConectado.Text = string.Format("Usuario conectado: {0}", usuario);
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateNullOrEmpty(sender, "Digite nombre");
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateNullOrEmpty(sender, "Digite correo");
        }

        private void txtTotal_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateNullOrEmpty(sender, "Digite total");
        }

        private void txtPagoInicial_TextChanged(object sender, TextChangedEventArgs e)
        {
            validateNullOrEmpty(sender, "Digite pago inicial");
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            total = getValue(txtTotal);
            pagoInicial = getValue(txtPagoInicial);

            if (total <=0 || pagoInicial <=0)
            {
                DisplayAlert("Error", "Ingrese valor de curso y/o pago inicial", "Aceptar");
                return;
            }

            if (pagoInicial > total)
            {
                DisplayAlert("Error", "El pago no puede ser mayor que el total", "Aceptar");
                return;
            }

            saldo = total - pagoInicial;
            interes = total * 0.05;
            cuota = 0;

            if (saldo > 0)
            {
                cuota = (saldo / 3) + interes; 
            }

            txtCuota.Text = cuota.ToString();
            this.calculado = true;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (this.calculado)
            {
                Dictionary<string, double> resumen = new Dictionary<string, double>();
                resumen.Add("total", this.total);
                resumen.Add("saldo", this.saldo);
                resumen.Add("cuota", this.cuota);
                resumen.Add("pagoInicial", this.pagoInicial);

                DisplayAlert("Info", "Elemento guardado con éxito", "Aceptar");
                await Navigation.PushAsync(new Resumen(this.usuarioConectado, resumen, txtNombre.Text));
            } else
            {
                DisplayAlert("Error", "Aún no se ha calculado los valores, presione calcular antes de continuar", "Aceptar");
            }
        }

        private void validateNullOrEmpty(object sender, String message)
        {
            Entry entry = ((Entry)sender);
            if (String.IsNullOrEmpty(entry.Text))
            {
                DisplayAlert("Error", message, "Aceptar");
                entry.Focus();
            }
        }

        private void validateNullOrEmpty2(object sender, String message)
        {
            Entry entry = ((Entry)sender);
            if (!String.IsNullOrEmpty(entry.Text))
            {
                double value = Convert.ToDouble(entry.Text);
                if (value < 0 || value > 10)
                {
                    entry.Text = "";
                    DisplayAlert("Error", message, "Aceptar");
                }
            }
        }

        private double getValue(object sender)
        {
            Entry entry = ((Entry)sender);
            return String.IsNullOrEmpty(entry.Text) ? 0 : Convert.ToDouble(entry.Text); ;
        }

        
    }
}