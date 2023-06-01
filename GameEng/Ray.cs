using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngNamespace;

namespace Engine
{
    public class Ray
    {
        private CoordinateSystem _coordSystem;
        private Point _initialPoint;
        private Vector _direction;

        public CoordinateSystem CoordSystem
        {
            get { return _coordSystem; }
            set { _coordSystem = value; }
        }

        public Point InitialPoint
        {
            get { return _initialPoint; }
            set { _initialPoint = value; }
        }

        public Vector Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Ray(CoordinateSystem coordSystem, Point initalPoint, Vector direction) 
        {
            _coordSystem = coordSystem;
            _initialPoint = initalPoint;
            _direction = direction;
        }
    }
}
