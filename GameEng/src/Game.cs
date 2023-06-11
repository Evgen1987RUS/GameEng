using GameEng.lib.BasicMath;
using GameEng.lib.Engine.BasicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.src
{
    public class Game
    {
        EntitiesList _entities;
        CoordinateSystem _coordinateSystem;
        EventSystem _eventSystem;

        public EntitiesList Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }

        public CoordinateSystem CoordinateSyst
        {
            get { return _coordinateSystem; }
            set { _coordinateSystem = value; }
        }

        public EventSystem EventSystem
        {
            get { return _eventSystem; }
            set { _eventSystem = value; }
        }

        public Game(CoordinateSystem coordinateSystem, EntitiesList entities, EventSystem eventSystem)
        {
            _entities = entities;
            _coordinateSystem = coordinateSystem;
            _eventSystem = eventSystem;
        }

        public void ApplyConfiguration(GameConfiguration configuration) // ?? TODO: ApplyConfiguration
        {
            throw new Exception();
        }

        public void Run() { }
        public void Update() { }
        public void Exit() { }
    }
}
