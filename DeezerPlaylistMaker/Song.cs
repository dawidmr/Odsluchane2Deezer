using System;
using System.Collections.Generic;
using System.Text;

namespace DeezerPlaylistMaker
{
    public class Song
    {
        public Song(string stringSong)
        {
            string[] parts = stringSong.Split(" - ");

            Artist = parts[0];
            Title = parts[1];
        }

        public string Artist { get; set; }
        public string Title { get; set; }
    }
}
