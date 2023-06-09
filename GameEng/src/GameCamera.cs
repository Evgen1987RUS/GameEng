﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GameEng.src;
using GameEng.lib.BasicMath;
using GameEng.lib.Engine.BasicClasses;

namespace GameEng
{
    public class GameCamera : GameObject
    {
        float _fov, _vfov, _drawDistance;
        Point _lookAt = new(3, 1);

        public float Fov
        {
            get { return _fov; }
            set { _fov = value; }
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

        public GameCamera(CoordinateSystem coordinateSystem, Point point, Vector direction, float fov, float drawDistance) : base(coordinateSystem, point, direction)
        {
            SetProperty("fov", fov);
            SetProperty("draw distance", drawDistance);
            _fov = fov;
            _drawDistance = drawDistance;
        }

        public GameCamera(CoordinateSystem coordinateSystem, Point point, Vector direction, float fov, float vfov, float drawDistance) : base(coordinateSystem, point, direction)
        {
            SetProperty("fov", fov);
            SetProperty("vfov", vfov);
            SetProperty("draw distance", drawDistance);
            _fov = fov;
            _drawDistance = drawDistance;
            _vfov = vfov;
        }

        public GameCamera(CoordinateSystem coordinateSystem, Point point, Vector direction, float fov, Point lookAt, float drawDistance) : base(coordinateSystem, point, direction)
        {
            SetProperty("fov", fov);
            SetProperty("look at", lookAt);
            SetProperty("draw distance", drawDistance);
            _fov = fov;
            _lookAt = lookAt;
            _drawDistance = drawDistance;
        }

        public GameCamera(CoordinateSystem coordinateSystem, Point point, Vector direction, float fov, Point lookAt, float vfov, float drawDistance) : base(coordinateSystem, point, direction)
        {
            SetProperty("fov", fov);
            SetProperty("look at", lookAt);
            SetProperty("vfov", vfov);
            SetProperty("draw distance", drawDistance);
            _fov = fov;
            _vfov = vfov;
            _lookAt = lookAt;
            _drawDistance = drawDistance;
        }

        public override void Rotation_3D(float angleX, float angleY, float angleZ) { } // stub

        public override float? IntersectionDistance(Ray ray) { return 0; } // stub

        public Ray[,] GetRays(int horizontalBlocks, int verticalBlocks)
        {
            Vector initialDirectionVector = Direction == null ? (CoordinateSyst.VectorSpace.PointToVector(LookAt) - CoordinateSyst.VectorSpace.PointToVector(Position)) : Direction;

            Ray[,] allRays = new Ray[horizontalBlocks, verticalBlocks];

            float deltaHorizontalAlpha = Fov / (horizontalBlocks);
            float deltaVerticalBeta = Vfov / (verticalBlocks);

            for (int i = 0; i < verticalBlocks; i++)
            {
                for (int j = 0; j < horizontalBlocks; j++)
                {
                    float alpha_i = deltaHorizontalAlpha * i - Fov / 2f;
                    float beta_i = deltaVerticalBeta * j - Vfov / 2f;

                    Ray buff = new(CoordinateSyst, Position, initialDirectionVector);
                    buff.Normalize();
                    buff.Direction = initialDirectionVector.Rotate(alpha_i, alpha_i, 0);
                    buff.Direction = buff.Direction.Rotate(beta_i, 0, beta_i);

                    allRays[i, j] = buff;
                }
            }

            return allRays;
        }
    }
}
