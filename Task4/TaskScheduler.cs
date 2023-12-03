namespace Task4;

public class TaskScheduler<TTask, TPriority> where TPriority : IComparable<TPriority>
{
    private readonly SortedDictionary<TPriority, Queue<TTask>> _tasksByPriority = new();

    public void AddTask(TTask task, TPriority priority)
    {
        if (!_tasksByPriority.TryGetValue(priority, out var queue))
            _tasksByPriority[priority] = queue = new Queue<TTask>();

        queue.Enqueue(task);
    }

    public void ExecuteNext(TaskExecution<TTask> executionDelegate)
    {
        TryExecuteNext(executionDelegate);
    }

    public bool TryExecuteNext(TaskExecution<TTask> executionDelegate)
    {
        if (_tasksByPriority.Count <= 0)
            return false;

        var highestPriority = _tasksByPriority.Keys.Last();
        var queue = _tasksByPriority[highestPriority];
        var nextTask = queue.Dequeue();
        if (queue.Count == 0) _tasksByPriority.Remove(highestPriority);
        executionDelegate(nextTask);
        return true;
    }
}