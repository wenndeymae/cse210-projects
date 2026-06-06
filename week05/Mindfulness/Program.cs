// EXCEEDING REQUIREMENTS:
// I improved the Listing Activity by allowing the user to enter multiple items in a list.
// The user can type each item and press Enter to go to the next one.
// I also added an option for the user to type "0" when they are finished.
// At the end, the program shows all the items the user entered in a numbered list.

using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            if (choice == "1")
                activity = new BreathingActivity();
            else if (choice == "2")
                activity = new ReflectionActivity();
            else if (choice == "3")
                activity = new ListingActivity();
            else if (choice == "4")
                break;

            if (activity != null)
            {
                activity.StartActivity(0);
                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }
    }
}