using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;

namespace DeezerPlaylistMaker
{
    public class OdsluchaneCrawler
    {
        private string StationNumber = "5";
        private string UrlTemplate = "https://www.odsluchane.eu/szukaj.php?r={0}&date={1}&time_from={2}&time_to={3}";

        public string GetDataFromOdlsuchane(string uri)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(uri);
            }
        }

        public string PrepareUri(string stationNumber, string date, string timeFrom, string timeTo)
        {
            return string.Format(UrlTemplate, stationNumber, date, timeFrom, timeTo);
        }

        public List<string> GetUris(string monthNumber, string yearNumber)
        {
            List<string> uris = new List<string>();
            for (int i=1; i<30; i++)
            {
                var date = $"{i.ToString("0#")}-{monthNumber}-{yearNumber}";

                uris.Add(PrepareUri(StationNumber, date, "7", "16"));
                uris.Add(PrepareUri(StationNumber, date, "17", "22"));
            }

            return uris;
        }

        public List<string> Manager(string month)
        {
            var uris = GetUris(month, "2020");

            var sites = new List<string>();

            foreach (var uri in uris)
            {
                sites.Add(GetDataFromOdlsuchane(uri));
            }

            //sites.Add(GetDataFromOdlsuchane(uris[0]));

            return sites;
        }
    }
}
