using GameEng.lib.BasicMath;
using GameEng.lib.Engine.BasicClasses;
using GameEng.lib.Engine.Visualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.lib.GameEngine
{
    public class Game
    {
        EntitiesList _entities;
        CoordinateSystem _coordinateSystem;
        EventSystem _eventSystem;
        GameCanvas _canvas;
        GameCamera _camera;
        public event EventHandler<ConsoleKeyInfo>? KeyPress;
        int _wait;

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

        public Game(CoordinateSystem coordinateSystem, EntitiesList entities, GameConfiguration config, GameCamera camera)
        {
            _entities = entities;
            _coordinateSystem = coordinateSystem;
            _camera = camera;
            _wait = config.GetVariable("wait");
            _canvas = new GameConsole(config, this);
            
        }

        public void Run()
        {
            ConsoleKeyInfo info;

            do
            {
                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(_wait);
                    Update(); 
                }

                info = Console.ReadKey(true);
                KeyPress?.Invoke(this, info);
            } while (info.Key != ConsoleKey.Escape);

            Exit();
        }
        public void Update()
        {
            _canvas.Draw(_camera); 
        }
        public void Exit() { }
    }
}
