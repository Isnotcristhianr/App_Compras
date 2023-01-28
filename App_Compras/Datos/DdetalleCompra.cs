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
    }
}
