using App_Compras.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Compras.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarCompra : ContentPage
    {
        public AgregarCompra(Mproductos parametrosTrae)
        {
            InitializeComponent();
            BindingContext = new VistaModelo.VMagregarCompra(Navigation, parametrosTrae);
        }
    }
}