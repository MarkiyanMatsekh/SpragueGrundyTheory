using System;

namespace GameTheory.UI.Parser
{
    static internal class OperationHelper
    {
        public static Operation ParseOperation(char op)
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
                    throw new InvalidOperationException(string.Format("Cannot parse '{0}'. Not supported operation", op));
            }
        }

        public static string Show(this Operation op)
        {
            switch (op)
            {
                case Operation.Plus:
                    return "+";
                    break;
                case Operation.Minus:
                    return "-";
                    break;
                case Operation.None:
                    return string.Empty;
                    break;
                default:
                    throw new InvalidOperationException(string.Format("Can't show '{0}'. Not supported operation", op));
            }
        }
    }
}