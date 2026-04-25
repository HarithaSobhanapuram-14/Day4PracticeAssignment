using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Queue<string> taskQueue = new Queue<string>();
        Stack<string> undoStack = new Stack<string>();
        List<string> allTasks = new List<string>();
        SortedDictionary<int, string> priorityTasks = new SortedDictionary<int, string>();
        HashSet<string> uniqueTasks = new HashSet<string>();

        AddTask("Backup Files", 2);
        AddTask("System Update", 1);
        AddTask("Virus Scan", 3);
        AddTask("Backup Files", 4);

        Console.WriteLine("=== All Tasks ===");
        foreach (string task in allTasks)
        {
            Console.WriteLine(task);
        }

        Console.WriteLine("\n=== Priority Based Tasks ===");
        foreach (var task in priorityTasks)
        {
            Console.WriteLine($"Priority {task.Key}: {task.Value}");
        }

        Console.WriteLine("\n=== Executing Tasks ===");
        while (taskQueue.Count > 0)
        {
            string task = taskQueue.Dequeue();
            Console.WriteLine($"Executed: {task}");
            undoStack.Push(task);
        }

        Console.WriteLine("\n=== Undo Last Operation ===");
        if (undoStack.Count > 0)
        {
            string lastTask = undoStack.Pop();
            Console.WriteLine($"Undo: {lastTask}");
        }

        void AddTask(string task, int priority)
        {
            if (uniqueTasks.Add(task))
            {
                allTasks.Add(task);
                taskQueue.Enqueue(task);
                priorityTasks.Add(priority, task);
            }
            else
            {
                Console.WriteLine($"Duplicate Task Ignored: {task}");
            }
        }
    }
}
