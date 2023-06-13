using GameEng.lib.BasicMath;
using GameEng.lib.GameEngine;
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
        int _horizontal, _vertical, _drawDistance;
        Matrix _distances;
        Game _game;

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

        public int DrawDistance
        {
            get { return _drawDistance; }
            set { _drawDistance = value; }
        }

        public Matrix Distances
        {
            get { return _distances; }
            set { _distances = value; }
        }

        public Game Game_
        {
            get { return _game; }
            set { _game = value; }
        }

        public GameCanvas(GameConfiguration config, Game game)
        {
            _horizontal = config.GetVariable("horizontalBlocks");
            _vertical = config.GetVariable("verticalBlocks");
            _drawDistance = config.GetVariable("drawDistance");
            _distances = new(_horizontal, _vertical);
            _game = game;
        }

        public abstract void Draw(GameCamera gameCamera);

        public abstract void Update(GameCamera gameCamera);
    }
}
