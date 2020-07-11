using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DeezerPlaylistMaker
{
    public class Converter
    {
        public List<Song> ConvertSitesToSongs(List<string> sites)
        {
            var songs = new List<Song>();

            foreach(var site in sites)
            {
                songs.AddRange(ConvertSiteToSongs(site));
            }

            return songs;
        }

        private List<Song> ConvertSiteToSongs(string site)
        {
            Regex regex = new Regex("open.spotify.com/search/results/(.*?)\"");
            var matches = regex.Matches(site);
            var songs = new List<Song>();

            foreach(var match in matches.ToList())
            {
                var stringSong = match.Groups[1]?.Value;

                songs.Add(new Song(stringSong));
            }

            return songs;
        }
    }
}
