using System;
using System.Collections.Generic;

public class DuplicateCounter
{
    public static void Run()
    {
        // Example list of numbers with some duplicates
        int[] data = { 1, 2, 3, 4, 2, 3, 5, 6, 2, 7 };

        Console.WriteLine($"Total items: {data.Length}");
        Console.WriteLine($"Number of duplicates: {CountDuplicates(data)}");
    }

    // Count how many duplicate numbers exist in the array
    private static int CountDuplicates(int[] data)
    {
        var uniqueValues = new HashSet<int>(); // store unique numbers
        int duplicates = 0;

        foreach (int number in data)
        {
            if (uniqueValues.Contains(number))
            {
                duplicates++; // found a duplicate
            }
            else
            {
                uniqueValues.Add(number); // first time we see this number
            }
        }

        return duplicates;
    }
}
