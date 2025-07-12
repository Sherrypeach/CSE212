public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Adds a value with priority to the back of the queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    /// <summary>
    /// Removes and returns the value with the highest priority.
    /// If multiple items have the same highest priority, the one closest to the front is returned.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int highPriorityIndex = 0;

        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = i;
            }
        }

        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
