﻿using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title))
            throw new ArgumentException("Title cannot be null or empty");

        Random rand = new Random();
        this.id = rand.Next(10000, 99999); // Generate random 5-digit ID
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0)
            throw new ArgumentException("Play count cannot be negative");

        this.playCount += count;
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
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Nur Ilmli Mufidah");
        video.PrintVideoDetails();

        video.IncreasePlayCount(10);
        video.PrintVideoDetails();
    }
}