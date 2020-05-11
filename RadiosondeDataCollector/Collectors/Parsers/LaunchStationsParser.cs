using RadiosondeDataCollector.Models;
using RadiosondeDataDefinitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RadiosondeDataCollector.Collectors.Parsers
{
    /// <summary>
    /// I. FORMAT OF "igra2-station-list.txt"
    ///
    /// ------------------------------
    /// Variable Columns   Type
    /// ------------------------------
    /// ID            1-11   Character
    /// LATITUDE     13-20   Real
    /// LONGITUDE    22-30   Real
    /// ELEVATION    32-37   Real
    /// STATE        39-40   Character
    /// NAME         42-71   Character
    /// FSTYEAR      73-76   Integer
    /// LSTYEAR      78-81   Integer
    /// NOBS         83-88   Integer
    /// ------------------------------
    /// 
    /// These variables have the following definitions:
    /// ID is the station identification code.Note that the first two characters denote the FIPS  country code, the third character
    /// is a network code that identifies the station numbering system used, and the remaining eight characters contain the actual
    /// station ID. 
    /// 
    /// See "igra2-country-list.txt" for a complete list of country codes.
    /// 
    /// The network code has the following five values:
    /// 
    /// I = ICAO callsign (last four characters of the IGRA 2 ID)
    /// M = WMO identification number(last five characters of the IGRA 2 ID)
    /// V = Volunteer Observing Ship callsign(last four to six characters of the IGRA 2 ID)
    /// W = Weather Bureau, Army, Navy (WBAN) identification number (last five characters of the IGRA 2 ID)
    /// X = Specially constructed station identifier("UA" followed by an additional six alphanumeric characters)
    /// 
    /// LATITUDE   is the latitude of the station(in decimal degrees, mobile = -98.8888).
    /// 
    /// LONGITUDE  is the longitude of the station(in decimal degrees, mobile = -998.8888).
    /// 
    /// ELEVATION  is the elevation of the station(in meters, missing = -999.9, mobile = -998.8).
    /// 
    /// STATE      is the U.S.postal code for the state (for stations in the United States, Puerto Rico, and Virgin Islands only).
    /// 
    /// NAME       is the name of the station.
    /// 
    /// FSTYEAR    is the first year of record in the sounding data.
    /// 
    /// LSTYEAR    is the last year of record in the sounding data.
    /// 
    /// NOBS   	   is the number of soundings in the sounding data record.
    /// ----------------------------------------------------------------------------------------------------------------------------
    /// NOTE: Derived parameters and monthly means are available for a subset of the stations listed and may not be available for the 
    /// full period of record of any one station.
    /// </summary>
    public class LaunchStationParser : BaseParser
    {
        public IList<IRadiosondeLaunchStation> Parse(IEnumerable<string> lines)
        {
            return Parse<IRadiosondeLaunchStation>(lines);
        }

        /// <summary>
        /// ------------------------------
        /// Variable Columns   Type
        /// ------------------------------
        /// ID            1-11   Character
        /// LATITUDE     13-20   Real
        /// LONGITUDE    22-30   Real
        /// ELEVATION    32-37   Real
        /// STATE        39-40   Character
        /// NAME         42-71   Character
        /// FSTYEAR      73-76   Integer
        /// LSTYEAR      78-81   Integer
        /// NOBS         83-88   Integer
        /// ------------------------------
        /// </summary>
        protected override Dictionary<object, string> SplitLine(string line)
        {
            Dictionary<object, string> lineElements = new Dictionary<object, string>();

            lineElements.Add(
                Fields.Id,
                FindSubstringAndRemoveSubstringFromLine(11, ref line).Trim());

            lineElements.Add(
                Fields.Latitude,
                FindFirstMatchWithRegexAndRemoveMatchFromLine(@"[-+]?\d*\.\d*", ref line).Trim());

            lineElements.Add(
                Fields.Longitude,
                FindFirstMatchWithRegexAndRemoveMatchFromLine(@"[-+]?\d*\.\d*", ref line).Trim());

            lineElements.Add(
                Fields.Elevation,
                FindFirstMatchWithRegexAndRemoveMatchFromLine(@"[-+]?\d*\.\d*", ref line).Trim());

            lineElements.Add(
                Fields.Nobs,
                FindLastMatchWithRegexAndRemoveMatchFromLine(@"[-+]?\d*\s*", ref line).Trim());

            lineElements.Add(
                Fields.LastYear,
                FindLastMatchWithRegexAndRemoveMatchFromLine(@"\d{4}", ref line).Trim());

            lineElements.Add(
                Fields.FirstYear,
                FindLastMatchWithRegexAndRemoveMatchFromLine(@"\d{4}", ref line).Trim());

            lineElements.Add(
                Fields.State,
                FindSubstringAndRemoveSubstringFromLine(4, ref line).Trim());

            lineElements.Add(
                Fields.Name,
                line.Trim());

            return lineElements;
        }

        protected override void Validate(Dictionary<object, string> lineElements)
        {
        }

        protected override object ParseObjectFromLineElements<T>(Dictionary<object, string> lineElements)
        {
            var radiosonde = new RadiosondeLaunchStation
            {
                RecordId = GenerateID(),
                CreatedDateTimeStamp = DateTime.Now,
                Id = lineElements[Fields.Id],
                Latitude = Convert.ToDecimal(lineElements[Fields.Latitude]),
                Longitude = Convert.ToDecimal(lineElements[Fields.Longitude]),
                Elevation = Convert.ToDecimal(lineElements[Fields.Elevation]),
                State = lineElements[Fields.State],
                Name = lineElements[Fields.Name],
                FirstYear = Convert.ToInt32(lineElements[Fields.FirstYear]),
                LastYear = Convert.ToInt32(lineElements[Fields.LastYear]),
                Nobs = Convert.ToInt32(lineElements[Fields.Nobs])
            };

            return radiosonde;
        }

        protected enum Fields
        {
            Id,
            Latitude,
            Longitude,
            Elevation,
            State,
            Name,
            FirstYear,
            LastYear,
            Nobs
        }
    }
}
