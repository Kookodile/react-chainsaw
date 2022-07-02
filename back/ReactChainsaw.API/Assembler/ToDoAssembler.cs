using ReactChainsaw.API.Database.Models;
using ReactChainsaw.API.Transports;

namespace ReactChainsaw.API.Assembler
{
    public class ToDoAssembler : BaseAssembler<ToDoEntity, ToDo>
    {
        public override ToDo Convert(ToDoEntity obj)
        {
            return new ToDo
            {
                DateCreation = obj.DateCreation,
                DateModification = obj.DateModification,
                DeadLine = obj.DeadLine,
                Description = obj.Description,
                Nom = obj.Nom,
                Eta = obj.Eta,
                Id = obj.Id
            };
        }

        public override ToDoEntity Convert(ToDo obj)
        {
            return new ToDoEntity
            {
                DateCreation = obj.DateCreation,
                DateModification = obj.DateModification,
                DeadLine = obj.DeadLine,
                Description = obj.Description,
                Nom = obj.Nom,
                Eta = obj.Eta,
                Id = obj.Id
            };
        }
    }
}
