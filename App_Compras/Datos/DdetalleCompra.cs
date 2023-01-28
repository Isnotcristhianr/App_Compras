using System;
using System.Collections.Generic;
using System.Text;
//firebase
using Firebase.Database;
using Firebase.Database.Query;
//extra
using System.Linq;
using System.Threading.Tasks;
//directorios
using App_Compras.Modelo;
using App_Compras.Conexiones;

namespace App_Compras.Datos
{
    public class DdetalleCompra
    {

        public async Task InsertarDetCompra(MdetalleCompras parametros) {
            await Cconexion.firebase.Child("DetalleCompra").PostAsync(new MdetalleCompras() {
                Cantidad = parametros.Cantidad,
                IdProducto = parametros.IdProducto,
                PrecioCompra = parametros.PrecioCompra,
                Total = parametros.Total,
            });
        }

        public async Task<List<MdetalleCompras>> PreviaDetalleCompra() {

            //almacenar ids
            var ListaDetalleCompras = new List<MdetalleCompras>();
            var funcionProductos = new Dproductos();
            var paramProductos = new Mproductos();

            //lista de datos
            var data = (await Cconexion.firebase.Child("DetalleCompra").OnceAsync<MdetalleCompras>())
                .Where(a => a.Key != "Modelo")
                .Select(item => new MdetalleCompras()
                {
                    IdProducto = item.Object.IdProducto,
                    IdDetalleCompra = item.Key
                });

            //recorrer ids de img
            foreach (var tmp in data) {
                
                var parametros = new MdetalleCompras();
                parametros.IdProducto = tmp.IdProducto;
                paramProductos.IdProducto = tmp.IdProducto;
                var listaProductos = await funcionProductos.MostrarProductosId(paramProductos);
                
                parametros.Imagen = listaProductos[0].Icono;
                ListaDetalleCompras.Add(parametros); 

            }

            return ListaDetalleCompras;

        }
    }
}
