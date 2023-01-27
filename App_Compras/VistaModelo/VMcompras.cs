using App_Compras.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
//extr
using App_Compras.Modelo;
using App_Compras.Datos;

namespace App_Compras.VistaModelo
{
    public class VMcompras : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        //extra
        List<Mproductos> _listaProd;
        int _index;
        #endregion
        #region CONSTRUCTOR
        public VMcompras(INavigation navigation, StackLayout ladoDerecha, StackLayout ladoIzquierda)
        {
            Navigation = navigation;
            MostrarProductosBDD(ladoDerecha, ladoIzquierda);
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }

        public List<Mproductos> ListaProductos
        {
            get { return _listaProd; }
            set { SetValue(ref _listaProd, value); }
        }
        #endregion
        #region PROCESOS
        //mostrar prod de la bd de firebase
        public async Task MostrarProductosBDD(StackLayout ladoDerecha, StackLayout ladoIzquierda) {
            var funcion = new Dproductos();
            ListaProductos = await funcion.MostrarProductos();
            //limpiar
            ladoDerecha.Children.Clear();
            ladoIzquierda.Children.Clear();
            //recorrer y agregar
            foreach (var item in ListaProductos) {
                CrearContenedorProductos(item, _index, ladoDerecha, ladoIzquierda);
                _index++;
            }
        }

        public void CrearContenedorProductos(Mproductos item, int index, StackLayout ladoDerecha, StackLayout ladoIzquierda) {
            
            //obtener lado
            var _ubicacion = Convert.ToBoolean(index%2);
            //asignar lado
            var lado = _ubicacion ?ladoDerecha: ladoIzquierda;

            //contenedor
            var frame = new Frame
            {
                HeightRequest = 330,
                CornerRadius = 10,
                Margin = 4,
                BackgroundColor = Color.White,
                Padding = 20
            };
            var stack = new StackLayout
            {
                //vacio
            };
            var img = new Image 
            {
                Source = item.Icono,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0,10,0,0)
            };
            var lblPrecio = new Label
            {
                Text = "$"+item.Precio,
                FontAttributes = FontAttributes.Bold,
                FontSize = 22,
                Margin = new Thickness(0,10),
                TextColor = Color.FromHex("#333333")
            };
            var lblDescrip = new Label
            {
                Text = item.Descripcion,
                FontSize = 18,
                TextColor = Color.Black,
                CharacterSpacing = 1
            };
            var lblCantidad = new Label
            {
                Text = "750ml",
                FontSize = 13,
                TextColor = Color.Gray,
                CharacterSpacing = 1
            };
            stack.Children.Add(img);
            stack.Children.Add(lblPrecio);
            stack.Children.Add(lblDescrip);
            stack.Children.Add(lblCantidad);
            frame.Content = stack;
            //ubicar 
            lado.Children.Add(frame);
        }
        public async Task ProcesoAsyncrono()
        {

        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
