using GameEng.lib.Exceptions;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;

namespace GameEng.lib.BasicMath
{
    public class Matrix
    {
        private int _n, _m;
        private float[,] _matrix;

        public int N
        {
            get { return _n; }
            set { _n = value; }
        }

        public int M
        {
            get { return _m; }
            set { _m = value; }
        }

        public float[,] CurrentMatrix
        {
            get { return _matrix; }
            set { _matrix = value; }
        }

        public Matrix(int n, int m)
        {
            _n = n;
            _m = m;
            _matrix = new float[N, M];
        }

        public bool isEqual(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.N != matrix2.N || matrix1.M != matrix2.M) { throw new EngineExceptions.InMatrixExceptions.BadSize(); }

            for (int i = 0; i < matrix1.N; i++)
            {
                for (int j = 0; j < matrix2.M; j++)
                {
                    if (matrix1.CurrentMatrix[i, j] != matrix2.CurrentMatrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static dynamic operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.N != matrix2.N || matrix1.M != matrix2.M) throw new EngineExceptions.InMatrixExceptions.BadSize();

            dynamic matrixNew = matrix1.GetType().GetConstructor(new Type[] { typeof(int), typeof(int) })!.Invoke(new object[] { matrix1.N, matrix1.M });

            for (int i = 0; i < matrix1.N; i++)
            {
                for (int j = 0; j < matrix1.M; j++)
                {
                    matrixNew.CurrentMatrix[i, j] = matrix1.CurrentMatrix[i, j] + matrix2.CurrentMatrix[i, j];
                }
            }

            return matrixNew;
        }

        public static dynamic operator -(Matrix matrix1, Matrix matrix2)
        {
            return matrix1 + matrix2 * -1;
        }

        public static dynamic operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.M != matrix2.N) throw new EngineExceptions.InMatrixExceptions.BadSize();

            int counter = 0;

            dynamic matrixNew = matrix1.GetType().GetConstructor(new Type[] { typeof(int), typeof(int) })!.Invoke(new object[] { matrix1.N, matrix2.M });

            for (int i = 0; i < matrix1.N; i++)
            {
                for (; counter < matrix2.M; counter++)
                {
                    for (int j = 0; j < matrix1.M; j++)
                    {
                        matrixNew.CurrentMatrix[i, counter] += matrix1.CurrentMatrix[i, j] * matrix2.CurrentMatrix[j, counter];
                    }
                }

                counter = 0;
            }

            return matrixNew;
        }

        public static dynamic operator *(Matrix matrix, float number)
        {
            dynamic matrixNew = matrix.GetType().GetConstructor(new Type[] { typeof(int), typeof(int) })!.Invoke(new object[] { matrix.N, matrix.M });

            for (int i = 0; i < matrix.N; i++)
            {
                for (int j = 0; j < matrix.M; j++)
                {
                    matrixNew.CurrentMatrix[i, j] = matrix.CurrentMatrix[i, j] * number;
                }
            }

            return matrixNew;
        }

        public static dynamic operator *(float number, Matrix matrix)
            => matrix * number;

        public static dynamic operator /(Matrix matrix, float number)
        {
            if (number == 0) throw new EngineExceptions.InMatrixExceptions.DivisionByZero();

            dynamic matrixNew = matrix.GetType().GetConstructor(new Type[] { typeof(int), typeof(int) })!.Invoke(new object[] { matrix.N, matrix.M });

            matrixNew = matrix * (1 / number);

            return matrixNew;
        }

