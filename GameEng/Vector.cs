using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using MatrixNamespace;
using VectorSpaceNamespace;

namespace VectorNamespace
{
    class Vector : Matrix
    {
        public Vector(int N, int M) : base (N, M) 
        {

        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            if (vector1.N != vector2.N) throw new Exception("Sum of vectors could not be defined: vector1.N != vector2.N");

            Vector vectorNew = new(vector1.N, 1);

            for (int i = 0; i <  vector1.N; i++)
            {
                vectorNew.CurrentMatrix[i, 0] = vector1.CurrentMatrix[i, 0] + vector2.CurrentMatrix[i, 0];
            }

            return vectorNew;
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            if (vector1.N != vector2.N) throw new Exception("Difference of vectors could not be defined: vector1.N != vector2.N");

            Vector vectorNew = new(vector1.N, vector2.M);

            for (int i = 0; i < vector1.N; i++)
            {
                vectorNew.CurrentMatrix[i, 0] = vector1.CurrentMatrix[i, 0] - vector2.CurrentMatrix[i, 0];
            }

            return vectorNew;
        }

        public static Vector operator *(Vector vector, float number)
        {
            Vector vectorNew = new(vector.N, vector.M);

            for (int i = 0; i < vector.N; i++)
            {
                vectorNew.CurrentMatrix[i, 0] = vector.CurrentMatrix[i, 0] * number;
            }

            return vectorNew;
        }

        public static Vector operator *(float number, Vector vector)
        {
            Vector vectorNew = new(vector.N, vector.M);

            for (int i = 0; i < vector.N; i++)
            {
                vectorNew.CurrentMatrix[i, 0] = vector.CurrentMatrix[i, 0] * number;
            }

            return vectorNew;
        }

        public static Vector operator /(Vector vector, float number)
        {
            Vector vectorNew = new(vector.N, vector.M);

            for (int i = 0; i < vector.N; i++)
            {
                vectorNew.CurrentMatrix[i, 0] = vector.CurrentMatrix[i, 0] / number;
            }

            return vectorNew;
        }

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
            if (N != 3) throw new Exception("Cross product could not be defined: N != 3");

            Vector crossProduct = new(3, 1);

            crossProduct.CurrentMatrix[0, 0] = CurrentMatrix[1, 0] * vector.CurrentMatrix[2, 0] - vector.CurrentMatrix[1, 0] * CurrentMatrix[2, 0];
            crossProduct.CurrentMatrix[1, 0] = CurrentMatrix[0, 0] * vector.CurrentMatrix[1, 0] - vector.CurrentMatrix[0, 0] * CurrentMatrix[1, 0];
            crossProduct.CurrentMatrix[2, 0] = vector.CurrentMatrix[0, 0] * CurrentMatrix[2, 0] - CurrentMatrix[0, 0] * vector.CurrentMatrix[2, 0];
            
            return crossProduct;
        }

        public static float Length(Vector vector)
            => vector.ScalarProduct(vector);
    }
}
