using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FrutosMaipo.Feria.Service.Models;
using FrutosMaipo.Feria.Service.Infrastructure.Interfaces;
using System.Net;

namespace FrutosMaipo.Feria.Service.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(ProductoModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerProductos()
        {
            IList<ProductoModel> productoList = await _productoRepository.ObtenerProductos();
            if (productoList != null)
            {
                return Ok(productoList);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        [Route("GetById/{idProducto}")]
        [ProducesResponseType(typeof(ProductoModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ProductoPorId(int idProducto)
        {
            ProductoModel producto = await _productoRepository.ProductoPorId(idProducto);
            if (producto != null)
            {
                return Ok(producto);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        [Route("ObtenerProcesosDetallePorEstado/{idEstado}")]
        [ProducesResponseType(typeof(IList<DetallePedidoAsignadoModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerProcesosDetalle(int idEstado)
        {
            IList<DetallePedidoAsignadoModel> detallePedidoAsignado = await _productoRepository.ObtenerProcesosDetallePorEstado(idEstado);
            if (detallePedidoAsignado != null)
            {
                return Ok(detallePedidoAsignado);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        [Route("ObtenerDetallePedidoAsignado/{idUsuario}")]
        [ProducesResponseType(typeof(IList<DetallePedidoAsignadoModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerDetallePedidoAsignado(int idUsuario)
        {
            IList<DetallePedidoAsignadoModel> detallePedidoAsignado = await _productoRepository.ObtenerDetallePedidoAsignado(idUsuario);
            if (detallePedidoAsignado != null)
            {
                return Ok(detallePedidoAsignado);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpGet]
        [Route("ObtenerProductosProveer/{idPedido}")]
        [ProducesResponseType(typeof(IList<ProductorProductoPedidoModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObtenerProductosProveer(int idPedido)
        {
            IList<ProductorProductoPedidoModel> productosProveer = await _productoRepository.ObtenerProductosProveer(idPedido);
            if (productosProveer != null)
            {
                return Ok(productosProveer);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(ProductoModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CrearProducto([FromBody] ProductoModel building)
        {
            if (await _productoRepository.CrearProducto(building) != false)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPost]
        [Route("InsertarPedido")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> InsertarPedido([FromBody] PedidoModel productoPedido)
        {
            if (await _productoRepository.InsertarProductoPedido(productoPedido.idUsuario, productoPedido.total, productoPedido.productosPedido) != false)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPost]
        [Route("Update")]
        [ProducesResponseType(typeof(ProductoModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ActualizarProducto([FromBody] ProductoModel producto)
        {

            if (await _productoRepository.ActualizarProducto(producto) != false)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPost]
        [Route("AsignarProductorToProducto")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AsignarProductorToProducto([FromBody] ProductorToProductoModel producto)
        {

            if (await _productoRepository.AsignarProductorToProducto(producto) != false)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }

        [HttpPost]
        [Route("Delete/{idProducto}")]
        [ProducesResponseType(typeof(ProductoModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> EliminarProducto(int idProducto)
        {
            if (await _productoRepository.EliminarProducto(idProducto) != false)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }
        }
    }
}