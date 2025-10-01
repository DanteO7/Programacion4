using introduccion.Models.Cine;
using introduccion.Models.Cine.DTO;
using introduccion.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using introduccion.Utils;

namespace introduccion.Controllers
{
    [Route("api/cines")]
    [ApiController]
    public class CineController : ControllerBase
    {
        private readonly ICineServices _services;
        public CineController(ICineServices cineServices)
        {
            _services = cineServices;
        }

        [HttpGet]
        [ProducesResponseType(type: typeof(List<Cine>), StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        public ActionResult<List<CinesDTO>> GetAll()
        {
            try
            {
                var cines = _services.GetAll();
                return Ok(cines);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage(ex.Message));
            }

        }


        [HttpGet("{id}")]
        [ProducesResponseType(type: typeof(Cine), StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status500InternalServerError)]

        public ActionResult<Cine> GetOneById(int id)
        {
            try
            {
                var cine = _services.GetOneById(id);
                return Ok(cine);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage(ex.Message));
            }
        }

        [HttpPost]
        [ProducesResponseType(type: typeof(Cine), StatusCodes.Status201Created)]
        [ProducesResponseType(type: typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status500InternalServerError)]

        public ActionResult<Cine> CreateOne([FromBody] CreateCineDTO createCineDTO)
        {
            try
            {
                var cine = _services.CreateOne(createCineDTO);
                return Created("Create Cine", cine);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status500InternalServerError)]

        public ActionResult DeleteOneById(int id)
        {
            try
            {
                _services.DeleteOneById(id);
                return Ok(new HttpMessage($"Cine con ID = {id} elliminado"));
            }
            catch (HttpResponseError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage(ex.Message));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(type: typeof(Cine), StatusCodes.Status200OK)]
        [ProducesResponseType(type: typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        public ActionResult<Cine> UpdateOneById(int id, [FromBody]UpdateCineDTO updateCineDTO)
        {
            try
            {
                var cine = _services.UpdateOneById(id, updateCineDTO);
                return Ok(cine);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage(ex.Message));
            }
        }
    }
}