using System;
using RadiosondeDataCollector.Collectors.Fetchers;
using RadiosondeDataCollector.Collectors.Parsers;

namespace RadiosondeDataLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("RadiosondeSoundingsLab");

            var countryCodeParser = new CountryCodesParser();

            var countryCodes = countryCodeParser
                .Parse(CountryCodesFetcher
                    .Fetch());

            var launchStationParser = new LaunchStationParser();

            var launchStations = launchStationParser
                .Parse(LaunchStationsFetcher
                    .Fetch());

            //Fetcher that reads the sturcture of the online repo and pull the info in

            //Parser service that populated the data objects

            //Database interface (create database structure / check db exists / tables exist / etc / migrations

            //Web portal / read data / authentication / authorization / Identity / 

            //Map that allows to select launch sites

            //Rest API to allow consumption of data

            Console.Read();
        }
    }
}
