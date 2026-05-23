using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        List<Scripture> scriptures = new List<Scripture>()
        {
            new Scripture(
                new Reference("Moses", 6, 34),
                "Behold my Spirit is upon you, wherefore all thy words will I justify; and the mountains shall flee before you, and the rivers shall turn from their course; and thou shalt abide in me, and I in you; therefore walk with me."
            ),

            new Scripture(
                new Reference("Doctrine and Covenants", 6, 36),
                "Look unto me in every thought; doubt not, fear not."
            ),

            new Scripture(
                new Reference("3 Nephi", 5, 13),
                "Behold, I am a disciple of Jesus Christ, the Son of God. I have been called of him to declare his word among his people, that they might have everlasting life."
            ),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding."
            )
        };

        int index = random.Next(scriptures.Count);
        Scripture scripture = scriptures[index];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("\nPress Enter to continue or type 'quit'");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}