using GameEng.lib.BasicMath;
using GameEng.lib.Engine.BasicClasses;
using GameEng.lib.Engine.Visualization;
using GameEng.lib.GameEngine;
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
        GameCanvas _canvas;
        GameCamera _camera;
        Mapper _mapper;
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
            _mapper = new(this);
            _mapper.Add(ConsoleKey.W, _camera, Forward);
            _mapper.Add(ConsoleKey.D, _camera, Right);
            _mapper.Add(ConsoleKey.A, _camera, Left);
            _mapper.Add(ConsoleKey.S, _camera, Backwards);
            _mapper.Add(ConsoleKey.Q, _camera, RotateLeft);
            _mapper.Add(ConsoleKey.E, _camera, RotateRight);
            _mapper.Add(ConsoleKey.Spacebar, _camera, Up);
            _mapper.Add(ConsoleKey.Z, _camera, Down);
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

        static void Forward(Entity entity)
        {
            GameCamera camera = (GameCamera)entity;
            camera.Move(camera.CoordinateSyst.VectorSpace.Normalize(camera.Direction));
        }

        static void Backwards(Entity entity)
        {
            GameCamera camera = (GameCamera)entity;
            camera.Move(-1 * camera.CoordinateSyst.VectorSpace.Normalize(camera.Direction));
        }

        static void Right(Entity entity)
        {
            Vector vector = new(3, 1);
            float[,] buffArray = { { 0 }, { 0 }, { 1 } };
            vector.CurrentMatrix = buffArray;
            GameCamera camera = (GameCamera)entity;
            Vector vectorRight = camera.CoordinateSyst.VectorSpace.CrossProduct(camera.Direction, vector); 
            camera.Move(camera.CoordinateSyst.VectorSpace.Normalize(vectorRight));
        }

        static void Left(Entity entity)
        {
            Vector vector = new(3, 1);
            float[,] buffArray = { { 0 }, { 0 }, { 1 } };
            vector.CurrentMatrix = buffArray;
            GameCamera camera = (GameCamera)entity;
            Vector vectorRight = camera.CoordinateSyst.VectorSpace.CrossProduct(camera.Direction, vector);
            camera.Move(-1 * camera.CoordinateSyst.VectorSpace.Normalize(vectorRight));
        }

        static void Up(Entity entity)
        {
            Vector vector = new(3, 1);
            float[,] buffArray = { { 0 }, { 0 }, { 1 } };
            vector.CurrentMatrix = buffArray;
            GameCamera camera = (GameCamera)entity;
            camera.Move(vector);
        }

        static void Down(Entity entity)
        {
            Vector vector = new(3, 1);
            float[,] buffArray = { { 0 }, { 0 }, { -1 } };
            vector.CurrentMatrix = buffArray;
            GameCamera camera = (GameCamera)entity;
            camera.Move(vector);
        }

        static void RotateLeft(Entity entity)
        {
            GameCamera camera = (GameCamera)entity;
            camera.Rotation_3D(0, 0, 10);
        }

        static void RotateRight(Entity entity)
        {
            GameCamera camera = (GameCamera)entity;
            camera.Rotation_3D(0, 0, -10);
        }
    }
}
