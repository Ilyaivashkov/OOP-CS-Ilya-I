using System;
using System.Collections.Generic;

namespace MusicApp
{
    public class Playlist
    {
        //Приватные поля
        private List<string> songs; // коллекция песен в плейлисте
        private string playlistName; // название плейлиста
        private int maxSongsCount; // максимальное количество песен, которое может быть в плейлисте

        //Открытые свойства
        public string PlaylistName
        {
            get { return playlistName; }
        }

        public int MaxSongsCount
        {
            get { return maxSongsCount; }
        }

        public int SongsCount
        {
            get { return songs.Count; }
        }

        // Конструктор
        public Playlist(string playlistName, int maxSongsCount)
        {
            if (playlistName == "")
            {
                Console.WriteLine("Название не может быть пустым");
                return;
            }

            if (maxSongsCount <= 0)
            {
                Console.WriteLine("Максимальное количество песен не может быть меньше или равно нулю");
                return;
            }

            this.playlistName = playlistName;
            this.maxSongsCount = maxSongsCount;
            songs = new List<string>();
        }

        // Добавление песни в плейлист (метод AddSong)
        public bool AddSong(string song)
        {
            if (songs.Count >= maxSongsCount)
            {
                return false;
            }

            if (songs.Contains(song))
            {
                return false;
            }

            songs.Add(song);
            return true;
        }

        // Удаление песни из плейлиста
        public bool RemoveSong(string song)
        {
            if (songs.Contains(song))
            {
                songs.Remove(song);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Возвращение строки с информацией о плейлисте
        public string GetPlaylistInfo()
        {
            string info = "Плейлист: " + playlistName + ", Песен: " + SongsCount + ", Песни: ";

            for (int i = 0; i < songs.Count; i++)
            {
                info += "'" + songs[i] + "'";
                if (i != songs.Count - 1)
                {
                    info += ", ";
                }
            }

            return info;
        }

        // Очистка всех песен в плейлисте
        public void ClearPlaylist()
        {
            songs.Clear();
        }
    }
}
