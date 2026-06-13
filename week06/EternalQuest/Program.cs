// Exceeds Requirements:
// I added a leveling system based on score, rank titles (Beginner, Goal Crusher, Legendary Hero),
// and a random bonus reward system to make the program more engaging and game-like.
// These gamification features motivate users to continue completing goals.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== ETERNAL QUEST ===");
            Console.WriteLine($"Score: {score} | Level: {GetLevel()} | Rank: {GetRank()}");
            Console.WriteLine();

            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Quit");

            string choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoals();
            else if (choice == "3") RecordEvent();
            else if (choice == "4") Save();
            else if (choice == "5") Load();
            else if (choice == "6") break;
        }
    }

    static int GetLevel() => score / 1000 + 1;

    static string GetRank()
    {
        int level = GetLevel();
        if (level >= 10) return "Legendary Hero";
        if (level >= 5) return "Goal Crusher";
        return "Beginner";
    }

    static void CreateGoal()
    {
        Console.WriteLine("1.Simple 2.Eternal 3.Checklist");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
            goals.Add(new SimpleGoal(name, desc, points));

        else if (type == "2")
            goals.Add(new EternalGoal(name, desc, points));

        else if (type == "3")
        {
            Console.Write("Target: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    static void ListGoals()
    {
        int i = 1;
        foreach (Goal g in goals)
        {
            Console.WriteLine($"{i}. {g.GetStatus()} {g.GetName()}");
            i++;
        }
        Console.ReadLine();
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Choose goal #: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int earned = goals[index].RecordEvent();
        score += earned;

        Console.WriteLine($"You earned {earned} points!");

        // 🎁 GAMIFICATION BONUS (random reward)
        Random r = new Random();
        if (r.Next(5) == 0)
        {
            Console.WriteLine("🎉 Lucky Bonus! +50 points!");
            score += 50;
        }

        Console.ReadLine();
    }

    static void Save()
    {
        using (StreamWriter sw = new StreamWriter("goals.txt"))
        {
            sw.WriteLine(score);

            foreach (Goal g in goals)
                sw.WriteLine(g.GetSaveString());
        }
    }

    static void Load()
    {
        string[] lines = File.ReadAllLines("goals.txt");

        score = int.Parse(lines[0]);
        goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] p = lines[i].Split("|");

            if (p[0] == "Simple")
                goals.Add(new SimpleGoal(p[1], p[2], int.Parse(p[3])));

            else if (p[0] == "Eternal")
                goals.Add(new EternalGoal(p[1], p[2], int.Parse(p[3])));

            else if (p[0] == "Checklist")
                goals.Add(new ChecklistGoal(
                    p[1], p[2],
                    int.Parse(p[3]),
                    int.Parse(p[5]),
                    int.Parse(p[6])
                ));
        }
    }
}