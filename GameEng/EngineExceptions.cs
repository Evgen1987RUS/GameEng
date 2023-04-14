using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngNamespace
{
    public abstract class EngineExceptions
    {
        public abstract class InMatrixExceptions
        {
            public class WrongSize : Exception { public WrongSize() : base("Sizes do not match") { } }

            public class DivisionByZero : Exception { public DivisionByZero() : base("Division by zero") { } }

            public class OutOfDimensions : Exception { public OutOfDimensions() : base("Invalid index") { } }

            public class DeterminantEqualsZero : Exception { public DeterminantEqualsZero() : base("Determinant equals zero") { } }
        }

        public abstract class MutualExceptions
        {
            public class BadInput : Exception { public BadInput() : base("Bad input") { } }
        }
    }
}
