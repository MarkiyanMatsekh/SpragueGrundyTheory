using System;

namespace GameTheory.UI.Parser.Expressions
{
    public class IteratorExpression : ExpressionsBase, IEquatable<IteratorExpression>
    {
        public bool HasVariable { get; private set; }
        public bool HasArgument { get; private set; }
        public Operation OperationOnIterator { get; private set; }
        public Operation OperationOnArgument { get; private set; }
        public int Argument { get; private set; }


        private IteratorExpression(bool hasVariable, Operation operationOnIterator, bool hasArgument, Operation operationOnArgument, int argument)
        {
            HasVariable = hasVariable;
            HasArgument = hasArgument;
            OperationOnIterator = operationOnIterator;
            OperationOnArgument = operationOnArgument;
            Argument = argument;
        }

        public IteratorExpression(bool hasVariable, Operation operationOnIterator, Operation operationOnArgument, int argument)
            : this(hasVariable, operationOnIterator, true, operationOnArgument, argument)
        {
        }

        public IteratorExpression(bool hasVariable, Operation operationOnIterator)
            : this(hasVariable, operationOnIterator, false, Operation.None, 0)
        {
        }

        #region Overrides

        public override string ToString()
        {
            return string.Format("{0}{1}i{2}{3}",
                                 HasVariable ? "x" : string.Empty,
                                 OperationOnIterator.Show(),
                                 OperationOnArgument.Show(),
                                 HasArgument ? Argument.ToString() : string.Empty);
        }

        public bool Equals(IteratorExpression other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.HasVariable.Equals(HasVariable) && 
                other.HasArgument.Equals(HasArgument) && 
                Equals(other.OperationOnIterator, OperationOnIterator) && 
                (!HasArgument ||  // if there's no argument equalityt is determined without the rest of params
                Equals(other.OperationOnArgument, OperationOnArgument) && 
                 other.Argument == Argument);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (IteratorExpression)) return false;
            return Equals((IteratorExpression) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = HasVariable.GetHashCode();
                result = (result*397) ^ HasArgument.GetHashCode();
                result = (result*397) ^ OperationOnIterator.GetHashCode();
                result = (result*397) ^ OperationOnArgument.GetHashCode();
                result = (result*397) ^ Argument;
                return result;
            }
        }

        #endregion

    }
}