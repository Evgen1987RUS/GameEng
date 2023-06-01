using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using GameEngNamespace;

namespace GameEng
{
    public class GameCamera : GameObject
    {
        float _fov, _vfov, _drawDistance;
        Point _lookAt;

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

    }
}
