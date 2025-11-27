using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Services.Interfaces;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/user
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al obtener los usuarios.", Detalle = ex.Message });
            }
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user == null)
                    return NotFound(new { Mensaje = $"No se encontró el usuario con ID {id}." });

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al obtener el usuario.", Detalle = ex.Message });
            }
        }

        // POST: api/user
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                var createdUser = await _userService.CreateAsync(user);
                return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al crear el usuario.", Detalle = ex.Message });
            }
        }

        // PUT: api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User updatedUser)
        {
            try
            {
                var existingUser = await _userService.GetByIdAsync(id);
                if (existingUser == null)
                    return NotFound(new { Mensaje = $"No se encontró el usuario con ID {id}." });

                existingUser.Name = updatedUser.Name;
                existingUser.Email = updatedUser.Email;
                existingUser.Password = updatedUser.Password;

                await _userService.UpdateAsync(id, existingUser);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al actualizar el usuario.", Detalle = ex.Message });
            }
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                if (user == null)
                    return NotFound(new { Mensaje = $"No se encontró el usuario con ID {id}." });

                await _userService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al eliminar el usuario.", Detalle = ex.Message });
            }
        }
    }
}
