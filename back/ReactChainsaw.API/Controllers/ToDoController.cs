using Microsoft.AspNetCore.Mvc;
using ReactChainsaw.API.Assembler;
using ReactChainsaw.API.Database.Repositories;
using ReactChainsaw.API.Transports;
using ReactChainsaw.API.Transports.Requests;

namespace ReactChainsaw.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {

        private readonly ToDoAssembler assembler;

        public ToDoController(ToDoRepository repository)
        {
            this.assembler = new ToDoAssembler();
            this.repository = repository;
        }

        private readonly ToDoRepository repository;

        [HttpGet]
        public List<ToDo> GetToDos()
        {
            return assembler.Convert(repository.GetAll());
        }

        [HttpPost]
        public void AddTodos(AddTodo request)
        {
            repository.Insert(request.Nom, request.Description, request.DeadLine);
        }

        [HttpDelete("{id}")]
        public void DeleteTodos(int id)
        {
            repository.Delete(id);
        }

        [HttpPut("{id}")]
        public ToDo EditTodo(int id, EditTodo request)
        {

            return assembler.Convert(repository.Update(id, request.Nom, request.Description, request.DeadLine, request.Eta));
        }
    }
}