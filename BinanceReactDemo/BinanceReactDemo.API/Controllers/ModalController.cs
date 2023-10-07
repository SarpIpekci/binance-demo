using BinanceReactDemo.API.Repostories.FillModal.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BinanceReactDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalController : ControllerBase
    {
        private readonly IGetModal _modal;
        public ModalController(IGetModal modal)
        {
            _modal = modal;
        }

        [HttpGet("fillModal")]
        public async Task<IActionResult> FillModal()
        {
            try
            {
                var result = await _modal.GetFillModal();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
