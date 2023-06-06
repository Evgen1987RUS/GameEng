using System;
using GameEng.lib.BasicMath;

public class Program
{
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

    private static void Main() { }
}