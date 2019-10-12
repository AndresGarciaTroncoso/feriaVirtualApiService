using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FrutosMaipo.Feria.Service.Models;

namespace FrutosMaipo.Feria.Service.Infrastructure.Interfaces
{
    public interface IProductoRepository
    {
        Task<IList<ProductoModel>> ObtenerProductos();
        Task<bool> CrearProducto(ProductoModel producto);
        Task<bool> ActualizarProducto(ProductoModel producto);
        Task<bool> EliminarProducto(int idProducto);
        Task<ProductoModel> ProductoPorId(int idProducto);
        Task<bool> InsertarProductoPedido(int idUsuario, int totalPedido, IList<ProductoPedidoModel> productoPedido);
        Task<IList<DetallePedidoAsignadoModel>> ObtenerDetallePedidoAsignado(int idUsuario);
        Task<IList<DetallePedidoAsignadoModel>> ObtenerProcesosDetallePorEstado(int idEstado);
        Task<IList<ProductorProductoPedidoModel>> ObtenerProductosProveer(int idPedido);
        Task<bool> AsignarProductorToProducto(ProductorToProductoModel productoPedido);
    }
}
