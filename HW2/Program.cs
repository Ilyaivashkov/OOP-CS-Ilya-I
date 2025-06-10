using System;

namespace MusicApp
{
    public class Program
    {
        public static void Main()
        {
            var playlist = new Playlist("My Favorite Songs", 5);
            playlist.AddSong("Imagine");
            playlist.AddSong("Bohemian Rhapsody");
            playlist.AddSong("Stairway to Heaven");

            Console.WriteLine(playlist.GetPlaylistInfo());

            playlist.RemoveSong("Imagine");

            Console.WriteLine(playlist.GetPlaylistInfo());
        }
    }
}
