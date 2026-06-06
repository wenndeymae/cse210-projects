using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time you stood up for someone else.",
        "Think of a time you did something really difficult.",
        "Think of a time you helped someone in need.",
        "Think of a time you did something selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful?",
        "How did you feel during this experience?",
        "What did you learn about yourself?",
        "What would you do differently next time?",
        "How can this help you in the future?"
    };

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity helps you reflect on moments of strength and resilience.")
    {
    }

    protected override void Run(int duration)
    {
        Random rand = new Random();

        string prompt = _prompts[rand.Next(_prompts.Count)];
        Console.WriteLine($"\n{prompt}");
        Console.WriteLine("Think deeply about this...");
        ShowSpinner(5);

        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine($"\n{question}");
            ShowSpinner(5);
        }
    }
}