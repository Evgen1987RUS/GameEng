using System;
using MatrixNamespace;
using PointNamespace;
using VectorNamespace;
using VectorSpaceNamespace;
using CoordinateSystemNamespace;

internal class Program
{
    public static float BilinearForm(Matrix matrix, Vector vector1, Vector vector2)
    {
        if (matrix.N != matrix.M) throw new Exception("Bilinear form could not be defined: matrix is not square");
        if (vector1.N != vector2.N) throw new Exception("Bilinear form could not be defined: vector1.N != vector2.N");
        if (vector1.N != matrix.N) throw new Exception("Bilinear form could not be defined: vector1.N == vector2.N != matrix.N");

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

    private static void Main()
    {
        // тесты для всех перегрузок и методов
        float[] array1 = { 1, 2, 3, 5, 6, 7, 9, 10, 10 }, array2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        float number = 5;
        int forIdentityCheck = 3;

        Matrix matrix1 = new(3, 3), matrix2 = new(3, 3);
        matrix1.Insert(array1);
        matrix2.Insert(array2);

        Console.WriteLine("Матрица 1: ");
        Matrix.Print(matrix1);

        Console.WriteLine("Матрица 2: ");
        Matrix.Print(matrix2);

        Console.WriteLine("Сложение матриц: ");
        Matrix.Print(matrix1 + matrix2);

        Console.WriteLine("Разность матриц: ");
        Matrix.Print(matrix1 - matrix2); 

        Console.WriteLine("Умножение матрицы на матрицу: ");
        Matrix.Print(matrix1 * matrix2);

        Console.WriteLine("Умножение матрицы на скаляр: ");
        Matrix.Print(matrix1 * number);
        Matrix.Print(number * matrix1);

        Console.WriteLine("Деление матрицы на скаляр: ");
        Matrix.Print(matrix1 / number);

        Console.WriteLine("Определитель матрицы: ");
        Console.WriteLine(matrix1.Determinant() + "\n");

        Console.WriteLine("Транспонированная матрица: ");
        Matrix.Print(matrix1.Transpose());
        Matrix.Print(matrix1);
        matrix1.Transpose();

        Console.WriteLine("Обратная матрица: ");
        Matrix.Print(matrix1.Inverse());

        Console.WriteLine("Единичная матрица: ");
        Matrix.Print(Matrix.Identity(forIdentityCheck));

        /* ------------------------------------------------------------------------------------- */

        float[] vectorArray1 = { 1, 10, -3 }, vectorArray2 = { 12, 4, -10 }, basis1Array = { 1, 2, 10 }, basis2Array = { -5, 1, 6 }, basis3Array = { 3, 9, 1 };

        Vector vector1 = new(3, 1), vector2 = new(3, 1), basis1 = new(3, 1), basis2 = new(3, 1), basis3 = new(3, 1);
        vector1.Insert(vectorArray1);
        vector2.Insert(vectorArray2);
        basis1.Insert(basis1Array);
        basis2.Insert(basis2Array);
        basis3.Insert(basis3Array);

        VectorSpace vectorSpace = new(3, basis1, basis2, basis3);

        Console.WriteLine("Вектор 1: ");
        Vector.Print(vector1);

        Console.WriteLine("Вектор 2: ");
        Vector.Print(vector2);

        Console.WriteLine("Базис: ");
        Vector.Print(basis1);
        Vector.Print(basis2);
        Vector.Print(basis3);

        /* ------------------------------------------------------------------------------------- */

        Console.WriteLine("Матрица Грама: ");
        Matrix.Print(Matrix.GramMatrix(vectorSpace.Basis[0], vectorSpace.Basis[1], vectorSpace.Basis[2]));

        /* ------------------------------------------------------------------------------------- */

        Console.WriteLine("Сложение векторов: ");
        Vector.Print(vector1 + vector2);

        Console.WriteLine("Разность векторов: ");
        Vector.Print(vector1 - vector2);

        Console.WriteLine("Умножение вектора на скаляр: ");
        Vector.Print(vector1 * number);
        Vector.Print(number * vector1);

        Console.WriteLine("Деление вектора на скаляр: ");
        Vector.Print(vector1 / number);

        Console.WriteLine("Билинейная форма: ");
        Console.WriteLine(Program.BilinearForm(matrix1, vector1, vector2) + "\n");

        Console.WriteLine("Скалярное произведение: ");
        Console.WriteLine(vector1.ScalarProduct(vector2) + "\n");

        Console.WriteLine("Векторное произведение: ");
        Vector.Print(vector1.CrossProduct(vector2));

        Console.WriteLine("Скалярное произведение (через перегрузку): ");
        Console.WriteLine(vector1 % vector2 + "\n");

        Console.WriteLine("Векторное произведение (через перегрузку): ");
        Vector.Print(vector1 ^ vector2);

        Console.WriteLine("Длина вектора: ");
        Console.WriteLine(Vector.Length(vector1) + "\n");

        Console.WriteLine("Скалярное произведение (через матрицу Грама): ");
        Console.WriteLine(vectorSpace.ScalarProduct(vector1, vector2) + "\n");

        /* ------------------------------------------------------------------------------------- */

        Point point = new(3, 1);
        float[] pointArray= { 20, -10, 15 };
        point.Insert(pointArray);

        Console.WriteLine("Переход точки в вектор: ");
        Vector.Print(vectorSpace.PointToVector(point));

        Console.WriteLine("Сумма точки и вектора: ");
        Point.Print(point + vector1);

        Console.WriteLine("Разность точки и вектора: ");
        Point.Print(point - vector1);

        /* ------------------------------------------------------------------------------------- */

        CoordinateSystem coordinateSystem = new(point, vectorSpace);

        Console.WriteLine("Базис в системе координат: ");
        Vector.Print(vectorSpace.Basis[0]);
        Vector.Print(vectorSpace.Basis[1]);
        Vector.Print(vectorSpace.Basis[2]);
    }
}