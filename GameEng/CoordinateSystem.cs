﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngNamespace
{
    class CoordinateSystem
    {
        Point _point;
        VectorSpace _vectorSpace;

        public Point Point
        {
            get { return _point; }
            set { _point = value; }
        }

        public VectorSpace VectorSpace
        {
            get { return _vectorSpace; }
            set { _vectorSpace = value; }
        }

        public CoordinateSystem(Point point, VectorSpace vectorSpace)
        {
            _point = point;
            _vectorSpace = vectorSpace;
        }
    }
}
