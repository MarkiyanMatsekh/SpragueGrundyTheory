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

        public const char IteratorSymbol = 'i';
        public const char IteratorStartSymbol = '=';
        public const string IteratorRangeSymbol = "..";

        public const char VariableSymbol = 'n';

        public const char MinusSymbol = '-';

        public static List<ExpressionBase> ParseMultipleTransitions(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            var transitions = text.Split(TransitionsSeparator);

            var transitionsList = new List<ExpressionBase>();

            foreach (var transtitionStr in transitions)
            {
                var transition = ParseSingleTransition(transtitionStr);
                if (transition != null)
                    transitionsList.Add(transition);
            }

            return transitionsList;
        }

        public static ExpressionBase ParseSingleTransition(string transtition)
        {
            if (string.IsNullOrEmpty(transtition))
                return null;

            ExpressionBase exp;

            var trimmed = transtition.Replace(" ", string.Empty); // remove spaces

            if (trimmed.Contains(IteratorSymbol))
                exp = ParseFullExpressionWithIterator(trimmed);
            else
                exp = ParseSimpleExpression(trimmed);

            return exp;

        }

        public static FullExpressionWithIterator ParseFullExpressionWithIterator(string strExpression)
        {
            FullExpressionWithIterator expression;

            if (string.IsNullOrEmpty(strExpression))
                throw new ArgumentException("Expression cannot be null");

            var parts = strExpression.Split(PartsSeparator);
            if (parts.Length != 2)
                throw new ArgumentException("Iterations must have 2 parts");

            expression = new FullExpressionWithIterator(ParseExpressionWithIterator(parts[0]));

            var iterator = parts[1];
            var iteratorRange = iterator.SubstringAfter(IteratorStartSymbol);
            var iteratorParts = iteratorRange.Split(new string[] { IteratorRangeSymbol }, StringSplitOptions.RemoveEmptyEntries);
            if (iteratorParts.Length != 2)
                throw new ArgumentException("iterator range must have exactly 2 parts");

            var iteratorLeft = iteratorParts[0];
            var iteratorRight = iteratorParts[1];

            expression.IterateFrom = ParseSimpleExpression(iteratorLeft);
            expression.IterateTo = ParseSimpleExpression(iteratorRight);

            return expression;

        }

        public static ExpressionWithIterator ParseExpressionWithIterator(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentException("expression cannot be null");

            var exp = new ExpressionWithIterator();
            if (expression.Contains(VariableSymbol))
            {
                exp.HasVariable = true;

                expression = expression.SubstringAfter(VariableSymbol);

                var operation = OperationHelper.ParseOperation(expression[0]);
                exp.OperationOnIterator = operation;

                expression = expression.Substring(1); // assuming operation takes 1 char
            }
            else
            {
                exp.OperationOnIterator = Operation.None; // may be deleted
            }

            var exp2 = ParseSimpleExpression(expression, IteratorSymbol);

            exp.Operation = exp2.Operation;
            exp.Argument = exp2.Argument;

            return exp;
        }

        public static SimpleExpression ParseSimpleExpression(string expression, char variableSymbol = VariableSymbol)
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

                var operation = OperationHelper.ParseOperation(expression[0]);
                exp.Operation = operation;

                expression = expression.Substring(1); // assuming operatoin takes 1 char
            }

            int value;
            if (!int.TryParse(expression, out value))
                throw new ArgumentException("couldn't parse value: " + expression);

            exp.Argument = value;

            return exp;
        }
    }

    public enum Operation { None = 0, Plus, Minus }
}
