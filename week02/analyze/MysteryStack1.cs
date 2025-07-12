public static class MysteryStack1
{
    public static string Run(string text)
    {
        // We create our empty tower of letters
        var stack = new Stack<char>();

        // 1) We stack each letter (like building blocks)
        foreach (var letter in text)
            stack.Push(letter);  //  we push the letter onto the tower

        // 2) Now the tower has all the letters, the last block is on top!
        var result = "";

        // 3) We take each block (letter) from the top and add it to the result
        while (stack.Count > 0)
            result += stack.Pop();  //  we pop the top letter and add it

        return result;  // we return the text “flipped”
    }
}