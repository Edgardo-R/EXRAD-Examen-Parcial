using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXRAD.Views;
using EXRAD.Controllers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXRAD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInicio : ContentPage
    {
        public PageInicio()
        {
            InitializeComponent();
        }

        private async void Btnagregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageAgregar());
        }

        private async void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageActualizar());
        }

        private async void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageRevisar());
        }
    }
}