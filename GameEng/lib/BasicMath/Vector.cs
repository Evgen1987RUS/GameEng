using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.lib.BasicMath
{
    public class Vector : Matrix
    {
        public Vector(int N, int M) : base(N, M) { }

        public static float operator %(Vector vector1, Vector vector2)
            => vector1.ScalarProduct(vector2);

        public static Vector operator ^(Vector vector1, Vector vector2)
            => vector1.CrossProduct(vector2);

        public float ScalarProduct(Vector vector)
        {
            float scalarProduct = 0;

            for (int i = 0; i < N; i++)
            {
                scalarProduct += CurrentMatrix[i, 0] * vector.CurrentMatrix[i, 0];
            }

            return scalarProduct;
        }

        public Vector CrossProduct(Vector vector)
        {
            if (N != 3) throw new EngineExceptions.MutualExceptions.BadInput();

            Vector crossProduct = new(3, 1);

            crossProduct.CurrentMatrix[0, 0] = CurrentMatrix[1, 0] * vector.CurrentMatrix[2, 0] - vector.CurrentMatrix[1, 0] * CurrentMatrix[2, 0];
            crossProduct.CurrentMatrix[1, 0] = -CurrentMatrix[0, 0] * vector.CurrentMatrix[2, 0] + vector.CurrentMatrix[0, 0] * CurrentMatrix[2, 0];
            crossProduct.CurrentMatrix[2, 0] = vector.CurrentMatrix[1, 0] * CurrentMatrix[0, 0] - CurrentMatrix[1, 0] * vector.CurrentMatrix[0, 0];

            return crossProduct;
        }

        public float Length()
            => ScalarProduct(this);
    }
}
