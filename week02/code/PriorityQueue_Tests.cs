using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 items with different priorities and dequeue them in order.
    // Expected Result: Items with highest priority should come out first: "C", "B", then "A".
    // Defect(s) Found: None.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add 3 items with the same priority to test FIFO behavior among equals.
    // Expected Result: Items dequeued in the same order they were enqueued: "X", "Y", "Z".
    // Defect(s) Found: None.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("X", 5);
        priorityQueue.Enqueue("Y", 5);
        priorityQueue.Enqueue("Z", 5);

        Assert.AreEqual("X", priorityQueue.Dequeue());
        Assert.AreEqual("Y", priorityQueue.Dequeue());
        Assert.AreEqual("Z", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException with correct message.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var queue = new PriorityQueue();

        try
        {
            queue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        catch (Exception ex)
        {
            Assert.Fail($"Unexpected exception type: {ex.GetType()}");
        }
    }

    [TestMethod]
    // Scenario: Mixed priorities and some same-priority items. Validate both priority and FIFO.
    // Expected Result: Highest priority comes first, then FIFO respected among equals.
    // Defect(s) Found: None.
    public void TestPriorityQueue_MixedCases()
    {
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 3);
        queue.Enqueue("C", 3);
        queue.Enqueue("D", 2);

        Assert.AreEqual("B", queue.Dequeue()); // 3 - first in
        Assert.AreEqual("C", queue.Dequeue()); // 3 - second in
        Assert.AreEqual("D", queue.Dequeue()); // 2
        Assert.AreEqual("A", queue.Dequeue()); // 1
    }
}
