//using System;

//class SayaTubeVideo
//{
//    private int id;
//    private string title;
//    private int playCount;

//    public SayaTubeVideo(string title)
//    {
//        if (string.IsNullOrEmpty(title))
//            throw new ArgumentException("Title cannot be null or empty");

//        Random rand = new Random();
//        this.id = rand.Next(10000, 99999); // Generate random 5-digit ID
//        this.title = title;
//        this.playCount = 0;
//    }

//    public void IncreasePlayCount(int count)
//    {
//        if (count < 0)
//            throw new ArgumentException("Play count cannot be negative");

//        this.playCount += count;
//    }

//    public void PrintVideoDetails()
//    {
//        Console.WriteLine("Video ID: " + id);
//        Console.WriteLine("Title: " + title);
//        Console.WriteLine("Play Count: " + playCount);
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Nur Ilmli Mufidah");
//        video.PrintVideoDetails();

//        video.IncreasePlayCount(10);
//        video.PrintVideoDetails();
//    }
//}

using System.Diagnostics;

using System;
using System.Diagnostics;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Debug.Assert(!string.IsNullOrEmpty(title) && title.Length <= 100, "Title cannot be null and must be at most 100 characters long");

        Random rand = new Random();
        this.id = rand.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count > 0 && count <= 10000000, "Play count must be between 1 and 10,000,000");

        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Play count exceeded the maximum integer limit.");
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Video ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}

class Program
{
    static void Main()
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Nur Ilmi Mufidah");
        video.PrintVideoDetails();

        video.IncreasePlayCount(10);
        video.PrintVideoDetails();

        for (int i = 0; i < 100; i++)
        {
            video.IncreasePlayCount(10000000);
        }
    }
}