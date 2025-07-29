public static class Recursion
{
    // Problem 1: Recursively sum squares up to n
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0; // base case
        return n * n + SumSquaresRecursive(n - 1); // recursive step
    }

    // Problem 2: Generate all permutations of given size from letters
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word); // base case: word is ready
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            // Skip letters already in the word
            if (!word.Contains(letters[i]))
            {
                // Add letter and go deeper
                PermutationsChoose(results, letters, size, word + letters[i]);
            }
        }
    }

    // Problem 3: Count ways to climb stairs using memoization
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        if (remember.ContainsKey(s))
            return remember[s]; // return cached result

        // recursive calls + store result
        decimal result = CountWaysToClimb(s - 1, remember)
                       + CountWaysToClimb(s - 2, remember)
                       + CountWaysToClimb(s - 3, remember);
        remember[s] = result;
        return result;
    }

    // Problem 4: Wildcard binary generator
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        if (index == -1)
        {
            results.Add(pattern); // no more wildcards
            return;
        }

        // Replace * with 0
        WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);
        // Replace * with 1
        WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
    }

    // Problem 5: Recursive maze path solver
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // Invalid move? Stop recursion here
        if (!maze.IsValidMove(currPath, x, y))
            return;

        // Add current position to the path
        currPath.Add((x, y));

        // If reached end of maze, add the path to results
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1); // backtrack
            return;
        }

        // Explore 4 directions
        SolveMaze(results, maze, x + 1, y, new List<(int, int)>(currPath)); // right
        SolveMaze(results, maze, x - 1, y, new List<(int, int)>(currPath)); // left
        SolveMaze(results, maze, x, y + 1, new List<(int, int)>(currPath)); // down
        SolveMaze(results, maze, x, y - 1, new List<(int, int)>(currPath)); // up

        // No need to manually backtrack since we use new list in each call
    }
}
