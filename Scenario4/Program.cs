using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        LinkedList<string> playlist = new LinkedList<string>();
        SortedList<int, string> sortedSongs = new SortedList<int, string>();

        playlist.AddLast("Shape of You");
        playlist.AddLast("Believer");
        playlist.AddLast("Perfect");

        playlist.AddFirst("Senorita");

        sortedSongs.Add(3, "Perfect");
        sortedSongs.Add(1, "Senorita");
        sortedSongs.Add(2, "Believer");
        sortedSongs.Add(4, "Shape of You");

        Console.WriteLine("=== Playlist Songs ===");
        foreach (string song in playlist)
        {
            Console.WriteLine(song);
        }

        playlist.Remove("Believer");

        Console.WriteLine("\n=== Playlist After Removing Song ===");
        foreach (string song in playlist)
        {
            Console.WriteLine(song);
        }

        Console.WriteLine("\n=== Songs Sorted by Rank ===");
        foreach (var song in sortedSongs)
        {
            Console.WriteLine($"Rank {song.Key}: {song.Value}");
        }
    }
}
