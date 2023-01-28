using App_Compras.VistaModelo;
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
    public partial class Compras : ContentPage
    {
        VMcompras vm;


        public Compras()
        {
            InitializeComponent();
            vm= new App_Compras.VistaModelo.VMcompras(Navigation, ladoDerecha, ladoIzquierda);
            BindingContext = vm;

            //detalle previa compra
            this.Appearing += Compras_Appearing;
        }

        private async void Compras_Appearing(object sender, EventArgs e)
        {
            await vm.PreviaDetalleCompra();
        }
    }
}