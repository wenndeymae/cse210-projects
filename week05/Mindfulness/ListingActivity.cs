using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "List people you appreciate.",
        "List your personal strengths.",
        "List people you helped recently.",
        "List your favorite heroes.",
        "List things you are grateful for."
    };

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity helps you recognize the good things in your life.")
    {
    }

    protected override void Run(int duration)
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine($"\n{prompt}");
        Console.WriteLine("Type your items one by one. Type 0 when you are done.\n");

        ShowCountdown(5);

        List<string> items = new List<string>();

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (input == "0")
            {
                break;
            }

            items.Add(input);
        }

        Console.WriteLine("\nYou listed:");

        int count = 1;
        foreach (string item in items)
        {
            Console.WriteLine($"{count}. {item}");
            count++;
        }

        Console.WriteLine($"\nTotal items: {items.Count}");
    }
}