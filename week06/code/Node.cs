using System;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // PROBLEM 1: Insert unique values only (ignore duplicates)
    public void Insert(int value)
    {
        // If value equals this node's data, do nothing (no duplicates).
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Go left for smaller values.
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            // Go right for larger values.
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // PROBLEM 2: Recursively search for value
    public bool Contains(int value)
    {
        // If this node matches, found it.
        if (value == Data) return true;

        if (value < Data)
        {
            // Look left (if it exists).
            return Left != null && Left.Contains(value);
        }
        else
        {
            // Look right (if it exists).
            return Right != null && Right.Contains(value);
        }
    }

    // PROBLEM 4: Height = 1 + max(height(left), height(right))
    public int GetHeight()
    {
        // A leaf node has height 1.
        // If a child is null, its height is 0.
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
