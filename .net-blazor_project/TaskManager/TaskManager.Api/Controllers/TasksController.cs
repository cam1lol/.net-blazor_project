using Microsoft.AspNetCore.Mvc;
using TaskManager.Shared.Models;
using TaskManager.Api.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public TasksController(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var tasks = await _taskService.GetAllAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al obtener las tareas.", Detalle = ex.Message });
            }
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var task = await _taskService.GetByIdAsync(id);
                if (task == null)
                    return NotFound(new { Mensaje = $"No se encontró la tarea con ID {id}." });

                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al obtener la tarea.", Detalle = ex.Message });
            }
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserTask task)
        {
            try
            {
                // Validar que el usuario exista
                var user = await _userService.GetByIdAsync(task.UserId);
                if (user == null)
                    return BadRequest(new { Mensaje = $"El usuario con ID {task.UserId} no existe." });

                task.CreatedAt = DateTime.UtcNow; // asignar fecha de creación
                var createdTask = await _taskService.CreateAsync(task);
                return CreatedAtAction(nameof(GetById), new { id = createdTask.TaskId }, createdTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al crear la tarea.", Detalle = ex.Message });
            }
        }

        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserTask updatedTask)
        {
            try
            {
                var existingTask = await _taskService.GetByIdAsync(id);
                if (existingTask == null)
                    return NotFound(new { Mensaje = $"No se encontró la tarea con ID {id}." });

                // Actualizar campos
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.DueDate = updatedTask.DueDate;
                existingTask.UserId = updatedTask.UserId;
                existingTask.Status = updatedTask.Status;

                await _taskService.UpdateAsync(id, existingTask);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al actualizar la tarea.", Detalle = ex.Message });
            }
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var task = await _taskService.GetByIdAsync(id);
                if (task == null)
                    return NotFound(new { Mensaje = $"No se encontró la tarea con ID {id}." });

                await _taskService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensaje = "Error al eliminar la tarea.", Detalle = ex.Message });
            }
        }
    }
}
