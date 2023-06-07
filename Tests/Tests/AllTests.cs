using GameEng.lib.BasicMath;
using GameEng.lib.Engine.BasicClasses;

namespace Tests
{
    [TestClass]
    public class MatrixTests
    {
        float[,] arrayForTests1 = {
            { 1, -4, 3 },
            { 2, 10, -5 },
            { 8, 2, 9 }
        };

        float[,] arrayForTests2 = {
            { 2, 6, 1 },
            {-5, -7, 2 },
            { 4, 5, 3 }
        };

        [TestMethod]
        public void MatrixSum()
        {
            float[,] arrayForCorrectAnswer = {
                { 3, 2, 4 },
                { -3, 3, -3 },
                { 12, 7, 12 }
            };

            Matrix matrix1 = new(3, 3), matrix2 = new(3, 3), matrix3 = new(3, 3);
            matrix1.CurrentMatrix = arrayForTests1;
            matrix2.CurrentMatrix = arrayForTests2;

            matrix3 = matrix1 + matrix2;
            Matrix.Print(matrix3);
            Assert.IsInstanceOfType(matrix3, typeof(Matrix));


/*            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix3.CurrentMatrix[i, j], arrayForCorrectAnswer[i, j]);
                }
            }*/
        }

        [TestMethod]
        public void MatrixDifference()
        {
            float[,] arrayForCorrectAnswer = {
                { -1, -10, 2 },
                { 7, 17, -7 },
                { 4, -3, 6 }
            };

            Matrix matrix1 = new(3, 3), matrix2 = new(3, 3), matrix3 = new(3, 3);
            matrix1.CurrentMatrix = arrayForTests1;
            matrix2.CurrentMatrix = arrayForTests2;

            matrix3 = matrix1 - matrix2;
            Assert.IsInstanceOfType(matrix3, typeof(Matrix));

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix3.CurrentMatrix[i, j], arrayForCorrectAnswer[i, j]);
                }
            }
        }

        [TestMethod]
        public void MatricesMultiplication()
        {
            float[,] arrayForCorrectAnswer = {
                { 34, 49, 2 },
                { -66, -83, 7 },
                { 42, 79, 39 }
            };

            Matrix matrix1 = new(3, 3), matrix2 = new(3, 3), matrix3 = new(3, 3);
            matrix1.CurrentMatrix = arrayForTests1;
            matrix2.CurrentMatrix = arrayForTests2;

            matrix3 = matrix1 * matrix2;
            Assert.IsInstanceOfType(matrix3, typeof(Matrix));

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix3.CurrentMatrix[i, j], arrayForCorrectAnswer[i, j]);
                }
            }
        }

        [TestMethod]
        public void MatrixNumberMultipliction()
        {
            float[,] arrayForCorrectAnswer = {
                { 2, -8, 6 },
                { 4, 20, -10 },
                { 16, 4, 18 }
            };

            Matrix matrix1 = new(3, 3), matrix2 = new(3, 3);
            matrix1.CurrentMatrix = arrayForTests1;

            matrix2 = matrix1 * 2;
            Assert.IsInstanceOfType(matrix2, typeof(Matrix));

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix2.CurrentMatrix[i, j], arrayForCorrectAnswer[i, j]);
                }
            }
        }

        [TestMethod]
        public void NumberMatrixMultipliction()
        {
            float[,] arrayForCorrectAnswer = {
                { 2, -8, 6 },
                { 4, 20, -10 },
                { 16, 4, 18 }
            };

            Matrix matrix1 = new(3, 3), matrix2 = new(3, 3);
            matrix1.CurrentMatrix = arrayForTests1;

            matrix2 = 2 * matrix1;
            Assert.IsInstanceOfType(matrix2, typeof(Matrix));

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix2.CurrentMatrix[i, j], arrayForCorrectAnswer[i, j]);
                }
            }
        }

        [TestMethod]
        public void MatrixNumberDivision()
        {
            float[,] arrayForCorrectAnswer = {
                { 0.5f, -2, 1.5f },
                { 1, 5, -2.5f },
                { 4, 1, 4.5f }
            };

            Matrix matrix1 = new(3, 3), matrix2 = new(3, 3);
            matrix1.CurrentMatrix = arrayForTests1;

            matrix2 = matrix1 / 2;
            Assert.IsInstanceOfType(matrix2, typeof(Matrix));

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix2.CurrentMatrix[i, j], arrayForCorrectAnswer[i, j]);
                }
            }
        }

        [TestMethod]
        public void MatrixDeterminant()
        {
            Matrix matrix = new(3, 3);
            matrix.CurrentMatrix = arrayForTests1;
            Assert.AreEqual(matrix.Determinant(), 104);
        }

        [TestMethod]
        public void MatrixTranspose()
        {
            float[,] arrayForCorrectAnswer = {
                { 1, 2, 8 },
                { -4, 10, 2 },
                { 3, -5, 9 }
            };

            Matrix matrix = new(3, 3), matrixTransposed = new(3, 3);
            matrix.CurrentMatrix = arrayForTests1;
            matrixTransposed = matrix.Transpose();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrixTransposed.CurrentMatrix[i, j], arrayForCorrectAnswer[i, j]);
                }
            }
        }

        [TestMethod]
        public void MatrixInverse()
        {
            float[,] arrayForCorrectAnswer = {
                { 25f / 26f, 21f / 52f, -5f / 52f },
                { -29f / 52f, -15f / 104f, 11f / 104f },
                { -19f / 26f, -17f / 52f, 9f / 52f }
            };

            Matrix matrix = new(3, 3), matrixInverse = new(3, 3);
            matrix.CurrentMatrix = arrayForTests1;
            matrixInverse = matrix.Inverse();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(String.Format("{0:0.000}", matrixInverse.CurrentMatrix[i, j]), String.Format("{0:0.000}", arrayForCorrectAnswer[i, j]));
                }
            }

        }

        [TestMethod]
        public void MatrixIdentityCheck()
        {
            float[,] arrayForCorrectAnswer = {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };

            Matrix matrix = new(3, 3);
            matrix = Matrix.Identity(3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix.CurrentMatrix[i, j], arrayForCorrectAnswer[i, j]);
                }
            }
        }

