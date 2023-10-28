using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ZooAPI.Data.Repositories;
using ZooAPI.Model;

namespace ZooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAnimalController : ControllerBase
    {
        private readonly IZooRepository _zooRepository;

        public TipoAnimalController(IZooRepository zooRepository)
        {
            _zooRepository = zooRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTiposAnimais()
        {
            try
            {
                var tiposAnimais = await _zooRepository.GetAllTiposAnimais();
                return Ok(tiposAnimais);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipoAnimalById(int id)
        {
            try
            {
                var tipoAnimal = await _zooRepository.GetTipoAnimalById(id);
                if (tipoAnimal == null)
                    return NotFound();

                return Ok(tipoAnimal);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertTipoAnimal([FromBody] TipoAnimal tipoAnimal)
        {
            if (tipoAnimal == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _zooRepository.InsertTipoAnimal(tipoAnimal);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
