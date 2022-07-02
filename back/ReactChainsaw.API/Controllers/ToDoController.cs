using Microsoft.AspNetCore.Mvc;
using ReactChainsaw.API.Transports;

namespace ReactChainsaw.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        static List<ToDo> data = new List<ToDo>();

        [HttpGet]
        public List<ToDo> GetToDos()
        {

            return data;

        }

        [HttpPost]
        public void AddTodos(string nom, string description, DateTime deadline)
        {

            ToDo todo1 = new ToDo
            {
                DateCreation = DateTime.Now,
                DateModification = DateTime.Now,
                DeadLine = deadline,
                Description = description,
                Eta = 0,
                Id = Random.Shared.Next(),
                Nom = nom
            };
            data.Add(todo1);


        }

        [HttpDelete]
        public void DeleteTodos(int id)
        {
            //data.Any((todo) => { return todo.Eta == 100; });

            var toDelete = data.Find((todo) => todo.Id == id);

            if (toDelete != null)
            {
                data.Remove(toDelete);
            }
            else
            {
                throw new Exception("Id inexistant");
            }
        }

        [HttpPut]
        public ToDo EditTodo(int id, string nom, string description, int eta, DateTime deadline)
        {


            var update = data.Find((todo) => todo.Id == id);
            if (update != null)
            {
                update.Nom = nom;
                update.Description = description;
                update.Eta = eta;
                update.DeadLine = deadline;
                update.DateModification = DateTime.Now;

            } 
            else
            {
                throw new Exception("Id inexistant");
            }

            return update;
        }
    }
}