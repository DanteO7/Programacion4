using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders.Physical;
using Pancheria.Models.Pancho;
using Pancheria.Models.Pancho.DTO;
using Pancheria.Services;
using Pancheria.Utils;

namespace Pancheria.Controllers
{
    [Route("api/panchos")]
    [ApiController]
    public class PanchoController : ControllerBase
    {
        private readonly IPanchoServices _panchoServices;
        public PanchoController(IPanchoServices panchoServices)
        {
            _panchoServices = panchoServices;
        }

        [HttpGet]
        public ActionResult<List<PanchoDTO>> GetAll()
        {
            var panchos = _panchoServices.GetAll();
            return Ok(panchos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(type: typeof(Pancho), StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status404NotFound)]
        public ActionResult<Pancho> GetOneById(int id)
        {
            try
            {
                var pancho = _panchoServices.GetOneById(id);
                return Ok(pancho);
            }
            catch (Exception ex)
            {
                return NotFound(new HttpMessage { Message = ex.Message });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage { Message = "Algo malio sal" });
            }
        }

        [HttpGet("aderezo/{condiment}")]
        [ProducesResponseType(type: typeof(Pancho), StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status404NotFound)]
        public ActionResult<List<PanchoAderezoDTO>> GetAllByCondiment(string condiment)
        {
            try
            {
                var panchos = _panchoServices.GetAllByCondiment(condiment);
                return Ok(panchos);
            }
            catch (Exception ex)
            {
                return NotFound(new HttpMessage { Message = ex.Message });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage { Message = "Algo malio sal" });
            }
        }
    }
}
