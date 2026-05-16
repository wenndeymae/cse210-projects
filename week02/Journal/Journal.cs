using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned today?",
        "What challenge did I face today and how did I handle it?",
        "What made me smile today?",
        "What is something I am grateful for today?",
        "How did I help someone today?",
        "What is one goal I want to focus on tomorrow?",
        "What distracted me today and how can I improve?",
        "What is one positive habit I practiced today?",
        "What scripture or quote inspired me today?",
        "How did I grow as a person today?",
        "What is something I want to remember from today?",
        "What was the most peaceful moment of my day?",
        "What is one thing I could improve tomorrow?",
        "How did I take care of myself today?",
        "What am I most proud of today?"
    };

    public void WriteEntry()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        string randomPrompt = _prompts[index];

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("> ");
        string response = Console.ReadLine();

        Entry entry = new Entry();

        DateTime now = DateTime.Now;
        entry._date = now.ToShortDateString();
        entry._time = now.ToShortTimeString();

        entry._prompt = randomPrompt;
        entry._response = response;

        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter output = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                output.WriteLine($"{entry._date}|{entry._time}|{entry._prompt}|{entry._response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);

        _entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._time = parts[1];
            entry._prompt = parts[2];
            entry._response = parts[3];

            _entries.Add(entry);
        }
    }
}