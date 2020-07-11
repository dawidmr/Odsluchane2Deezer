using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeezerPlaylistMaker
{
    public class CVSwriter
    {
        string path = @"C:\temp\";

        public void SaveToFile(string playListName, List<Song> songs)
        {
            var fileStream = File.Create($"{path}{playListName}.csv");

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.WriteLine($"Track name, Artist name, Playlistname, Type");

                foreach(var song in songs)
                {
                    writer.WriteLine($"{song.Title},{song.Artist},{playListName},Playlist track");
                }

                writer.Close();
            }
        }
    }
}
