using System;
using System.Collections.Generic;

namespace GameTheory.UI.Parser.Expressions
{
    public class SimpleExpression : EvaluatableExpression, IEquatable<SimpleExpression>
    {
        public bool HasVariable { get; private set; }
        public bool HasArgument { get; private set; }
        public Operation Operation { get; private set; }
        public int Argument { get; private set; }

        private SimpleExpression(bool hasVariable, bool hasArgument, Operation operation, int argument)
        {
            HasVariable = hasVariable;
            HasArgument = hasArgument;
            Operation = operation;
            Argument = argument;
        }

        public SimpleExpression(int argument)
            : this(false, true, Operation.None, argument)
        {
        }

        public SimpleExpression(Operation operation, int argument)
            : this(true, true, operation, argument)
        {
        }

        public static SimpleExpression VariableOnly()
        {
            return new SimpleExpression(true, false, Operation.None, 0);
        }

        public static SimpleExpression Empty()
        {
            return new SimpleExpression(false, false, Operation.None, 0);
        }


        public override List<int> Evaluate(int n)
        {
            int arg1 = HasVariable ? n : 0;
            return new List<int> { EvaluateSimpleOperation(arg1, Operation, Argument) };
        }

        #region Overrides

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", HasVariable ? "x" : string.Empty,
                Operation.Show(),
                Argument);
        }

        public bool Equals(SimpleExpression other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return other.HasVariable.Equals(HasVariable) && other.HasArgument.Equals(HasArgument) &&
                   (!HasArgument ||
                   Equals(other.Operation, Operation) && other.Argument == Argument);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(SimpleExpression)) return false;
            return Equals((SimpleExpression)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = HasVariable.GetHashCode();
                result = (result * 397) ^ HasArgument.GetHashCode();
                result = (result * 397) ^ Operation.GetHashCode();
                result = (result * 397) ^ Argument;
                return result;
            }
        }

        #endregion
    }
}