public class TaskManager
{
    private readonly List<TaskItem> _tasks = new();

    public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

    public TaskItem AddTask(string title)
    {
        var task = new TaskItem(title);
        _tasks.Add(task);
        return task;
    }

    public TaskItem GetById(Guid id)
    {
        return _tasks.First(t => t.Id == id); // lança exceção se não existir
    }

    public bool CompleteTask(Guid id)
    {
        var task = GetById(id);
        task.Complete();
        return true;
    }
}