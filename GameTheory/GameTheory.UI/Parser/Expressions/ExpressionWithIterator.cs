using System;

namespace GameTheory.UI.Parser.Expressions
{
    public class ExpressionWithIterator : ExpressionBase, IEquatable<ExpressionWithIterator>
    {
        public Operation OperationOnIterator;
        
        #region Equality Operators

        public bool Equals(ExpressionWithIterator other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(other.OperationOnIterator, OperationOnIterator);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as ExpressionWithIterator);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (base.GetHashCode()*397) ^ OperationOnIterator.GetHashCode();
            }
        }

        #endregion
    }
}