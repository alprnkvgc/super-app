using Application.Features.Products.Commands;
using Application.Features.Products.Queries.GetAll;
using Application.Features.Products.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v2/[controller]")]
    public class ProductController : BaseApiController<ProductController>
    {
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }
        /// <summary>
        /// Get a Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery() { Id = id });
            return Ok(product);
        }

        /// <summary>
        /// Create/Update a Product
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateUpdateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        /// <summary>
        /// Delete Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 Ok</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteProductCommand { Id = id }));
        }
    }

}