using Application.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class TaskToDoController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public TaskToDoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await unitOfWork.TasksToDo.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await unitOfWork.TasksToDo.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskToDo requestBody)
        {
            var result = await unitOfWork.TasksToDo.AddAsync(requestBody);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TaskToDo requestBody)
        {
            var result = await unitOfWork.TasksToDo.UpdateAsync(requestBody);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await unitOfWork.TasksToDo.DeleteAsync(id);
            return Ok(result);
        }
    }
}
