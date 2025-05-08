using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicPlayer player = new MusicPlayer();

            // Додавання треків
            player.AddTrack(new Track("Song 1", "Artist 1", new TimeSpan(0, 3, 45)));
            player.AddTrack(new Track("Song 2", "Artist 2", new TimeSpan(0, 4, 20)));
            player.AddTrack(new Track("Song 3", "Artist 3", new TimeSpan(0, 5, 10)));

            // Створення плейлиста
            player.AddPlaylist("My Favorite Songs");

            // Додавання треків до плейлиста
            player.AddTrackToPlaylist("My Favorite Songs", new Track("Song 1", "Artist 1", new TimeSpan(0, 3, 45)));
            player.AddTrackToPlaylist("My Favorite Songs", new Track("Song 2", "Artist 2", new TimeSpan(0, 4, 20)));

            // Відтворення плейлиста
            player.PlayPlaylist("My Favorite Songs");

            // Видалення треку
            player.RemoveTrack("Song 2");

            // Оновлення інформації про трек
            player.UpdateTrack("Song 3", "Song 3 (Remastered)", "Artist 3", new TimeSpan(0, 5, 50));

            Console.ReadLine();
        }
    }


    public class Track
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Duration { get; set; }

        public Track(string title, string artist, TimeSpan duration)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist} [{Duration:mm\\:ss}]";
        }
    }
    public class MusicPlayer
    {
        private List<Track> _tracks = new List<Track>();
        private Dictionary<string, List<Track>> _playlists = new Dictionary<string, List<Track>>();

        // Додавання треку
        public void AddTrack(Track track)
        {
            _tracks.Add(track);
            Console.WriteLine($"Track '{track.Title}' by {track.Artist} added.");
        }

        // Видалення треку
        public void RemoveTrack(string title)
        {
            var track = _tracks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (track != null)
            {
                _tracks.Remove(track);
                Console.WriteLine($"Track '{track.Title}' removed.");
            }
            else
            {
                Console.WriteLine("Track not found.");
            }
        }

        // Оновлення інформації про трек
        public void UpdateTrack(string oldTitle, string newTitle, string newArtist, TimeSpan newDuration)
        {
            var track = _tracks.FirstOrDefault(t => t.Title.Equals(oldTitle, StringComparison.OrdinalIgnoreCase));
            if (track != null)
            {
                track.Title = newTitle;
                track.Artist = newArtist;
                track.Duration = newDuration;
                Console.WriteLine($"Track '{oldTitle}' updated.");
            }
            else
            {
                Console.WriteLine("Track not found.");
            }
        }

        // Додавання плейлиста
        public void AddPlaylist(string playlistName)
        {
            if (!_playlists.ContainsKey(playlistName))
            {
                _playlists[playlistName] = new List<Track>();
                Console.WriteLine($"Playlist '{playlistName}' created.");
            }
            else
            {
                Console.WriteLine("Playlist already exists.");
            }
        }

        // Додавання треку до плейлиста
        public void AddTrackToPlaylist(string playlistName, Track track)
        {
            if (_playlists.ContainsKey(playlistName))
            {
                _playlists[playlistName].Add(track);
                Console.WriteLine($"Track '{track.Title}' added to playlist '{playlistName}'.");
            }
            else
            {
                Console.WriteLine("Playlist not found.");
            }
        }

        // Відтворення треків з плейлиста
        public void PlayPlaylist(string playlistName)
        {
            if (_playlists.ContainsKey(playlistName))
            {
                Console.WriteLine($"Playing playlist '{playlistName}':");
                foreach (var track in _playlists[playlistName])
                {
                    Console.WriteLine(track);
                }
            }
            else
            {
                Console.WriteLine("Playlist not found.");
            }
        }
    }

}
