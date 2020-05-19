using System.Collections.Generic;

namespace CompetentieAppFrontend.Infrastructure.Repositories
{
    public interface ICRUDRepository<Entity, in Id>
    {
        IEnumerable<Entity> GetAll();
        Entity GetById(Id id);
        void Create(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);
    }
}