using System;
using VectorNamespace;

namespace PointNamespace
{
    class Point : Vector
    {
        public Point(int N, int M) : base(N, M) 
        { 
            
        }

        public static Point operator +(Point point, Vector vector)
        {
            if (point.N != vector.N) throw new Exception("Sum of point and vector could not be defined: point.N != vector.N");

            Point pointNew = new(point.N, 1);

            for (int i = 0; i < point.N; i++)
            {
                pointNew.CurrentMatrix[i, 0] = point.CurrentMatrix[i, 0] + vector.CurrentMatrix[i, 0];
            }

            return pointNew;
        }

        public static Point operator -(Point point, Vector vector)
        {
            if (point.N != vector.N) throw new Exception("Sum of point and vector could not be defined: point.N != vector.N");

            Point pointNew = new(point.N, 1);

            for (int i = 0; i < point.N; i++)
            {
                pointNew.CurrentMatrix[i, 0] = point.CurrentMatrix[i, 0] - vector.CurrentMatrix[i, 0];
            }

            return pointNew;
        }

    }
}