using System;

namespace DeezerPlaylistMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            var sites = new OdsluchaneCrawler().Manager("06");

            var songs = new Converter().ConvertSitesToSongs(sites);

            new Cleaner().CleanCharacters(songs);

            songs = new Cleaner().GetUniqueSongs(songs);

            new CVSwriter().SaveToFile("Antyradio czerwiec", songs);
        }
    }
}
