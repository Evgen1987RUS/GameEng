using GameEng.lib.BasicMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.lib.Engine.Visualization
{
    public class GameCanvas
    {
        int _horizontal, _vertical;
        Matrix _distances;

        public int Horizontal
        {
            get { return _horizontal; }
            set { _horizontal = value; }
        }

        public int Vertical
        {
            get { return _vertical; }
            set { _vertical = value; }
        }

        public Matrix Distances
        {
            get { return _distances; }
            set { _distances = value; }
        }

        public GameCanvas(int horizontal, int vertical) 
        {
            _horizontal = horizontal;
            _vertical = vertical;
            _distances = new(_horizontal, _vertical);
        }

        public void Draw()
        {

        }

        public void Update(GameCamera gameCamera)
        {

        }
    }
}
