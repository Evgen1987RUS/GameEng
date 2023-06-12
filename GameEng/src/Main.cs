using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEng.lib.GameEngine;
using GameEng.lib.BasicMath;
using GameEng.lib.Engine.BasicClasses;
using GameEng.lib.Engine.Visualization;
using System.ComponentModel;

namespace GameEng.src 
{
    public class Program
    {
        public static void Main() 
        {
            Vector basis1 = new(3, 1), basis2 = new(3, 1), basis3 = new(3, 1), initialDirection = new(3, 1);
            Point initialPointCam = new(3, 1);
            float[,] basis1array = 
            {
                { 1 },
                { 0 },
                { 0 } 
            };

            float[,] basis2array =
            {
                { 0 },
                { 1 },
                { 0 }
            };

            float[,] basis3array =
            {
                { 0 },
                { 0 },
                { 1 }
            };

            float[,] initialPointArray =
            {
                { 0 },
                { 0 },
                { 0 }
            };
            
            basis1.CurrentMatrix = basis2array; basis2.CurrentMatrix = basis2array; basis3.CurrentMatrix = basis3array; initialDirection.CurrentMatrix = initialPointArray;
            initialPointCam.CurrentMatrix = initialPointArray;

            CoordinateSystem cs = new(new Point(3, 1), new VectorSpace(3, basis1, basis2, basis3));
            GameConfiguration config = new("../config/default.config");

            Game game = new(cs,
                new EntitiesList(new List<Entity>()), config, new GameCamera(cs, initialPointCam, initialDirection, config, true));
            
            game.Run();
        }
    }
}
