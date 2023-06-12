using GameEng.lib.Engine.BasicClasses;
using GameEng.lib.Engine.Visualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.lib.GameEngine
{
    public class GameConsole : GameCanvas
    {
        string _charmap = ".:;><+r*zsvfwqkP694VOGbUAKXH8RD#$B0MNWQ%&@&@";

        public string Charmap
        {
            get { return _charmap; }
            set { _charmap = value; }
        }

        public GameConsole(GameConfiguration config, Game game) : base(config, game) { }

        public override void Draw(GameCamera camera)
        {
            Update(camera);
            string canvas = "";

            for (int i = 0; i < Horizontal; i++)
            {
                for (int j = 0; j < Vertical; j++)
                {
                    canvas += GetChar(i, j, camera);
                }

                canvas += "\n";
            }

            Console.Clear();
            Console.Write(canvas);
        }

        public char GetChar(int i, int j, GameCamera gameCamera)
        {
            if (Distances.CurrentMatrix[i, j] == -1)
                return Charmap[Charmap.Length - 1];

            return Charmap[(int)(Distances.CurrentMatrix[i, j] / (float)gameCamera.DrawDistance)];
        }

        public override void Update(GameCamera gameCamera)
        {
            Ray[,] rays = gameCamera.GetRays(Horizontal, Vertical);

            for (int i = 0; i < Horizontal; i++)
            {
                for (int j = 0; j < Vertical; j++)
                {
                    Distances.CurrentMatrix[i, j] = -1;

                    foreach (GameObject gameObject in Game_.Entities)
                    {
                        float intersectionDistance = gameObject.IntersectionDistance(rays[i, j]);
                        if (intersectionDistance == -1 || intersectionDistance > DrawDistance)
                            continue;
                        if (Distances.CurrentMatrix[i, j] == -1 || Distances.CurrentMatrix[i, j] > intersectionDistance)
                            Distances.CurrentMatrix[i, j] = intersectionDistance;
                    }
                }
            }
        }
    }
}
