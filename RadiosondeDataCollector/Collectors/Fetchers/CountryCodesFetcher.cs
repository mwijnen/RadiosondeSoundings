using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace RadiosondeDataCollector.Collectors.Fetchers
{
    static public class CountryCodesFetcher
    {
        public static bool PrintToConsole = true;

        public static string FileLocation = @"www1.ncdc.noaa.gov/pub/data/igra/igra2-country-list.txt";

        public static IEnumerable<string> Fetch()
        {
            var request = WebRequest.Create(@"https://" + FileLocation);
            var response = request.GetResponse();
            var line = string.Empty;
            var lines = new List<string>();

            using (var dataStream = response.GetResponseStream())
            {
                var reader = new StreamReader(dataStream);

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();

                    if (PrintToConsole)
                    {
                        Console.WriteLine($"{typeof(CountryCodesFetcher)} fetching: {line}");
                    }

                    lines.Add(line);
                }
            }

            response.Close();
            return lines;
        }
    }
}
