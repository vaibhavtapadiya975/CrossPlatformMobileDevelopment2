namespace Calculator;

public static class Calculator
{
    public static double Calculate(double value1, double value2, string mathOperator)
    {
        double result = 0;

        switch (mathOperator)
        {
            case "÷":
                result = value1 / value2;
                break;
            case "×":
                result = value1 * value2;
                break;
            case "+":
                result = value1 + value2;
                break;
            case "-":
                result = value1 - value2;
                break;
            case "mod":
                result = value1 % value2;
                break;

        }

        return result;
    }
    public static double evaluate(string expression)
    {
        Stack<double> operand = new Stack<double>();
        Stack<Char> oper = new Stack<char>();
        Console.WriteLine(expression);
        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];
            //check if it is number
            if (Char.IsDigit(c))
            {
                //Entry is Digit, it could be greater than one digit number
                int num = 0;
                while (Char.IsDigit(c))
                {
                    num = num * 10 + (c - '0');
                    i++;
                    if (i < expression.Length)
                        c = expression[i];
                    else
                        break;
                }
                i--;
                operand.Push(num);
            }
            else if (c == '(')
            {
                //push it to operators stack
                oper.Push(c);
            }
            else if (c == ')')
            {
                while (oper.Peek() != '(')
                {
                    double a = operand.Pop();
                    double b = operand.Pop();
                    double output = Calculate(b, a, oper.Pop() + "");
                    //push it back to stack
                    operand.Push(output);
                }
                oper.Pop();
            }
            else if ("-×÷+".Contains(c))
            {
                //1. If current operator has higher precedence than operator on top of the stack,
                //the current operator can be placed in stack
                // 2. else keep popping operator from stack and perform the operation in  numbers stack till
                //either stack is not empty or current operator has higher precedence than operator on top of the stack
                while (!(oper.Count == 0) && precedence(c) <= precedence(oper.Peek()))
                {
                    double a = operand.Pop();
                    double b = operand.Pop();
                    double output = Calculate(b, a, oper.Pop() + "");
                    //push it back to stack
                    operand.Push(output);
                }
                //now push the current operator to stack
                oper.Push(c);
            }
        }
        while (oper.Count > 0)
        {
            double a = operand.Pop();
            double b = operand.Pop();
            double output = Calculate(b, a, oper.Pop() + "");
            //push it back to stack
            operand.Push(output);
        }
        return operand.Pop();
    }
    static int precedence(char c)
    {
        switch (c)
        {
            case '+':
            case '-':
                return 1;
            case '×':
            case '÷':
                return 2;
            case '^':
                return 3;
        }
        return -1;
    }
}

public static class DoubleExtensions
{
    public static string ToTrimmedString(this double target, string decimalFormat)
    {
        string strValue = target.ToString(decimalFormat); //Get the stock string

        //If there is a decimal point present
        if (strValue.Contains("."))
        {
            //Remove all trailing zeros
            strValue = strValue.TrimEnd('0');

            //If all we are left with is a decimal point
            if (strValue.EndsWith(".")) //then remove it
                strValue = strValue.TrimEnd('.');
        }

        return strValue;
    }
}
