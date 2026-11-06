using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - Priority Queue tests.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add four items with different priorities, including two items
    // with equal highest priority.
    // Expected Result: Highest priority comes out first. Items with equal
    // priority come out in the order they were added.
    // Defect(s) Found: Original code ignored the last item when searching
    // for the highest priority and did not remove dequeued items.
    // Final Result: Passed.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High First", 5);
        priorityQueue.Enqueue("Medium", 3);
        priorityQueue.Enqueue("High Second", 5);

        Assert.AreEqual("High First", priorityQueue.Dequeue());
        Assert.AreEqual("High Second", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to remove an item from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the
    // message "The queue is empty."
    // Defect(s) Found: No defect found in the original empty-queue check.
    // Final Result: Passed.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    // Add more test cases as needed below.
}