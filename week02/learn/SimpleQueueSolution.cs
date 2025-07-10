// SimpleQueueSolution.cs
using System;
using System.Collections.Generic;

public class SimpleQueueSolution
{
    private List<int> items = new List<int>();

    // Enqueue: correct—add to the back
    public void Enqueue(int value)
    {
        items.Add(value);
    }

    // Dequeue: correct—remove from the front
    public int Dequeue()
    {
        if (items.Count == 0)
            throw new IndexOutOfRangeException("Cannot dequeue from empty queue");

        int value = items[0];
        items.RemoveAt(0);
        return value;
    }

    public static void Run()
    {
        var q = new SimpleQueueSolution();

        Console.WriteLine("Enqueue 100, 200, 300");
        q.Enqueue(100);
        q.Enqueue(200);
        q.Enqueue(300);

        Console.WriteLine("Dequeue: should be 100 → “{0}”", q.Dequeue());
        Console.WriteLine("Dequeue: should be 200 → “{0}”", q.Dequeue());
        Console.WriteLine("Dequeue: should be 300 → “{0}”", q.Dequeue());

        // Dequeue on empty throws, as required
        try
        {
            Console.WriteLine("Dequeue on empty: should throw →");
            q.Dequeue();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Caught: " + ex.GetType().Name + " – " + ex.Message);
        }
    }
}
