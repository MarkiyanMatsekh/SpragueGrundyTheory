using System;

namespace GameTheory.UI
{
    public class SimpleExpression : ExpressionBase, IEquatable<SimpleExpression>
    {
        public int Evaluate(int n)
        {
            int arg1 = HasVariable ? n : 0;
            return Evaluate(arg1, Operation, Argument);
        }

        public bool Equals(SimpleExpression other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as SimpleExpression);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}