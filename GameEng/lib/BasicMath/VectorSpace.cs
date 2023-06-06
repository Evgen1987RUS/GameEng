using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEng.lib.BasicMath
{
    public class VectorSpace
    {
        private int _dimension;
        private Vector[] _basis;

        public int Dimension
        {
            get { return _dimension; }
            set { _dimension = value; }
        }

        public Vector[] Basis
        {
            get { return _basis; }
            set { _basis = value; }
        }

        public VectorSpace(int dimension, params Vector[] args)
        {
            _dimension = dimension;
            _basis = new Vector[dimension];

            for (int i = 0; i < _dimension; i++)
            {
                _basis[i] = args[i];
            }
        }

        public float ScalarProduct(Vector vector1, Vector vector2)
            => (vector1.Transpose() * Matrix.GramMatrix(Basis) * vector2).CurrentMatrix[0, 0];

        public Vector PointToVector(Point point)
        {
            Vector vector = new(point.N, 1);

            for (int i = 0; i < Dimension; i++)
            {
                Console.WriteLine(Basis[i]);
                vector += Basis[i] * point.CurrentMatrix[i, 0];
            }

            return vector;

        }

    }
}
