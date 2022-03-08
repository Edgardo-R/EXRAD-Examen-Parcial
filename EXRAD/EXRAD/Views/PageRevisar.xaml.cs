using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EXRAD.Controllers;
using EXRAD.Model;
using EXRAD.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EXRAD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageRevisar : ContentPage
    {
        public PageRevisar()
        {
            InitializeComponent();
        }

        private void listacontactos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Contactos contactos = (Contactos)e.CurrentSelection.FirstOrDefault();
                var contacto = DB.DelContactoAsync(contactos);
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listacontactos.ItemsSource = await DB.obtenerListaContactos();
        }
    }
}