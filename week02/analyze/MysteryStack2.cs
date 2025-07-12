public static class MysteryStack2
{
    // This function checks if a string can be converted to a number (float)
    private static bool IsFloat(string text)
    {
        return float.TryParse(text, out _);
    }

    public static float Run(string text)
    {
        // Create an empty stack to hold float numbers
        var stack = new Stack<float>();

        // Go through each item (number or operator) in the input string
        foreach (var item in text.Split(' '))
        {
            // If it's an operator (+, -, *, /), we need to perform a calculation
            if (item == "+" || item == "-" || item == "*" || item == "/")
            {
                // Check if there are at least two numbers in the stack
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!"); // Not enough numbers to operate

                // Take the two top numbers from the stack
                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;

                // Perform the correct operation
                if (item == "+")
                {
                    res = op1 + op2;
                }
                else if (item == "-")
                {
                    res = op1 - op2;
                }
                else if (item == "*")
                {
                    res = op1 * op2;
                }
                else // it's a division
                {
                    // Division by zero is not allowed
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                // Push the result back onto the stack
                stack.Push(res);
            }
            // If it's a number, push it onto the stack
            else if (IsFloat(item))
            {
                stack.Push(float.Parse(item));
            }
            // If it's an empty string (extra space), do nothing
            else if (item == "")
            {
            }
            // If it's anything else (unknown symbol), throw an error
            else
            {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        // At the end, there should be exactly one result in the stack
        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!"); // Too many or too few values left

        // Return the final result
        return stack.Pop();
    }
}
