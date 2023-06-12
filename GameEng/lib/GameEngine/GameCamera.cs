using System;
using GameEng.lib.BasicMath;
using GameEng.lib.Engine.BasicClasses;
using System.Configuration;

namespace GameEng.lib.GameEngine
{
    public class GameCamera : GameObject
    {
        float _hfov, _vfov, _drawDistance;
        Point _lookAt = new(3, 1);

        public float Hfov
        {
            get { return _hfov; }
            set { _hfov = value; }
        }

        public float Vfov
        {
            get { return _vfov; }
            set { _vfov = value; }
        }

        public Point LookAt
        {
            get { return _lookAt; }
            set { _lookAt = value; }
        }

        public float DrawDistance
        {
            get { return _drawDistance; }
            set { _drawDistance = value; }
        }

        public GameCamera(CoordinateSystem coordinateSystem, Point point, Vector direction, GameConfiguration config) : base(coordinateSystem, point, direction)
        {
            _hfov = config.GetVariable("hfov");
            _drawDistance = config.GetVariable("drawDistance");
            SetProperty("hfov", _hfov);
            SetProperty("draw distance", _drawDistance);
        }

        public GameCamera(CoordinateSystem coordinateSystem, Point point, Vector direction, GameConfiguration config, bool isVfov) : base(coordinateSystem, point, direction) // isVfov is required for making VS ignore two of the same constructors
        {
            _hfov = config.GetVariable("hfov");
            _vfov = config.GetVariable("vfov");
            _drawDistance = config.GetVariable("drawDistance");
            SetProperty("hfov", _hfov);
            SetProperty("vfov", _vfov);
            SetProperty("draw distance", _drawDistance);
        }

        public GameCamera(CoordinateSystem coordinateSystem, Point point, Vector direction, Point lookAt, GameConfiguration config) : base(coordinateSystem, point, direction)
        {
            _hfov = config.GetVariable("hfov");
            _drawDistance = config.GetVariable("drawDistance");
            _lookAt = lookAt;
            SetProperty("hfov", _hfov);
            SetProperty("draw distance", _drawDistance);
            SetProperty("look at", _lookAt);
        }

        public GameCamera(CoordinateSystem coordinateSystem, Point point, Vector direction, Point lookAt, GameConfiguration config, bool isVfov) : base(coordinateSystem, point, direction) // isVfov is required for making VS ignore two of the same constructors
        {
            _hfov = config.GetVariable("hfov");
            _vfov = config.GetVariable("vfov");
            _drawDistance = config.GetVariable("drawDistance");
            _lookAt = lookAt;
            SetProperty("fov", _hfov);
            SetProperty("vfov", _vfov);
            SetProperty("draw distance", _drawDistance);
            SetProperty("look at", _lookAt);
        }

        public override void Rotation_3D(float angleX, float angleY, float angleZ) { } // stub

        public override float IntersectionDistance(Ray ray) { return 0; } // stub

        public Ray[,] GetRays(int horizontalBlocks, int verticalBlocks)
        {
            Vector initialDirectionVector = Direction == null ? CoordinateSyst.VectorSpace.PointToVector(LookAt) - CoordinateSyst.VectorSpace.PointToVector(Position) : Direction;

            Ray[,] allRays = new Ray[horizontalBlocks, verticalBlocks];

            float deltaHorizontalAlpha = Hfov / horizontalBlocks;
            float deltaVerticalBeta = Vfov / verticalBlocks;

            for (int i = 0; i < horizontalBlocks; i++)
            {
                for (int j = 0; j < verticalBlocks; j++)
                {
                    float alpha_i = deltaHorizontalAlpha * i - Hfov / 2f;
                    float beta_i = deltaVerticalBeta * j - Vfov / 2f;
                    
                    Ray buff = new(CoordinateSyst, Position, initialDirectionVector);
                    buff.Normalize();
                    buff.Direction = Vector.toVector(initialDirectionVector.Rotate(alpha_i, alpha_i, 0)); 
                    buff.Direction = Vector.toVector(buff.Direction.Rotate(beta_i, 0, beta_i));
                    buff.Direction *= CoordinateSyst.VectorSpace.Length(initialDirectionVector) * CoordinateSyst.VectorSpace.Length(initialDirectionVector) / CoordinateSyst.VectorSpace.ScalarProduct(initialDirectionVector, buff.Direction);

                    allRays[i, j] = buff;
                }
            }

            return allRays;
        }
    }
}
