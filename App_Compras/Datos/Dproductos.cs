using System.Collections.Generic;
//usar where
using System.Linq;
using System.Threading.Tasks;
//firebase
using App_Compras.Conexiones;
//asincronas
using App_Compras.Modelo;

namespace App_Compras.Datos
{
    public class Dproductos
    {

        public async Task<List<Mproductos>> MostrarProductos() {

            return (await Cconexion.firebase
                .Child("Productos")
                .OnceAsync<Mproductos>()).Select(item => new Mproductos
                { 
                    Contenido = item.Object.Contenido,
                    Descripcion = item.Object.Descripcion,
                    Icono = item.Object.Icono,
                    Precio = item.Object.Precio,
                    IdProducto = item.Key
                    
                }).ToList();
        }

        public async Task<List<Mproductos>> MostrarProductosId(Mproductos parametros)
        {

            return (await Cconexion.firebase
                .Child("Productos")
                .OnceAsync<Mproductos>()).Where(a=>a.Key == parametros.IdProducto).Select(item => new Mproductos
                {
                    Contenido = item.Object.Contenido,
                    Descripcion = item.Object.Descripcion,
                    Icono = item.Object.Icono,
                    Precio = item.Object.Precio,
                    IdProducto = item.Key

                }).ToList();
        }
    }
}


