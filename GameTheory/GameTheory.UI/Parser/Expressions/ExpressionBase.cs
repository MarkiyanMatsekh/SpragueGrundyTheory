using System;

namespace GameTheory.UI.Parser.Expressions
{
    public abstract class ExpressionBase : IEquatable<ExpressionBase>
    {
        public bool HasVariable;
        public bool HasArgument = true;
        public Operation Operation;
        public int Argument;

        public static int Evaluate(int arg1, Operation op, int arg2)
        {
            switch (op)
            {
                case Operation.Minus:
                    return arg1 - arg2;
                    break;
                case Operation.Plus:
                    return arg1 + arg2;
                    break;
                default:
                    throw new InvalidOperationException("currently only minus and plus operations are supported");
            }
        }

        public bool Equals(ExpressionBase other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.HasVariable.Equals(HasVariable) && Equals(other.Operation, Operation) && other.Argument == Argument;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is ExpressionBase)) return false;
            return Equals((ExpressionBase) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = HasVariable.GetHashCode();
                result = (result*397) ^ Operation.GetHashCode();
                result = (result*397) ^ Argument;
                return result;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", HasVariable ? "x" : string.Empty,
                Operation.Show(),
                Argument);
        }
    }




}