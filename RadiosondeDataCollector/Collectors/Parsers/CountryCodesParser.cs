using RadiosondeDataCollector.Models;
using RadiosondeDataDefinitions.Interfaces;
using System;
using System.Collections.Generic;

namespace RadiosondeDataCollector.Collectors.Parsers
{
    /// <summary>
    /// NOTE: Derived parameters and monthly means are available for a subset of the 
    /// stations listed and may not be available for the full period of record of any 
    /// one station.
    /// 
    /// II.FORMAT OF "igra2-country-list.txt"
    /// ------------------------------
    /// Variable Columns   Type
    /// ------------------------------
    /// CODE         1- 2    Character
    /// NAME         4-43    Character
    /// ------------------------------
    /// 
    /// These variables have the following definitions:
    /// CODE       is the FIPS country code of the country where the station is 
    /// located(from FIPS Publication 10-4 at
    /// www.cia.gov/cia/publications/factbook/appendix/appendix-d.html).
    /// NAME       is the name of the country.
    /// </summary>
    public class CountryCodesParser : BaseParser
    {
        public IList<IRadiosondeCountryCode> Parse(IEnumerable<string> lines)
        {
            return Parse<IRadiosondeCountryCode>(lines);
        }

        /// <summary>
        /// II.FORMAT OF "igra2-country-list.txt"
        /// ------------------------------
        /// Variable Columns   Type
        /// ------------------------------
        /// CODE         1- 2    Character
        /// NAME         4-43    Character
        /// ------------------------------
        protected override Dictionary<object, string> SplitLine(string line)
        {
            var lineElements = new Dictionary<object, string>();
            lineElements.Add(Fields.Code, line.Substring(0, 2).Trim());
            lineElements.Add(Fields.Name, line.Substring(3).Trim());

            return lineElements;
        }

        protected override void Validate(Dictionary<object, string> lineElements)
        {
        }

        protected override object ParseObjectFromLineElements<T>(Dictionary<object, string> lineElements)
        {
            var countryCode = new RadiosondeCountryCode
            {
                RecordId = GenerateID(),
                CreatedDateTimeStamp = DateTime.Now,
                Code = lineElements[Fields.Code],
                Name = lineElements[Fields.Name]
            };

            return countryCode;
        }

        protected enum Fields
        {
            Code,
            Name
        }
    }
}
