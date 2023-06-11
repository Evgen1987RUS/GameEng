using GameEng.lib.BasicMath;
using GameEng.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.lib.Engine.Visualization
{
    public abstract class GameCanvas
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

        public GameCanvas(GameConfiguration config) 
        {
            _horizontal = config.GetVariable("horizontalBlocks");
            _vertical = config.GetVariable("verticalVlocks");
            _distances = new(_horizontal, _vertical);
        }

        public abstract void Draw();

        public void Update(GameCamera gameCamera)
        {

        }
    }
}
