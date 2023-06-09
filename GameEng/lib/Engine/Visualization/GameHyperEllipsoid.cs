using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameEng.lib.BasicMath;
using GameEng.lib.Engine.BasicClasses;

namespace GameEng.lib.Engine.Visualization
{
    public class GameHyperEllipsoid : GameObject
    {
        List<float> _semiaxes = new();

        public List<float> SemiAxes 
        { 
            get { return _semiaxes; }
            set { _semiaxes = value; }
        }

        public GameHyperEllipsoid(CoordinateSystem coordinateSystem, Point position, Vector direction, List<float> semiaxes) : base(coordinateSystem, position, direction) 
        {
            _semiaxes = semiaxes;    
        }

        public override float? IntersectionDistance(Ray ray) // TODO: Intersection distance for hyper ellipsoid
        {
            float localLength_utility(float x, float y, float z)
            {
                return ((x - ray.InitialPoint.CurrentMatrix[0, 0]) * (x - ray.InitialPoint.CurrentMatrix[0, 0]) + (y - ray.InitialPoint.CurrentMatrix[1, 0]) * (y - ray.InitialPoint.CurrentMatrix[1, 0]) + (z - ray.InitialPoint.CurrentMatrix[2, 0]) * (z - ray.InitialPoint.CurrentMatrix[2, 0]));
            }

            float
                x0 = Position.CurrentMatrix[0, 0], y0 = Position.CurrentMatrix[1, 0], z0 = Position.CurrentMatrix[2, 0],
                x_ray = ray.InitialPoint.CurrentMatrix[0, 0], y_ray = ray.InitialPoint.CurrentMatrix[1, 0], z_ray = ray.InitialPoint.CurrentMatrix[2, 0],
                p1 = ray.Direction.CurrentMatrix[0, 0], p2 = ray.Direction.CurrentMatrix[1, 0], p3 = ray.Direction.CurrentMatrix[2, 0],
                a = _semiaxes[0], b = _semiaxes[1], c = _semiaxes[2],
                aSq = a * a, bSq = b * b, cSq = c * c;


            float // equations such as (x - x0) / p1 = (y - y0) / p2  = (z - z0) / p3
                k_for_y = p2 / p1, b_for_y = p2 / p1 * x_ray + y_ray,
                k_for_z = p3 / p1, b_for_z = p3 / p1 * x_ray + z_ray;

            float
                aQuadratic = bSq * cSq + aSq * cSq * k_for_y * k_for_y + aSq * bSq * k_for_z * k_for_z,
                bQuadratic = 2 * k_for_y * b_for_y + 2 * k_for_z * b_for_z,
                cQuadratic = b_for_y * b_for_y + b_for_z * b_for_z - aSq * bSq * cSq;

            float discriminant = bQuadratic * bQuadratic - 4 * aQuadratic * cQuadratic;

            if (discriminant < 0)
            {
                return null;
            }
            else if (discriminant == 0) 
            {
                float xOfIntersection = -bSq / (2 * aSq);

                float
                    yOfIntersection = k_for_y * xOfIntersection + b_for_y,
                    zOfIntersection = k_for_z * xOfIntersection + b_for_z;

                return localLength_utility(xOfIntersection, yOfIntersection, zOfIntersection);
            }

            float 
                x1OfIntersection = (-bSq + (float)Math.Sqrt(discriminant)) / (2 * aSq),
                x2OfIntersection = (-bSq - (float)Math.Sqrt(discriminant)) / (2 * aSq);

            float
                y1OfIntersection = k_for_y * x1OfIntersection + b_for_y,
                z1OfIntersection = k_for_z * x1OfIntersection + b_for_z,
                y2OfIntersection = k_for_y * x2OfIntersection + b_for_y,
                z2OfIntersection = k_for_z * x2OfIntersection + b_for_z;

            if (localLength_utility(x1OfIntersection, y1OfIntersection, z1OfIntersection) < localLength_utility(x2OfIntersection, y2OfIntersection, z2OfIntersection))
            {
                return localLength_utility(x1OfIntersection, y1OfIntersection, z1OfIntersection);
            }
            else
            {
                return localLength_utility(x2OfIntersection, y2OfIntersection, z2OfIntersection);
            }
        }

        public override void Rotation_3D(float angleX, float angleY, float angleZ)
        {
            Direction = Direction.Rotate(angleX, angleY, angleZ);
        }
    }
}
