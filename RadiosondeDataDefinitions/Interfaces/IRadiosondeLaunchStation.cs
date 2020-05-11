using System;

namespace RadiosondeDataDefinitions.Interfaces
{
    /// <summary>
    /// 8.2.2	Station List Format
    /// This file contains one record per station ID.When extracting the station information from an inventory or
    /// metadata file, a record should be written only if the latitude, longitude, and station name are available 
    /// along with the station ID. The following format is similar to that used in the GHCN-Daily station list 
    /// whose format we plan to closely follow when eventually creating the IGRA 2 station list.
    /// [source: www1.ncdc.noaa.gov/pub/data/igra/igra2-dataset-description.docx]
    /// </summary>
    public interface IRadiosondeLaunchStation
    {
        string RecordId { get; set; }

        DateTime CreatedDateTimeStamp { get; set; }

        /// <summary>
        /// ID is the station identification code in the 11-character format we use when reformatting data (see Section 8.1.2). 
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// LATITUDE is the latest available latitude of the station (in decimal degrees) as determined from 
        /// the inventory or metadata file being reformatted.
        /// </summary>
        decimal Latitude { get; set; }

        /// <summary>
        /// LONGITUDE is the latest available longitude of the station (in decimal degrees) as determined from 
        /// the inventory or metadata file being reformatted.
        /// </summary>
        decimal Longitude { get; set; }

        /// <summary>
        /// ELEVATION is the latest available elevation of the station (in meters and tenths, e.g., 5.0, missing = -999.9)
        /// as determined from the inventory or metadata file being reformatted.
        /// </summary>
        decimal Elevation { get; set; }

        /// <summary>
        /// STATE is the U.S.postal code for the state (for U.S.stations only) if available in the inventory or metadata 
        /// file being reformatted.Otherwise, this field should be left blank.
        /// </summary>
        string State { get; set; }

        /// <summary>
        /// NAME is the name of the station.
        /// </summary>
        string Name { get; set; }

        int FirstYear { get; set; }

        int LastYear { get; set; }

        int Nobs { get; set; }

        /// <summary>
        /// FIPS is the two-letter FIPS country code if provided in the inventory or metadata file being reformatted.
        /// Otherwise, this field should be left blank.
        /// </summary>
        //string Fips { get; set; }

        /// <summary>
        /// CALL is the four-letter international callsign of the station if provided in the inventory or metadata file
        /// being reformatted. Otherwise, this field should be left blank.
        /// </summary>
        //string Call { get; set; }

        /// <summary>
        /// WMOID is the WMO number for the station if provided in the inventory or metadata file being reformatted. 
        /// If the WMO ID is not provided in that file or if the station has no WMO number, then the field is blank.
        /// </summary>
        //string WmoId { get; set; }
    }
}
