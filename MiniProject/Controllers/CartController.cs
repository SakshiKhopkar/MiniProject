using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject.Model;
using MiniProject.Repositories;
using MiniProject.Services;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService service;
        public CartController(ICartService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("AddToCart")]
        public async Task<IActionResult> Post([FromBody][Bind(include: "Name,Price,ImageUrl")] Product product)
        {

            try
            {
                var result = await service.AddToCart(product);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
