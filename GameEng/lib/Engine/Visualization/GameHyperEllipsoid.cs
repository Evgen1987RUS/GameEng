using System;
using System.Collections.Generic;
using System.Linq;
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

        public override float? IntersectionDistance(Ray ray)
        {
            throw new NotImplementedException();
        }

        public override void Rotation_3D(float angleX, float angleY, float angleZ)
        {
            throw new NotImplementedException();
        }
    }
}
