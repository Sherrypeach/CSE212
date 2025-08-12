using System;

public static class Trees
{
    /// <summary>
    /// Given a sorted list, create a balanced BST by inserting middles first.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // start with empty tree
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    // PROBLEM 5: Insert middle element first, then recurse on left half and right half.
    // We pass indices (first, last) so we DON'T create sublists.
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: no range left.
        if (first > last) return;

        // Middle index (integer division).
        int mid = (first + last) / 2;

        // Insert the middle value first. This keeps the tree balanced.
        bst.Insert(sortedNumbers[mid]);

        // Recurse on left half [first, mid-1] and right half [mid+1, last].
        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
