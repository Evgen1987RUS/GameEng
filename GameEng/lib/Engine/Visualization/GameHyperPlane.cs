using GameEng.lib.BasicMath;
using GameEng.lib.Engine.BasicClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.lib.Engine.Visualization
{
    public class GameHyperPlane : GameObject
    {
        Vector _normal;

        public Vector Normal 
        { 
            get { return _normal; } 
            set { _normal = value; }
        }

        public GameHyperPlane(CoordinateSystem coordinateSystem, Point position, Vector direction, Vector normal) : base(coordinateSystem, position, direction) 
        {
            _normal = normal;
            SetProperty("normal", _normal);
        }

        public override float IntersectionDistance(Ray ray)
        {
            if (Math.Abs(CoordinateSyst.VectorSpace.ScalarProduct(Normal, Direction)) < 0.001)
            {
                if (Math.Abs(CoordinateSyst.VectorSpace.ScalarProduct(Normal, Position - ray.InitialPoint)) < 0.001)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            } 
            else
            {
                Point intersectionPoint = ray.InitialPoint + Direction * (-(Math.Abs(CoordinateSyst.VectorSpace.ScalarProduct(Normal, ray.InitialPoint - Position))) / Math.Abs((CoordinateSyst.VectorSpace.ScalarProduct(Normal, Direction))));
                return CoordinateSyst.VectorSpace.Length(intersectionPoint - ray.InitialPoint);
            }
        }

        public override void Rotation_3D(float angleX, float angleY, float angleZ)
        {
            Normal = Normal.Rotate(angleX, angleY, angleZ);
        }
    }
}
