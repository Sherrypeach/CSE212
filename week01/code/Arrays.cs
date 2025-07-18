using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// 
    /// Plan:
    /// - Create an array of size 'length'.
    /// - Loop from 0 to length - 1.
    /// - For each position i, store the value (number * (i + 1)) in the result.
    /// - Return the result array.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and the amount is 3, 
    /// the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    ///
    /// Because a list is dynamic, this function will modify the existing data list 
    /// rather than returning a new list.
    ///
    /// Plan:
    /// - Extract the last 'amount' elements from the list using GetRange.
    /// - Remove those elements from the end of the list using RemoveRange.
    /// - Insert the extracted elements at the beginning using InsertRange.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        List<int> endSlice = data.GetRange(data.Count - amount, amount);
        data.RemoveRange(data.Count - amount, amount);
        data.InsertRange(0, endSlice);
    }
}