/*        [TestMethod]
        public void MatrixRotation()
        {
            float[,] arrayForCorrectAnswer = {
                { 1f, -4f, 3f, },
                { 2f, 10f, -5f },
                { 8f, 2f, 9f }
            };

            Matrix matrix = new(3, 3);
            matrix.CurrentMatrix = arrayForTests1;
            matrix.Rotate(90, 0, 0);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < 3; j++)
                {
                    //Console.WriteLine(matrix.CurrentMatrix[i, j]);
                    Assert.AreEqual(matrix.CurrentMatrix[i, j], arrayForCorrectAnswer[i, j]);
                }
            }

        }*/
    }

    [TestClass]
    public class VectorTests
    {
        float[,] arrayForTests1 =  {
            { 1 },
            { 2 },
            { 3 }
        };

        float[,] arrayForTests2 =  {
            { 3 },
            { 2 },
            { 1 }
        };

        [TestMethod]
        public void VectorSum()
        {
            float[,] arrayForCorrectAnswer = {
                { 4 },
                { 4 },
                { 4 },
            };

            Vector vector1 = new(3, 1), vector2 = new(3, 1), vector3 = new(3, 1);
            vector1.CurrentMatrix = arrayForTests1;
            vector2.CurrentMatrix = arrayForTests2;

            vector3 = vector1 + vector2;
            Assert.IsInstanceOfType(vector3, typeof(Vector));

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(vector3.CurrentMatrix[i, 0], arrayForCorrectAnswer[i, 0]);
            }
        }

        [TestMethod]
        public void VectorDifference()
        {
            float[,] arrayForCorrectAnswer = {
                { -2 },
                { 0 },
                { 2 },
            };

            Vector vector1 = new(3, 1), vector2 = new(3, 1), vector3 = new(3, 1);
            vector1.CurrentMatrix = arrayForTests1;
            vector2.CurrentMatrix = arrayForTests2;

            vector3 = vector1 - vector2;
            Assert.IsInstanceOfType(vector3, typeof(Vector));

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(vector3.CurrentMatrix[i, 0], arrayForCorrectAnswer[i, 0]);
            }
        }

        [TestMethod]
        public void VectorsScalarProduct()
        {
            Vector vector1 = new(3, 1), vector2 = new(3, 1);
            vector1.CurrentMatrix = arrayForTests1;
            vector2.CurrentMatrix = arrayForTests2;

            Assert.AreEqual(vector1 % vector2, 10);
        }

        [TestMethod]
        public void VectorsCrossProduct()
        {
            float[,] arrayForCorrectAnswer = {
                { -4 },
                { 8 },
                { -4 }
            };

            Vector vector1 = new(3, 1), vector2 = new(3, 1), vector3 = new(3, 1);
            vector1.CurrentMatrix = arrayForTests1;
            vector2.CurrentMatrix = arrayForTests2;

            vector3 = vector1 ^ vector2;
            Assert.IsInstanceOfType(vector3, typeof(Vector));

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(vector3.CurrentMatrix[i, 0], arrayForCorrectAnswer[i, 0]);
            }
        }

        [TestMethod]
        public void MatrixNumberMultipliction()
        {
            float[,] arrayForCorrectAnswer = {
                { 2 },
                { 4 },
                { 6 }
            };

            Vector vector1 = new(3, 1), vector2 = new(3, 1);
            vector1.CurrentMatrix = arrayForTests1;

            vector2 = vector1 * 2;
            Assert.IsInstanceOfType(vector2, typeof(Vector));

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(vector2.CurrentMatrix[i, 0], arrayForCorrectAnswer[i, 0]);
            }
        }

        [TestMethod]
        public void NumberMatrixMultipliction()
        {
            float[,] arrayForCorrectAnswer = {
                { 2 },
                { 4 },
                { 6 }
            };

            Vector vector1 = new(3, 1), vector2 = new(3, 1);
            vector1.CurrentMatrix = arrayForTests1;

            vector2 = 2 * vector1;
            Assert.IsInstanceOfType(vector2, typeof(Vector));

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(vector2.CurrentMatrix[i, 0], arrayForCorrectAnswer[i, 0]);
            }
        }

        [TestMethod]
        public void MatrixNumberDivision()
        {
            float[,] arrayForCorrectAnswer = {
                { 0.5f },
                { 1 },
                { 1.5f }
            };

            Vector vector1 = new(3, 1), vector2 = new(3, 1);
            vector1.CurrentMatrix = arrayForTests1;

            vector2 = vector1 / 2;
            Assert.IsInstanceOfType(vector2, typeof(Vector));

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(vector2.CurrentMatrix[i, 0], arrayForCorrectAnswer[i, 0]);
            }
        }

        [TestMethod]
        public void BilinearFormTest()
        {
            float[,] uniqueArrayForTest = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            Matrix matrix = new(3, 3);
            matrix.CurrentMatrix = uniqueArrayForTest;

            Vector vector1 = new(3, 1), vector2 = new(3, 1);
            vector1.CurrentMatrix = arrayForTests1;
            vector2.CurrentMatrix = arrayForTests2;

            Assert.AreEqual(Program.BilinearForm(matrix, vector1, vector2), 204);
        }

        [TestMethod]
        public void VectorLength()
        {
            Vector vector = new(3, 1);
            vector.CurrentMatrix = arrayForTests1;
            Assert.AreEqual(vector.Length(), 14);
        }
    }

    [TestClass]
    public class VectorSpaceTests
    {
        float[,] basis1array = {
            { 1 },
            { 2 },
            { 10 }
        };

        float[,] basis2array = {
            { -5 },
            { 1 },
            { 6 }
        };

        float[,] basis3array = {
            { 3 },
            { 9 },
            { 1 }
        };

        float[,] arrayForTests1 =  {
            { 1 },
            { 2 },
            { 3 }
        };

        float[,] arrayForTests2 =  {
            { 3 },
            { 2 },
            { 1 }
        };

        Vector basis1 = new(3, 1), basis2 = new(3, 1), basis3 = new(3, 1);

        [TestMethod]
        public void GramMatrixTest()
        {
            float[,] arrayForCorrectAnswer = {
                { 105, 57, 31 },
                { 57, 62, 0 },
                { 31, 0, 91 }
            };

            basis1.CurrentMatrix = basis1array;
            basis2.CurrentMatrix = basis2array;
            basis3.CurrentMatrix = basis3array;
            VectorSpace vectorSpace = new(3, basis1, basis2, basis3);
            Matrix gramMatrix = new(3, 3);
            gramMatrix = Matrix.GramMatrix(vectorSpace.Basis);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(gramMatrix.CurrentMatrix[i, j], arrayForCorrectAnswer[i, j]);
                }
            }
        }

        [TestMethod]
        public void VectorScalarProductThroughGram()
        {
            float[,] arrayForCorrectAnswer = {
                { 105, 57, 31 },
                { 57, 62, 0 },
                { 31, 0, 91 }
            };

            Vector vector1 = new(3, 1), vector2 = new(3, 1);
            vector1.CurrentMatrix = arrayForTests2;
            vector2.CurrentMatrix = arrayForTests2;

            basis1.CurrentMatrix = basis1array;
            basis2.CurrentMatrix = basis2array;
            basis3.CurrentMatrix = basis3array;
            VectorSpace vectorSpace = new(3, basis1, basis2, basis3);

            Assert.AreEqual(vectorSpace.ScalarProduct(vector1, vector2), 2154);
        }

        [TestMethod]
        public void PointToVectorTest()
        {
            float[,] arrayForCorrectAnswer = {
                { 0 },
                { 31 },
                { 25 },
            };

            Point point = new(3, 1);
            point.CurrentMatrix = arrayForTests1;
            Vector vector = new(3, 1);

            basis1.CurrentMatrix = basis1array;
            basis2.CurrentMatrix = basis2array;
            basis3.CurrentMatrix = basis3array;
            VectorSpace vectorSpace = new(3, basis1, basis2, basis3);

            vector = vectorSpace.PointToVector(point);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(vector.CurrentMatrix[i, 0], arrayForCorrectAnswer[i, 0]);
            }
        }

    }
    /*
        [TestClass]
        public class PointTests { }*/

    [TestClass]
    public class IdentifierTests
    {
        [TestMethod]
        public void IdentifierGenerationTest()
        {
            Identifier identifier = new();

            for (int i = 1; i < 100; i++)
            {
                identifier.Generate();
                Console.WriteLine(identifier.Identifiers[i]);
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IdentifierGetValueTest() 
        {
            Identifier identifier = new();
            Console.Write(identifier.GetValue() + "; Current value number: ");
            Console.WriteLine(identifier.ValueNumber);
            identifier.Generate();
            Console.Write(identifier.GetValue() + "; Current value number: ");
            Console.WriteLine(identifier.ValueNumber);

            Assert.IsTrue(true);
        }
    }

    [TestClass]
    public class EntitiesTests
    {
        float[,] basis1array = {
            { 1 },
            { 2 },
            { 10 }
        };

        float[,] basis2array = {
            { -5 },
            { 1 },
            { 6 }
        };

        float[,] basis3array = {
            { 3 },
            { 9 },
            { 1 }
        };

        Vector basis1 = new(3, 1), basis2 = new(3, 1), basis3 = new(3, 1);

        [TestMethod]
        public void SetAndGetPropertyTest() 
        {
            float[,] array =
            {
                { 1 },
                { 2 },
                { 3 },
            };

            basis1.CurrentMatrix = basis1array;
            basis2.CurrentMatrix = basis2array;
            basis3.CurrentMatrix = basis3array;
            VectorSpace vectorSpace = new(3, basis1, basis2, basis3);
            Point pt = new(3, 1);
            pt.CurrentMatrix = array;
            CoordinateSystem cs = new(pt, vectorSpace);

            Entity entity = new(cs);

            entity.SetProperty("bebra", true);

            Assert.IsTrue(entity.GetProperty("bebra"));
        }

        
    }

    [TestClass]
    public class RayTests
    {
        float[,] basis1array = {
            { 1 },
            { 0 },
            { 0 }
        };

        float[,] basis2array = {
            { 0 },
            { 1 },
            { 0 }
        };

        float[,] basis3array = {
            { 0 },
            { 0 },
            { 1 }
        };

        float[,] pointArray =
        {
            { 0 }, 
            { 0 }, 
            { 0 }
        };

        float[,] vectorForTestArray = {
            { 4 },
            { 3 },
            { 0 }
        };

        Vector basis1 = new(3, 1), basis2 = new(3, 1), basis3 = new(3, 1), vectorForTest = new(3, 1);
        Point initialPt = new(3, 1);

        [TestMethod]
        public void NormalizeTest()
        {
            float[,] arrayForTest =
            {
                { 4f / 5f },
                { 3f / 5f },
                { 0f },
            };

            basis1.CurrentMatrix = basis1array;
            basis2.CurrentMatrix = basis2array;
            basis3.CurrentMatrix = basis3array;
            vectorForTest.CurrentMatrix = vectorForTestArray;
            initialPt.CurrentMatrix = pointArray;

            VectorSpace vectorSpace = new(3, basis1, basis2, basis3);
            CoordinateSystem coordinateSystem = new(initialPt, vectorSpace);

            Ray ray = new(coordinateSystem, initialPt, vectorForTest); // basis1 as direction vector

            ray.Normalize();

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(ray.Direction.CurrentMatrix[i, 0], arrayForTest[i, 0]);
            }
        }
    }
}