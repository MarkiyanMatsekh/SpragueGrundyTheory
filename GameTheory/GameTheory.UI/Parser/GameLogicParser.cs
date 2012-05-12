using System;
using System.Collections.Generic;
using System.Linq;
using GameTheory.UI.Parser.Expressions;

namespace GameTheory.UI.Parser
{
    public static class GameLogicParser
    {
        public const char TransitionsSeparator = ';';
        public const char PartsSeparator = ',';

        public const char IteratorSymbol = 'i';
        public const char IteratorStartSymbol = '=';
        public const string IteratorRangeSymbol = "..";

        public const char VariableSymbol = 'n';

        public static List<EvaluatableExpression> ParseMultipleTransitions(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");

            var transitions = text.Split(TransitionsSeparator);

            var transitionsList = new List<EvaluatableExpression>();

            foreach (var transtitionStr in transitions)
            {
                var transition = ParseSingleTransition(transtitionStr);
                if (transition != null)
                    transitionsList.Add(transition);
            }

            return transitionsList;
        }

        public static EvaluatableExpression ParseSingleTransition(string transtition)
        {
            if (string.IsNullOrEmpty(transtition))
                return null;

            EvaluatableExpression exp;

            var trimmed = transtition.Replace(" ", string.Empty); // remove spaces

            if (trimmed.Contains(IteratorSymbol))
                exp = ParseFullIteratorExpression(trimmed);
            else
                exp = ParseSimpleExpression(trimmed);

            return exp;

        }

        public static FullIteratorExpression ParseFullIteratorExpression(string strExpression)
        {
            FullIteratorExpression expression;

            if (string.IsNullOrEmpty(strExpression))
                throw new ArgumentException("Expression cannot be null");

            var parts = strExpression.Split(PartsSeparator);
            if (parts.Length != 2)
                throw new ArgumentException("Iterations must have 2 parts");

            var body = ParseIteratorBodyExpression(parts[0]);
            var range = ParseIteratorRangeExpression(parts[1]);

            return new FullIteratorExpression(body, range);
        }

        public static IteratorRangeExpression ParseIteratorRangeExpression(string expression)
        {
            if (!expression.StartsWith(string.Format("{0}{1}", IteratorSymbol, IteratorStartSymbol)))
                throw new ArgumentException("Range part must start with iterator declaration");

            var range = expression.SubstringAfter(IteratorStartSymbol);
            var rangeParts = range.Split(IteratorRangeSymbol);
            if (rangeParts.Length != 2)
                throw new ArgumentException("iterator range must have exactly 2 parts");

            var left = rangeParts[0];
            var right = rangeParts[1];

            var iterateFrom = ParseSimpleExpression(left);
            var iterateTo = ParseSimpleExpression(right);

            return new IteratorRangeExpression(iterateFrom, iterateTo);
        }

        public static IteratorBodyExpression ParseIteratorBodyExpression(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentException("expression cannot be null");

            bool hasVariable;
            Operation opOnIterator;

            if (expression.Contains(VariableSymbol))
            {
                hasVariable = true;

                expression = expression.SubstringAfter(VariableSymbol);

                var operation = OperationHelper.ParseOperation(expression[0]);
                opOnIterator = operation;

                expression = expression.Substring(operation.Show().Length);
            }
            else
            {
                hasVariable = false;
                opOnIterator = Operation.None;
            }

            var subeExpression = ParseSimpleExpression(expression, IteratorSymbol);

            return subeExpression.HasArgument
                ? new IteratorBodyExpression(hasVariable, opOnIterator, subeExpression.Operation, subeExpression.Argument)
                : new IteratorBodyExpression(hasVariable, opOnIterator);
        }

        public static SimpleExpression ParseSimpleExpression(string expression, char variableSymbol = VariableSymbol)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentException("expression cannot be null");


            bool hasVariable = false, hasArgument = true;
            Operation op = Operation.None;

            if (expression.Contains(variableSymbol))
            {
                hasVariable = true;

                expression = expression.SubstringAfter(variableSymbol);

                if (expression.IsEmpty())
                {
                    hasArgument = false;
                }
                else
                {
                    var operation = OperationHelper.ParseOperation(expression[0]);
                    op = operation;

                    expression = expression.Substring(op.Show().Length); // assuming operatoin takes 1 char
                }
            }

            if (!hasArgument)
                return SimpleExpression.VariableOnly();

            int arg;
            if (!int.TryParse(expression, out arg))
                throw new ArgumentException("couldn't parse value: " + expression);

            return hasVariable ? new SimpleExpression(op, arg) : new SimpleExpression(arg);

        }
    }
}
