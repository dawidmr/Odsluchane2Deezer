using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace DeezerPlaylistMaker
{
    public class Cleaner
    {
        const string titleMark = "&#039;";

        public void CleanCharacters(List<Song> songs)
        {
            foreach(var song in songs)
            {
                var artistIndex = song.Artist.IndexOf("&#");
                if (artistIndex != -1)
                {
                    song.Artist = song.Artist.Substring(0, artistIndex);
                }

                var artistComaIndex = song.Artist.IndexOf(',');
                if (artistComaIndex != -1)
                {
                    song.Artist = song.Artist.Substring(0, artistComaIndex);
                }

                var titleIndex = song.Title.IndexOf(titleMark);

                while (titleIndex != -1)
                {
                    song.Title = song.Title.Remove(titleIndex, titleMark.Length);

                    titleIndex = song.Title.IndexOf(titleMark);
                }

                var comaIndex = song.Title.IndexOf(',');

                while (comaIndex != -1)
                {
                    song.Title = song.Title.Remove(comaIndex, 1);

                    comaIndex = song.Title.IndexOf(',');
                }
            }
        }

        public List<Song> GetUniqueSongs(List<Song> songs)
        {
            return songs.Distinct(new SongComparer()).ToList();
        }
    }

    public class SongComparer : IEqualityComparer<Song>
    {
        public bool Equals([AllowNull] Song x, [AllowNull] Song y)
        {
            if (x.Artist == y.Artist && x.Title == y.Title)
                return true;
            else
                return false;
        }

        public int GetHashCode([DisallowNull] Song obj)
        {
            return $"{obj.Artist}{obj.Title}".GetHashCode();
        }
    }
}
