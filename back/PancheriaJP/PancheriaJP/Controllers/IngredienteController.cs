using PancheriaJP.Utils;
using Microsoft.AspNetCore.Mvc;
using PancheriaJP.Models.Ingrediente;
using PancheriaJP.Models.Ingrediente.Dto;
using PancheriaJP.Services;

namespace PancheriaJP.Controllers
{
    [Route("api/ingredientes")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteServices _ingServices;

        public IngredienteController(IngredienteServices panchoServices)
        {
            _ingServices = panchoServices;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Ingrediente>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<List<Ingrediente>>> GetAll()
        {
            try
            {
                var ings = await _ingServices.GetAll();
                return Ok(ings);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Ingrediente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Ingrediente>> GetOneById(int id)
        {
            try
            {
                var ing = await _ingServices.GetOneById(id);
                return Ok(ing);
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
        [ProducesResponseType(typeof(Ingrediente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Ingrediente>> CreateOne([FromBody] CreateUpdateIngredienteDTO createDTO)
        {
            try
            {
                var ing = await _ingServices.CreateOne(createDTO);
                return Created("Create Ingrediente", ing);
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
                await _ingServices.DeleteOneById(id);
                return Ok(new HttpMessage($"Ingrediente con ID = {id} eliminado"));
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
        [ProducesResponseType(typeof(Ingrediente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<Ingrediente>> UpdateOneById(int id, [FromBody] CreateUpdateIngredienteDTO updateDto)
        {
            try
            {
                var ing = await _ingServices.UpdateOneById(id, updateDto);
                return Ok(ing);
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
