using System;
using System.Collections.Generic;

namespace GameTheory.UI.Parser.Expressions
{
    public abstract class ExpressionsBase { }

    public abstract class EvaluatableExpression : ExpressionsBase
    {
        public abstract List<int> Evaluate(int x);

        public static int EvaluateSimpleOperation(int arg1, Operation op, int arg2)
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
    }
}