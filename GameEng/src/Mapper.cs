using GameEng.lib.Engine.BasicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.src
{
    public class Mapper
    {
        Dictionary<ConsoleKey, List<Tuple<Entity, Action<Entity>>>> _mapper = new();

        public Mapper(Game game) 
        {
            game.KeyPress += KeyPress;
        }

        private void KeyPress(object? sender, ConsoleKeyInfo info)
        {
            if (_mapper.ContainsKey(info.Key)) 
            {
                foreach (var tuple in _mapper[info.Key])
                {
                    Action<Entity> method = tuple.Item2;
                    if (method != null)
                        method(tuple.Item1);
                }
            }
        }

        public void Add(ConsoleKey key, Entity entity, Action<Entity> method)
        {
            Tuple<Entity, Action<Entity>> tuple = new(entity, method);

            if (!_mapper.ContainsKey(key))
                _mapper[key] = new List<Tuple<Entity, Action<Entity>>> { tuple };
            else
                _mapper[key].Add(tuple);
        }

        public void Clear(ConsoleKey key)
        {
            _mapper[key].Clear();
        }

        public void Remove(ConsoleKey key, Tuple<Entity, Action<Entity>> tuple)
        {
            _mapper[key].Remove(tuple);
        }
    }
}
