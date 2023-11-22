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
    public class AnimalController : ControllerBase
    {
        private readonly IZooRepository _zooRepository;

        public AnimalController(IZooRepository zooRepository)
        {
            _zooRepository = zooRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnimais()
        {
            try
            {
                var animais = await _zooRepository.GetAllAnimais();
                return Ok(animais);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ByTipo/{tipoId}")]
        public async Task<IActionResult> GetAnimaisByTipo(int tipoId)
        {
            try
            {
                var animais = await _zooRepository.GetAnimaisByTipo(tipoId);
                return Ok(animais);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ByNome/{nome}")]
        public async Task<IActionResult> GetAnimalByNome(string nome)
        {
            try
            {
                var animal = await _zooRepository.GetAnimalByNome(nome);
                if (animal == null)
                    return NotFound();

                return Ok(animal);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimalById(int id)
        {
            try
            {
                var animal = await _zooRepository.GetAnimalById(id);
                if (animal == null)
                    return NotFound();

                return Ok(animal);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertAnimal([FromBody] Animal animal)
        {
            if (animal == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _zooRepository.InsertAnimal(animal);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnimal([FromBody] Animal animal)
        {
            if (animal == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var success = await _zooRepository.UpdateAnimal(animal);
                if (!success)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            try
            {
                var success = await _zooRepository.DeleteAnimal(id);
                if (!success)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
