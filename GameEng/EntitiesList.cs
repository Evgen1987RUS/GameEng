using Engine;
using GameEngNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng
{
    public class EntitiesList
    {
        List<Entity> _entities;

        public List<Entity> Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public EntitiesList(List<Entity> entities) 
        {
            _entities = entities;
        }

        public void Append(Entity entity)
        {
            Entities.Add(entity);
        }

        public void RemoveEntity(Entity entity)
        {
            if (Entities.Contains(entity))
                Entities.Remove(entity);
            else 
                throw new EngineExceptions.InEntityExceptions.NoKeyFound();
        }

        public Entity GetEntity(Identifier id)
        {
            if (Entities[id.Value] != null)
                return Entities[id.Value];
            else
                throw new EngineExceptions.InEntityExceptions.NoKeyFound();
        }

// TODO : exec <> ?

        public EntitiesList this[Identifier id]
        {
            get { GetEntity(id); return this; }
            set { Entities[id.Value] = value; }
        }
    }
}
