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
