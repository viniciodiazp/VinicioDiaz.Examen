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
    public partial class Resumen : ContentPage
    {
        private Dictionary<string, double> resumen;
        private string nombre;
        public Resumen(String usuario, Dictionary<string, double> resumen, string nombre)
        {
            InitializeComponent();
            lblUsuarioConectado.Text = string.Format("Usuario conectado: {0}", usuario);
            this.resumen = resumen;
            this.nombre = nombre;
            CalcularTotales();
        }

        private void CalcularTotales()
        {
            double total = this.resumen["total"];
            double saldo = this.resumen["saldo"];
            double cuota = this.resumen["cuota"];
            double pagoInicial = this.resumen["pagoInicial"];
            txtTotal.Text = total.ToString();
            txtCuota.Text = cuota.ToString();
            txtNombre.Text = this.nombre;
            txtPagoInicial.Text = pagoInicial.ToString();
            txtTotalPagar.Text = (pagoInicial + (cuota * 3)).ToString();


        }

    }
}