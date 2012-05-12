using System;
using GameTheory.UI;

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
                throw new InvalidOperationException("not supported operation");
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
                throw new InvalidOperationException("not supported operation");
        }
    }
}