using System;
using System.Collections.Generic;

namespace RadiosondeDataDefinitions.Interfaces
{
    /// <summary>
    /// 8.1.2	Format of Header Record for One Sounding
    /// Each header record contains 99 characters, the first of which always is the pound sign(#). 
    /// The format is described below in terms of a Fortran 90/95 write statement, including format specifications, 
    /// followed by an explanation of each variable used in the statement.
    /// WRITE(udatafile, '('#',a11,i4,3i2.2,i4.4,i4,a9,i7,i8,i5,a2,a5,a20,a1,6a2)') &
    /// cStnid, iCurYear, iCurMon, iCurDay, iCurHour, iRTime, iNewNLvls, cClouds, &
    /// iLat, iLon, iElev, cObsType, cSondeType, cSerialNum, cSerialNumType, &
    /// cCorP, cCorZ, cCorT, cCorH, cCorD, cCorW
    /// [source: www1.ncdc.noaa.gov/pub/data/igra/igra2-dataset-description.docx]
    /// </summary>
    public interface IRadiosondeSounding
    {
        string RecordId { get; set; }

        DateTime CreatedDateTimeStamp { get; set; }

        /// <summary>
        /// CStnid is the 11-character station identification code. the station identification code used in 
        ///the source data should be right-justified in this field and should be left-padded with zeros. 
        ///Sounding should not be written if a station number is not available. If several different types of 
        ///station identification codes are used in the same source dataset (for example, WBAN and WMO numbers), 
        ///the type of station number can be identified in the third character of the 11-character station 
        ///identifier as follows: A = U.S. Air Force number, R = six-digit CARDS number, S = ship, U = unknown, 
        ///W = WBAN number, 0 = other. 
        /// </summary>
        string LaunchSiteId { get; set; }

        ///<summary>
        ///iCurYear is the four-digit year of the sounding.Valid range may depend on the source dataset but should 
        ///not exceed 1900-2008. the sounding should not be written if this value is not available or is outside the 
        ///valid range.
        ///</summary>
        int LaunchYear { get; set; }

        ///<summary>
        ///iCurMon is the two-digit month of the sounding. A valid range is 01-12. the sounding should not be written 
        ///if this value is not available or is outside the valid range
        ///</summary>
        int LaunchMonth { get; set; }

        /// <summary>
        /// iCurday is the two-digit day of the sounding. Valid range is 01 through the last possible day of the 
        /// month (for example, 01-28 for February 2007, 01-29 for February 2008, 01-31 for any March). the sounding 
        /// should not be written if this value is not available or is outside the valid range. 
        /// </summary>
        int LaunchDay { get; set; }

        /// <summary>
        /// iCurHour is the two-digit observation hour of the sounding. Valid range is 00-24 UTC 
        /// (permitting both zero UTC and 24 UTC.) The missing value code is 99; the hour is permitted to be missing if
        /// a valid release hour is available (see next field). The sounding should not be written if is outside the 
        /// valid range. 
        /// </summary>
        int LaunchHour { get; set; }

        /// <summary>
        /// iRTime is the actual time of release of the sonde. Units are hhmm (i.e., hour and minutes UTC). Missing 
        /// value code = 9999.
        /// </summary>
        int LaunchTime { get; set; }

        /// <summary>
        /// iNewNLvls is the number of levels in the sounding that are written to the output data file 
        /// (i.e., the number of data lines that follow this header). Valid range is 1-9999. For obvious reasons, this 
        /// value cannot 
        /// be missing.
        /// </summary>
        int NumberOfLevelsInSounding { get; set; }

        /// <summary>
        /// cClouds is a nine-character code giving weather and cloud observations. Use whatever codes are provided in
        /// the source 
        /// dataset. If none are provided, set the entire string to blank.
        /// </summary>
        string CloudInformation { get; set; }

        /// <summary>
        /// iLat is the latitude, if generally provided once per sounding in the source data. Units are degrees*10**4. 
        /// Missing value code is -999999.
        /// </summary>
        decimal Latitude { get; set; }

        /// <summary>
        /// iLon is the longitude, if generally provided once per sounding in the source data. Units are degrees*10**4. 
        /// Missing value code is -9999999.
        /// </summary>
        decimal Longitude { get; set; }

        /// <summary>
        /// iElev is the site elevation, if generally provided once per sounding in the source data. Units are m*10. 
        /// Missing value code is -9999.
        /// </summary>
        decimal Elevation { get; set; }

        /// <summary>
        /// cObsType is the type of observation taken during the current flight. Use whatever code is used in the 
        /// source dataset. If missing, the field should be left blank.
        /// </summary>
        string ObservationType { get; set; }

        /// <summary>
        /// cSondeType is the type of sonde used for the current flight. Use whatever code is used in the source 
        /// dataset. If missing, the field should be left blank.
        /// </summary>
        string SondeType { get; set; }

        /// <summary>
        /// cSerialNum is the serial number or baroswitch used. This number should be left aligned within the 
        /// 20-character field. If not available, the field should be left blank.
        /// </summary>
        string SerialNumber { get; set; }

        /// <summary>
        /// cSerialNumType is the type of serial number identifying the sonde. It can take the following values: 
        /// B = baroswitch number; R = radiosonde serial number.If missing or unknown, the field should be left blank.
        /// </summary>
        string SerialNumberType { get; set; }

        /// <summary>
        /// cCorP is the type of correction applied at the station to the pressure values in the sounding. 
        /// Use whatever code is used in the source dataset. If missing, the field should be left blank.
        /// </summary>
        string PressureCorrection { get; set; }

        /// <summary>
        /// cCorZ is the type of correction applied at the station to geopotential height values in the sounding. 
        /// Use whatever code is used in the source dataset. If missing, the field should be left blank.
        /// </summary>
        string GeopotentialHeightCorrection { get; set; }

        /// <summary>
        /// cCorT is the type of correction applied at the station to temperature values in the sounding. 
        /// Use whatever code is used in the source dataset. If missing, the field should be left blank.
        /// </summary>
        string TemperatureCorrection { get; set; }

        /// <summary>
        /// cCorrH is the type of correction applied at the station to relative humidity values in the sounding. 
        /// Use whatever code is used in the source dataset. If missing, the field should be left blank.
        /// </summary>
        string RelativeHumidityCorrection { get; set; }

        /// <summary>
        /// cCorD is the type of correction applied at the station to dew-point depression values in the sounding. 
        /// Use whatever code is used in the source dataset. If missing, the field should be left blank.
        /// </summary>
        string DewPointCorrection { get; set; }

        /// <summary>
        /// cCorW is the type of correction applied at the station to wind direction and speed values in the sounding. 
        /// Use whatever code is used in the source dataset. If missing, the field should be left blank.
        /// </summary>
        string WindSpeedAndDirectionCorrection { get; set; }

        /// <summary>
        /// Levels withing sounding
        /// </summary>
        IEnumerable<IRadiosondeSoundingLevel> Levels { get; set; }
    }
}
