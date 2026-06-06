using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity helps you relax by guiding slow breathing in and out.")
    {
    }

    protected override void Run(int duration)
    {
        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in...");
            ShowCountdown(4);

            Console.Write("\nBreathe out...");
            ShowCountdown(4);
        }
    }
}