using PancheriaJP.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PancheriaJP.Models.Pancho;
using PancheriaJP.Models.Pancho.Dto;
using PancheriaJP.Services;

namespace PancheriaJP.Controllers
{
    [Route("api/panchos")]
    [ApiController]
    public class PanchoController : ControllerBase
    {
        private readonly PanchoServices _panchoServices;

        public PanchoController(PanchoServices panchoServices)
        {
            _panchoServices = panchoServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Pancho>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<List<PanchosDTO>>> GetAll()
        {
            try
            {
                var panchos = await _panchoServices.GetAll();
                return Ok(panchos);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        //[HttpGet("aderezo/{aderezo}")]
        //[ProducesResponseType(typeof(List<Pancho>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        //async public Task<ActionResult<List<PanchoAderezoDTO>>> GetAllAderezo(string aderezo)
        //{
        //    try
        //    {
        //        var panchos = await _panchoServices.GetAllByAderezo(aderezo);
        //        return Ok(panchos);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(
        //            StatusCodes.Status500InternalServerError,
        //            new HttpMessage(ex.Message)
        //        );
        //    }
        //}

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Pancho), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Pancho>> GetOneById(int id)
        {
            try
            {
                var pancho = await _panchoServices.GetOneById(id);
                return Ok(pancho);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pancho), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Pancho>> CreateOne([FromBody] CreatePanchoDTO createDTO)
        {
            try
            {
                var pancho = await _panchoServices.CreateOne(createDTO);
                return Created("Create Pancho", pancho);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult> DeleteOneById(int id)
        {
            try
            {
                await _panchoServices.DeleteOneById(id);
                return Ok(new HttpMessage($"Pancho con ID = {id} eliminado"));
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Pancho), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Pancho>> UpdateOneById(int id, [FromBody] UpdatePanchoDTO updateDto)
        {
            try
            {
                var pancho = await _panchoServices.UpdateOneById(id, updateDto);
                return Ok(pancho);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }
    }
}
