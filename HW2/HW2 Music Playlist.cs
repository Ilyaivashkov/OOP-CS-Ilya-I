using System;
using System.Collections.Generic;

namespace MusicApp
{
    /// <summary>
    /// Represents a playlist that holds a collection of unique songs.
    /// </summary>
    public class Playlist
    {
        // Private fields
        private readonly List<string> _songs;
        private readonly string _playlistName;
        private readonly int _maxSongsCount;

        // Public properties (read-only)
        public string PlaylistName => _playlistName;

        public int MaxSongsCount => _maxSongsCount;

        public int SongsCount => _songs.Count;

        /// <summary>
        /// Initializes a new instance of the Playlist class.
        /// </summary>
        /// <param name="playlistName">The name of the playlist.</param>
        /// <param name="maxSongsCount">The maximum number of songs allowed in the playlist.</param>
        /// <exception cref="ArgumentException">Thrown when the playlist name is empty or maxSongsCount is invalid.</exception>
        public Playlist(string playlistName, int maxSongsCount)
        {
            if (string.IsNullOrWhiteSpace(playlistName))
            {
                throw new ArgumentException("Playlist name cannot be empty.");
            }

            if (maxSongsCount <= 0)
            {
                throw new ArgumentException("Maximum number of songs must be greater than zero.");
            }

            _playlistName = playlistName;
            _maxSongsCount = maxSongsCount;
            _songs = new List<string>();
        }

        /// <summary>
        /// Adds a song to the playlist if there's space and it's not a duplicate.
        /// </summary>
        /// <param name="song">The name of the song to add.</param>
        /// <returns>True if the song was added, false otherwise.</returns>
        public bool AddSong(string song)
        {
            if (_songs.Count >= _maxSongsCount)
            {
                return false;
            }

            if (_songs.Contains(song))
            {
                return false;
            }

            _songs.Add(song);
            return true;
        }

        /// <summary>
        /// Removes a song from the playlist if it exists.
        /// </summary>
        /// <param name="song">The name of the song to remove.</param>
        /// <returns>True if the song was removed, false otherwise.</returns>
        public bool RemoveSong(string song)
        {
            return _songs.Remove(song);
        }

        /// <summary>
        /// Returns information about the playlist including its name, song count, and song list.
        /// </summary>
        /// <returns>A string containing playlist details.</returns>
        public string GetPlaylistInfo()
        {
            string songList = string.Join(", ", _songs);
            string info = $"Playlist: {_playlistName}, Songs: {SongsCount}, Titles: {songList}";
            return info;
        }

        /// <summary>
        /// Removes all songs from the playlist.
        /// </summary>
        public void ClearPlaylist()
        {
            _songs.Clear();
        }
    }
}
