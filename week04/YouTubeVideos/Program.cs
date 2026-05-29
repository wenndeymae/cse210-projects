using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("BINI - Here With You", "ABS-CBN Star Music", 211);
        v1.AddComment(new Comment("Jeffyu", "The vocal flip of colet in last chorus is so satisfying"));
        v1.AddComment(new Comment("Hannah Marie", "I really love stacey and colet's quality of voice"));
        v1.AddComment(new Comment("Mike", "Such a sweet song. Doesn't need a rap to sound cool. Just pure voice embracing you like a warm hugs."));

        Video v2 = new Video("Once You Try This Pasta Recipe, You’ll Never Stop Making It!", "Essen Recipes", 482);
        v2.AddComment(new Comment("Nazim", "I have prepared this for Ramadhan and set it out to break fast. Hope my family loves it."));
        v2.AddComment(new Comment("Johnny Hyzer", "A handful of your recipes have made their way to my dinning table, my family appreciates it. Thank you, wishing you the best."));
        v2.AddComment(new Comment("Ferris", "My wife and I always enjoy your cooking, my wife just said that this one will be high on her list Thanks very much"));

        Video v3 = new Video("Cooking Steak in the Rain | Wild Alaska Forest", "OLEKSII WILD COOKING", 1047);
        v3.AddComment(new Comment("Emma", "Me watching this at 1 AM after I forgot to eat dinner. It looks so good"));
        v3.AddComment(new Comment("Noah", "The sound of the rain hitting the fire and the meat sizzing at the same time is pure ASMR."));
        v3.AddComment(new Comment("Nony", "This video deserves a million views"));

        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        foreach (Video video in videos)
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("\nComments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment._name}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}