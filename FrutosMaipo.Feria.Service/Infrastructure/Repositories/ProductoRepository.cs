using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrutosMaipo.Feria.Service.Infrastructure.Interfaces;
using FrutosMaipo.Feria.Service.Infrastructure.Entities;
using FrutosMaipo.Feria.Service.Models;

namespace FrutosMaipo.Feria.Service.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly FMaipoBDContext _context;

        public ProductoRepository (FMaipoBDContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarProducto(ProductoModel producto)
        {
            try
            {
                Producto productoEntity = await _context.Producto.FirstOrDefaultAsync(a => a.IdProducto == producto.idProducto);
                productoEntity.Nombre = producto.Nombre;
                productoEntity.Descripcion = producto.Descripcion;
                productoEntity.Precio = producto.Precio;

                return await _context.SaveChangesAsync() > 0 ? true : false;

            }
            catch (Exception) { return false; }
        }

        public async Task<bool> AsignarProductorToProducto(ProductorToProductoModel productoPedido)
        {
            try
            {
                IList<ProductoPedido> productoPedidoEntity = await _context.ProductoPedido.Where(a => a.Pedido == productoPedido.idPedido).ToListAsync();

                foreach (var item in productoPedidoEntity)
                {
                    foreach (var itemProducto in productoPedido.idProducto)
                    {
                        item.Productor = itemProducto;
                    }
                }
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> CrearProducto(ProductoModel producto)
        {
            Producto nuevoProducto = new Producto();
            nuevoProducto.Nombre = producto.Nombre;
            nuevoProducto.Descripcion = producto.Descripcion;
            nuevoProducto.Precio = producto.Precio;
            nuevoProducto.Imagen = producto.Image;
            await _context.Producto.AddAsync(nuevoProducto);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<bool> EliminarProducto(int idProducto)
        {
            try
            {
                var productoResult = await _context.Producto.FirstOrDefaultAsync(a => a.IdProducto == idProducto);
                bool response;
                if (productoResult == null)
                {
                    response = false;
                }
                else
                {
                    _context.Producto.Remove(productoResult);
                    await _context.SaveChangesAsync();
                    response = true;
                }
                return response;
            }
            catch (Exception) { return false; }
        }

        public async Task<bool> InsertarProductoPedido(int idUsuario, int totalPedido, IList<ProductoPedidoModel> productoPedido)
        {
            try
            {
                Pedido nuevoPedido = new Pedido();
                nuevoPedido.Descripcion = "Pedido solicitado por cliente externo y creado por el administrador";
                nuevoPedido.Vigencia = "1";
                nuevoPedido.Usuario = idUsuario;
                await _context.Pedido.AddAsync(nuevoPedido);
                await _context.SaveChangesAsync();
                int idPedido = nuevoPedido.IdPedido;

                if (idPedido!=null)
                {
                    foreach (var item in productoPedido)
                    {
                        ProductoPedido nuevoProductoPedido = new ProductoPedido();
                        nuevoProductoPedido.Pedido = idPedido;
                        nuevoProductoPedido.Producto = item.idProducto;
                        nuevoProductoPedido.Kilogramos = item.cantidad;
                        await _context.ProductoPedido.AddAsync(nuevoProductoPedido);
                    }
                    if (await _context.SaveChangesAsync() > 0 ? true : false)
                    {
                        ProcesoVenta nuevoProcesoVenta = new ProcesoVenta();
                        nuevoProcesoVenta.FechaInicio = DateTime.Now;
                        nuevoProcesoVenta.FechaTermino = null;
                        nuevoProcesoVenta.TipoVenta = 1;
                        nuevoProcesoVenta.Estado = 1;
                        nuevoProcesoVenta.Pedido = idPedido;
                        nuevoProcesoVenta.Total = totalPedido;
                        await _context.ProcesoVenta.AddAsync(nuevoProcesoVenta);
                    }
                    return await _context.SaveChangesAsync() > 0 ? true : false;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception) { return false; }
        }

        public async Task<IList<DetallePedidoAsignadoModel>> ObtenerDetallePedidoAsignado(int idUsuario)
        {
            IList<DetallePedidoAsignadoModel> detallePedidoAsignadoList = new List<DetallePedidoAsignadoModel>();
            DetallePedidoAsignadoModel detallePedidoAsignadoModel = null;
            IList<ProcesoVenta> procesoVentaListEntities = new List<ProcesoVenta>();
            try
            {
                IList<Pedido> pedidoEntity = await _context.Pedido.Where(a => a.Usuario == idUsuario).ToListAsync();

                foreach (var item in pedidoEntity)
                {
                    ProcesoVenta procesoVentaResult = await _context.ProcesoVenta.FirstOrDefaultAsync(a => a.Pedido == item.IdPedido);
                    procesoVentaListEntities.Add(procesoVentaResult);
                }


                foreach (var item in procesoVentaListEntities)
                {
                    var tipoVentaDescripcion = "";
                    var estadoDescripcion = "";
                    TipoVenta tipoVentaEntity = await _context.TipoVenta.FirstOrDefaultAsync(a => a.IdTipoVenta == item.TipoVenta);
                    tipoVentaDescripcion = tipoVentaEntity.Descipcion;
                    Estado estadoEntity = await _context.Estado.FirstOrDefaultAsync(a => a.IdEstado == item.Estado);
                    estadoDescripcion = estadoEntity.Descripcion;

                    detallePedidoAsignadoModel = new DetallePedidoAsignadoModel()
                    {
                        idProcesoVenta = item.IdProcesoVenta,
                        idPedido = item.Pedido.HasValue? item.Pedido.Value : 0,
                        fechaInicio = item.FechaInicio.ToString() != null ? item.FechaInicio.ToString() : "-",
                        tipoVenta = tipoVentaDescripcion, 
                        idEstado = item.Estado.HasValue? item.Estado.Value : 0,
                        estado = estadoDescripcion
                    };
                    detallePedidoAsignadoList.Add(detallePedidoAsignadoModel);
                }
                return detallePedidoAsignadoList;
            }
            catch (Exception ex)
            {
                var e = ex.Message;
                throw;
            }
        }

        public async Task<IList<DetallePedidoAsignadoModel>> ObtenerProcesosDetallePorEstado(int idEstado)
        {
            IList<DetallePedidoAsignadoModel> detallePedidoAsignadoList = new List<DetallePedidoAsignadoModel>();
            DetallePedidoAsignadoModel detallePedidoAsignadoModel = null;
            IList<ProcesoVenta> procesoVentaListEntities = new List<ProcesoVenta>();
            try
            {
                IList<Pedido> pedidoEntity = await _context.Pedido.ToListAsync();

                foreach (var item in pedidoEntity)
                {
                    ProcesoVenta procesoVentaResult = await _context.ProcesoVenta.FirstOrDefaultAsync(a => a.Pedido == item.IdPedido && a.Estado == idEstado);
                    if (procesoVentaResult != null)
                    {
                        procesoVentaListEntities.Add(procesoVentaResult);
                    }
                }


                foreach (var item in procesoVentaListEntities)
                {
                    var tipoVentaDescripcion = "";
                    var estadoDescripcion = "";
                    TipoVenta tipoVentaEntity = await _context.TipoVenta.FirstOrDefaultAsync(a => a.IdTipoVenta == item.TipoVenta);
                    tipoVentaDescripcion = tipoVentaEntity.Descipcion;
                    Estado estadoEntity = await _context.Estado.FirstOrDefaultAsync(a => a.IdEstado == item.Estado);
                    estadoDescripcion = estadoEntity.Descripcion;

                    detallePedidoAsignadoModel = new DetallePedidoAsignadoModel()
                    {
                        idProcesoVenta = item.IdProcesoVenta,
                        idPedido = item.Pedido.HasValue ? item.Pedido.Value : 0,
                        fechaInicio = item.FechaInicio.ToString() != null ? item.FechaInicio.ToString() : "-",
                        tipoVenta = tipoVentaDescripcion,
                        idEstado = item.Estado.HasValue ? item.Estado.Value : 0,
                        estado = estadoDescripcion
                    };
                    detallePedidoAsignadoList.Add(detallePedidoAsignadoModel);
                }
                return detallePedidoAsignadoList;
            }
            catch (Exception ex)
            {
                var e = ex.Message;
                throw;
            }
        }

        public async Task<IList<ProductoModel>> ObtenerProductos()
        {
            IList<ProductoModel> productoList = new List<ProductoModel>();
            ProductoModel productoModel = null;
            try
            {
                var buildingResult = await _context.Producto.ToListAsync();
                foreach (var item in buildingResult)
                {
                    productoModel = new ProductoModel()
                    {
                        idProducto = item.IdProducto,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        Precio = item.Precio.HasValue? item.Precio.Value : 0,
                        Image = item.Imagen
                    };
                    productoList.Add(productoModel);
                }
                return productoList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IList<ProductorProductoPedidoModel>> ObtenerProductosProveer(int idPedido)
        {
            IList<ProductorProductoPedidoModel> productosProveerList = new List<ProductorProductoPedidoModel>();
            ProductorProductoPedidoModel productosProveerModel = null;
            IList<Producto> productosListEntities = new List<Producto>();
            try
            {
                IList<ProductoPedido> pedidoEntity = await _context.ProductoPedido.Where(a => a.Pedido== idPedido).ToListAsync();

                foreach (var item in pedidoEntity)
                {
                    Producto productosResult = await _context.Producto.FirstOrDefaultAsync(a => a.IdProducto == item.Producto);
                    productosListEntities.Add(productosResult);
                }


                foreach (var item in pedidoEntity)
                {
                    //var nombreProducto = "";
                    //var descripcionProducto = "";
                    //var imageProducto = "";
                    //var precioProducto = 0;

                    Producto productoEntity = await _context.Producto.FirstOrDefaultAsync(a => a.IdProducto == item.Producto);
                    //nombreProducto = productoEntity.Nombre;
                    //descripcionProducto = productoEntity.Descripcion;
                    //imageProducto = productoEntity.Imagen;
                    //precioProducto = productoEntity.Precio.HasValue? productoEntity.Precio.Value : 0;

                    productosProveerModel = new ProductorProductoPedidoModel()
                    {
                        idPedido = item.Pedido.HasValue ? item.Pedido.Value : 0,
                        idProducto = item.Producto.HasValue ? item.Producto.Value : 0,
                        nombreProducto = productoEntity.Nombre,
                        descripcionProducto = productoEntity.Descripcion,
                        imageProducto = productoEntity.Imagen,
                        precioProducto = productoEntity.Precio.HasValue ? productoEntity.Precio.Value : 0,
                        cantidadPedido = item.Kilogramos.HasValue ? item.Kilogramos.Value : 0
                    };
                    productosProveerList.Add(productosProveerModel);
                }
                return productosProveerList;
            }
            catch (Exception ex)
            {
                var e = ex.Message;
                throw;
            }
        }

        public async Task<ProductoModel> ProductoPorId(int idProducto)
        {
            ProductoModel producto = null;
            try
            {
                Producto productoEntity = await _context.Producto.FirstOrDefaultAsync(a => a.IdProducto == idProducto);
                if (productoEntity != null)
                {
                    producto = new ProductoModel
                    {
                        idProducto = productoEntity.IdProducto,
                        Descripcion = productoEntity.Descripcion
                    };
                    return producto;
                }
                else { return producto; }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
