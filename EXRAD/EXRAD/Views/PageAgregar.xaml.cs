using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using EXRAD.Model;
using EXRAD.Controllers;
using EXRAD.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXRAD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAgregar : ContentPage
    {
        public PageAgregar()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            CancellationTokenSource cts;
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if(location != null)
                {
                    Latitud.Text = Convert.ToString(location.Latitude);
                    Longitud.Text = Convert.ToString(location.Longitude);
                }
                else
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
                    cts = new CancellationTokenSource();
                    location = await Geolocation.GetLocationAsync(request, cts.Token);

                    if (location != null)
                    {
                        Latitud.Text = Convert.ToString(location.Latitude);
                        Longitud.Text = Convert.ToString(location.Longitude);
                    }
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                fnsEx.ToString();
            }
        }
        private async Task<bool> validarFormulario()
        {
            
            if (String.IsNullOrWhiteSpace(Nombres.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del nombre es obligatorio.", "OK");
                return false;
            }

            if (String.IsNullOrWhiteSpace(Apellidos.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del apellido es obligatorio.", "OK");
                return false;
            }

            if (String.IsNullOrWhiteSpace(Celular.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del número celular es obligatorio.", "OK");
                return false;
            }

            if (String.IsNullOrWhiteSpace(Nota.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del Nota es obligatorio.", "OK");
                return false;
            }
            return true;
        }
        private async void BtnSalvar_Clicked(object sender, EventArgs e)
        {
            if (await validarFormulario())
            {
                await DisplayAlert("Exito", "Todos tus campos cumplieron las validaciones.", "OK");
                var contacto = new Contactos
                {
                    Nombres = Nombres.Text,
                    Apellidos = Apellidos.Text,
                    Edad = Convert.ToInt32(Edad.Text),
                    Celular = Convert.ToInt32(Celular.Text),
                    Pais = Pais.SelectedItem.ToString(),
                    Nota = Nota.Text,
                    Latitud = Convert.ToDouble(Latitud.Text),
                    Longitud = Convert.ToDouble(Longitud.Text)
                };
                await DB.AddContacto(contacto);
                if (await DB.AddContacto(contacto) > 0)
                {
                    await DisplayAlert("Aviso", "Contacto Adicionado", "Ok");
                }
                else
                {
                    await DisplayAlert("Aviso", "Ha ocurrido un error", "OK");
                }
            }
            
        }

    }
}