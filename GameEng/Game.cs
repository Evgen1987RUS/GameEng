using GameEngNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng
{
    public class Game
    {
        EntitiesList _entities;
        CoordinateSystem _coordinateSystem;

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

        public Game(CoordinateSystem coordinateSystem, EntitiesList entities) 
        {
            _entities = entities;
            _coordinateSystem = coordinateSystem;
        }

        public void Run() { }
        public void Update() { }
        public void Exit() { }
    }
}
