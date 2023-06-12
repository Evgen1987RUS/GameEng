using GameEng.lib.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.lib.Engine.BasicClasses
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

        public IEnumerator<Entity> GetEnumerator()
        {
            foreach (Entity entity in Entities)
            {
                yield return entity;
            }
        }

        public Entity this[Identifier id]
        {
            get { return GetEntity(id); }
            set { Entities[id.Value] = value; }
        }
    }
}