        private Matrix CreateMatrixWithoutColumn(int column)
        {
            if (column < 0 || column >= M) throw new EngineExceptions.InMatrixExceptions.OutOfDimensions();

            Matrix matrixNew = new(N, M - 1);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (j < column)
                    {
                        matrixNew.CurrentMatrix[i, j] = CurrentMatrix[i, j];
                    }
                    else if (j > column)
                    {
                        matrixNew.CurrentMatrix[i, j - 1] = CurrentMatrix[i, j];
                    }
                }
            }

            return matrixNew;
        }

        private Matrix CreateMatrixWithoutRow(int row)
        {
            if (row < 0 || row >= N) throw new EngineExceptions.InMatrixExceptions.OutOfDimensions();

            Matrix matrixNew = new(N - 1, M);

            for (int i = 0; i < N; i++)
            {
                if (i == row)
                {
                    continue;
                }

                for (int j = 0; j < M; j++)
                {
                    if (i < row)
                    {
                        matrixNew.CurrentMatrix[i, j] = CurrentMatrix[i, j];
                    }
                    else if (i > row)
                    {
                        matrixNew.CurrentMatrix[i - 1, j] = CurrentMatrix[i, j];
                    }
                }
            }

            return matrixNew;
        }

        public float Determinant()
        {
            if (N != M) throw new EngineExceptions.InMatrixExceptions.BadSize();

            if (N == 1)
            {
                return CurrentMatrix[0, 0];
            }
            else if (N == 2)
            {
                return CurrentMatrix[0, 0] * CurrentMatrix[1, 1] - CurrentMatrix[0, 1] * CurrentMatrix[1, 0];
            }
            else
            {
                float determinant = 0;

                for (int i = 0; i < M; i++)
                {
                    determinant += (i % 2 == 0 ? 1 : -1) * CurrentMatrix[0, i] * CreateMatrixWithoutColumn(i).CreateMatrixWithoutRow(0).Determinant();
                }

                return determinant;
            }
        }

        public Matrix Inverse()
        {
            if (N != M) throw new EngineExceptions.InMatrixExceptions.BadSize();
            if (Determinant() == 0) throw new EngineExceptions.InMatrixExceptions.DeterminantEqualsZero();

            Matrix cofactorMatrix = new(N, M);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    cofactorMatrix.CurrentMatrix[i, j] = ((i + j) % 2 == 0 ? 1 : -1) * CreateMatrixWithoutColumn(j).CreateMatrixWithoutRow(i).Determinant();
                }
            }

            return cofactorMatrix.Transpose() / Determinant();
        }

        public Matrix Transpose()
        {
            Vector transposedMatrix = new(M, N);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    transposedMatrix.CurrentMatrix[j, i] = CurrentMatrix[i, j];
                }
            }

            return transposedMatrix;
        }

        public static Matrix Identity(int n)
        {
            Matrix matrixNew = new(n, n);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        matrixNew.CurrentMatrix[i, j] = 1;
                    }

                    else
                    {
                        matrixNew.CurrentMatrix[i, j] = 0;
                    }
                }
            }

            return matrixNew;
        }

        public static Matrix GramMatrix(params Vector[] args)
        {
            Matrix gramMatrix = new(args.Length, args.Length);

            for (int i = 0; i < gramMatrix.N; i++)
            {
                for (int j = 0; j < gramMatrix.N; j++)
                {
                    gramMatrix.CurrentMatrix[i, j] = args[i].ScalarProduct(args[j]);
                }
            }

            return gramMatrix;
        }

        public dynamic Rotate(params float[] args)
        {
            dynamic rotatedMatrix = GetType().GetConstructor(new Type[] { typeof(int), typeof(int) })!.Invoke(new object[] { N, M });

            for (int i = 0; i < args.Length; i++)
                args[i] = args[i] * ((float)Math.PI / 180);

            if (N == 2)
            {
                if (args.Length != 1)
                    throw new EngineExceptions.MutualExceptions.BadInput();

                rotatedMatrix.CurrentMatrix[0, 0] = CurrentMatrix[0, 0] * (float)Math.Cos(args[0]) - CurrentMatrix[1, 0] * (float)Math.Sin(args[0]);
                rotatedMatrix.CurrentMatrix[1, 0] = CurrentMatrix[0, 0] * (float)Math.Sin(args[0]) + CurrentMatrix[1, 0] * (float)Math.Cos(args[0]);

                return rotatedMatrix;
            }
            else if (N == 3)
            {
                if (args.Length != 3)
                    throw new EngineExceptions.MutualExceptions.BadInput();

                Matrix rotationMatrix = new(3, 3);

                float sinAlpha = (float)Math.Sin(args[0]),
                      cosAlpha = (float)Math.Cos(args[0]),
                      sinBeta = (float)Math.Sin(args[1]),
                      cosBeta = (float)Math.Cos(args[1]),
                      sinGamma = (float)Math.Sin(args[2]),
                      cosGamma = (float)Math.Cos(args[2]);

                float[,] arrayForInsert = { { cosBeta * cosGamma, -sinGamma * cosBeta, sinBeta },
                                            { sinAlpha * sinBeta * cosGamma + sinGamma * cosAlpha, -sinAlpha * sinBeta * sinGamma + cosAlpha * cosGamma, -sinAlpha * cosBeta },
                                            { sinAlpha * sinGamma - sinBeta * cosAlpha * cosGamma, sinAlpha * cosGamma + sinBeta * sinGamma * cosAlpha, cosAlpha * cosBeta } };

                rotationMatrix.CurrentMatrix = arrayForInsert;

                rotatedMatrix = rotationMatrix * this;

                return rotatedMatrix;
            }
            else
                throw new EngineExceptions.MutualExceptions.BadInput();
        }

        public static float BilinearForm(Matrix matrix, Vector vector1, Vector vector2)
        {
            if (matrix.N != matrix.M) throw new GameEng.lib.Exceptions.EngineExceptions.InMatrixExceptions.BadSize();
            if (vector1.N != vector2.N) throw new GameEng.lib.Exceptions.EngineExceptions.InMatrixExceptions.BadSize(); ;
            if (vector1.N != matrix.N) throw new GameEng.lib.Exceptions.EngineExceptions.InMatrixExceptions.BadSize(); ;

            float sum = 0;

            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.N; j++)
                {
                    sum += matrix.CurrentMatrix[i, j] * vector1.CurrentMatrix[i, 0] * vector2.CurrentMatrix[j, 0];
                }
            }

            return sum;
        }

        public static void Print(Matrix matrix)
        {
            for (int i = 0; i < matrix.N; i++)
            {
                for (int j = 0; j < matrix.M; j++)
                {
                    Console.Write(matrix.CurrentMatrix[i, j] + " ");
                }
                Console.Write("\n");
            }

            Console.WriteLine();
        }
    }
}