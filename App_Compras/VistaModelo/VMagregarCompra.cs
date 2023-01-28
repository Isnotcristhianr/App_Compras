using App_Compras.Datos;
using App_Compras.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App_Compras.VistaModelo
{
    internal class VMagregarCompra:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        int _Cant;
        //extra
        public Mproductos Recibir { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMagregarCompra(INavigation navigation, Mproductos traer)
        {
            Navigation = navigation;
            Recibir = traer;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public int Cantidad { 
            get { return _Cant; }
            set { SetValue(ref _Cant, value); }
        }
        #endregion
        #region PROCESOS
        public async Task InsertarDetCompra() {

            if (Cantidad == 0) {
                Cantidad = 1;
            }
            
            var funcion = new DdetalleCompra();
            var parametros = new MdetalleCompras
            {
                Cantidad = Cantidad.ToString(),
                IdProducto = Recibir.IdProducto,
                PrecioCompra = Recibir.Precio
            };
            double precioCompra = Convert.ToDouble(Recibir.Precio);
            double cantidad = Convert.ToDouble(Cantidad);
            //calcular precio de venta
            double total = precioCompra * cantidad;
            //
            parametros.Total = total.ToString();

            //ejecutar
            await funcion.InsertarDetCompra(parametros);
            await Volver();


        }
        public async Task ProcesoAsyncrono()
        {
            await Task.Delay(1000);
        }
        public void ProcesoSimple()
        {

        }

        public void Aumentar() {
            Cantidad++;
        }

        public void Disminuir() {
            if (Cantidad > 0)
            {
                Cantidad--;
            }
            else {
                Cantidad = 0;
            }
        }

        //volver
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        public ICommand Aumentarcommand => new Command(Aumentar);
        public ICommand Disminuircommand => new Command(Disminuir);
        public ICommand Insertarcommand => new Command(async () => await InsertarDetCompra());
        #endregion
    }
}
