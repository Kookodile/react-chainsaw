using ReactChainsaw.API.Database.Models;

namespace ReactChainsaw.API.Database.Repositories
{
    public class ToDoRepository
    {
        private readonly AppDbContext context;

        public ToDoRepository(AppDbContext context)
        {
            this.context = context;
        }
        public List<ToDoEntity> GetAll()
        {
            return context.Todos.ToList();
        }
        public ToDoEntity Insert(string nom, string description, DateTime? deadline)
        {
            var entity = new ToDoEntity
            {

                Nom = nom,
                Description = description,
                DateCreation = DateTime.Now,
                DateModification = DateTime.Now,
                DeadLine = deadline,
                Eta = 0,
                Id = Random.Shared.Next()

            };
            context.Todos.Add(entity);
            context.SaveChanges();
            return entity;

        }
        public void Delete(int id)
        {
            var toDelete = context.Todos.FirstOrDefault((todo) => todo.Id == id);

            if (toDelete != null)
            {
                context.Todos.Remove(toDelete);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Id inexistant");
            }
        }
        public ToDoEntity Update(int id, string nom, string description, DateTime? deadline, int eta)
        {
            var update = context.Todos.FirstOrDefault((todo) => todo.Id == id);
            if (update != null)
            {
                update.Nom = nom;
                update.Description = description;
                update.Eta = eta;
                update.DeadLine = deadline;
                update.DateModification = DateTime.Now;
                context.SaveChanges();

            }
            else
            {
                throw new Exception("Id inexistant");
            }

            return update;
        }
    }

}
