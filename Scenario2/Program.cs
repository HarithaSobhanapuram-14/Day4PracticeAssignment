using System;
using System.Collections.Generic;

class Transaction
{
    public string Type { get; set; }
    public double Amount { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Transaction> transactions = new List<Transaction>();
        Stack<Transaction> undoStack = new Stack<Transaction>();

        double balance = 0;

        // Deposit
        Transaction t1 = new Transaction { Type = "Deposit", Amount = 1000 };
        balance += t1.Amount;
        transactions.Add(t1);
        undoStack.Push(t1);

        // Withdraw
        Transaction t2 = new Transaction { Type = "Withdraw", Amount = 300 };
        balance -= t2.Amount;
        transactions.Add(t2);
        undoStack.Push(t2);

        Console.WriteLine($"Current Balance: {balance}");

        // Undo last transaction
        Console.WriteLine("\nUndo Last Transaction...");

        if (undoStack.Count > 0)
        {
            Transaction last = undoStack.Pop();

            if (last.Type == "Deposit")
                balance -= last.Amount;
            else
                balance += last.Amount;

            Console.WriteLine($"Reverted {last.Type} of {last.Amount}");
        }

        Console.WriteLine($"Balance After Undo: {balance}");

        Console.WriteLine("\nAll Transactions:");
        foreach (var t in transactions)
        {
            Console.WriteLine($"{t.Type} - {t.Amount}");
        }
    }
}
