// SimpleQueue.cs
using System;
using System.Collections.Generic;

public class SimpleQueue
{
    private List<int> items = new List<int>();

    // Enqueue: add to back of the queue
    public void Enqueue(int value)
    {
        // BUG #1: This was accidentally inserting at index 0,
        // which makes the list act like a stack instead of a queue!
        // Fix later by changing Insert(0, value) → Add(value).
        items.Insert(0, value);
    }

    // Dequeue: remove from front of the queue
    public int Dequeue()
    {
        if (items.Count == 0)
            throw new IndexOutOfRangeException("Cannot dequeue from empty queue");

        // BUG #2: This was removing from the back of the list,
        // so items come out in reverse order.
        // Fix later by removing at the last index → remove at index 0.
        int value = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        return value;
    }

    public static void Run()
    {
        var q = new SimpleQueue();

        Console.WriteLine("Enqueue 100, 200, 300");
        q.Enqueue(100);
        q.Enqueue(200);
        q.Enqueue(300);

        Console.WriteLine("Dequeue: should be 100 → “{0}”", q.Dequeue());
        Console.WriteLine("Dequeue: should be 200 → “{0}”", q.Dequeue());
        Console.WriteLine("Dequeue: should be 300 → “{0}”", q.Dequeue());

        // If we try to dequeue again, it will throw:
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
