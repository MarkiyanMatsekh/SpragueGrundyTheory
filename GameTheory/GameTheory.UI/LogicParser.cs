using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameTheory.UI
{
    public static class LogicParser
    {
        public const char TransitionsSeparator = ';';
        public const char PartsSeparator = ',';

        public const char IteratorStartSymbol = '=';
        public const char IteratorRangeSymbol = '-';
        public const char IteratorSymbol = 'i';

        public const char VariableSymbol = 'n';

        public const char MinusSymbol = '-';


        public static List<ExpressionBase> Parse(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            var transitions = text.Split(TransitionsSeparator);

            var transitionsList = new List<ExpressionBase>();

            foreach (var transtitionStr in transitions)
            {
                var transition = ParseTransition(transtitionStr);
                if (transition != null)
                    transitionsList.Add(transition);
            }

            return transitionsList;
        }

        private static ExpressionBase ParseTransition(string transtition)
        {
            if (string.IsNullOrEmpty(transtition))
                return null;

            ExpressionBase exp;

            var trimmed = transtition.Replace(" ", string.Empty); // remove spaces

            if (trimmed.Contains(IteratorSymbol))
            {
                var parts = trimmed.Split(PartsSeparator);
                if (parts.Length != 2)
                    throw new ArgumentException("Iterations must have 2 parts");

                exp = ParseExpressionWithIterator(parts[0]);

                var iterator = parts[1];
                var iteratorRange = iterator.SubstringAfter(IteratorStartSymbol);
                var iteratorParts = iteratorRange.Split(IteratorRangeSymbol);
                if (iteratorParts.Length != 2)
                    throw new ArgumentException("iterator range msut have 2 parts");

                var iteratorLeft = iteratorParts[0];
                var iteratorRight = iteratorParts[1];

                var iteratorFrom = ParseSimpleExpression(iteratorLeft);
                var iteratorTo = ParseSimpleExpression(iteratorRight);

            }
            else
            {
                exp = ParseSimpleExpression(trimmed);
            }

            return exp;

        }

        private static ExpressionWithIterator ParseExpressionWithIterator(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentException("expression cannot be null");

            //if (expression.Contains(IteratorSymbol))
            //    throw new ArgumentException("expression containing iterator should parse in other way");

            var exp = new ExpressionWithIterator();
            if (expression.Contains(VariableSymbol))
            {
                exp.HasVariable = true;

                expression = expression.SubstringAfter(VariableSymbol);

                var operation = ParseOperation(expression[0]);
                exp.OperationOnIterator = operation;

                expression = expression.Substring(1); // assuming operatoin takes 1 char
            }

            var exp2 = ParseSimpleExpression(expression, IteratorSymbol);

            exp.Operation = exp2.Operation;
            exp.Argument = exp2.Argument;

            return exp;
        }

        private static SimpleExpression ParseSimpleExpression(string expression, char variableSymbol = VariableSymbol)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentException("expression cannot be null");

            //if (expression.Contains(IteratorSymbol))
            //    throw new ArgumentException("expression containing iterator should parse in other way");

            var exp = new SimpleExpression();
            if (expression.Contains(variableSymbol))
            {
                exp.HasVariable = true;

                expression = expression.SubstringAfter(VariableSymbol);

                var operation = ParseOperation(expression[0]);
                exp.Operation = operation;

                expression = expression.Substring(1); // assuming operatoin takes 1 char
            }

            int value;
            if (!int.TryParse(expression, out value))
                throw new ArgumentException("couldn't parse value: " + expression);

            exp.Argument = value;

            return exp;
        }

        private static Operation ParseOperation(char op)
        {
            switch (op)
            {
                case '+':
                    return Operation.Plus;
                    break;
                case '-':
                    return Operation.Minus;
                    break;
                default:
                    throw new InvalidOperationException("not supported operation");
            }
        }
    }

    public abstract class ExpressionBase
    {
        public bool HasVariable;
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
    }

    public class ExpressionWithIterator : ExpressionBase
    {
        public Operation OperationOnIterator;

        public List<int> Evaluate(int n, SimpleExpression iteratorFrom, SimpleExpression iteratorTo)
        {
            var result = new List<int>();
            int arg1 = HasVariable ? n : 0;

            for (int i = iteratorFrom.Evaluate(n); i < iteratorTo.Evaluate(n); i++)
            {
                result.Add(Evaluate(arg1, OperationOnIterator, Evaluate(i, Operation, Argument)));
            }

            return result;
        }
    }

    public class SimpleExpression : ExpressionBase
    {
        public int Evaluate(int n)
        {
            int arg1 = HasVariable ? n : 0;
            return Evaluate(arg1, Operation, Argument);
        }

    }

    public enum Operation { Plus, Minus }

    public static class StringExtensions
    {
        public static string SubstringAfter(this string str, char symbol)
        {
            return str.Substring(str.IndexOf(symbol) + 1);
        }
    }
}
