using System;
using System.Collections.Generic;
using System.Text;

namespace RadiosondeDataDefinitions.Interfaces
{
    /// <summary>
    /// 8.1.3	Format of Data Record for One Level 
    /// Each data record contains the data for one atmospheric level as defined by the pressure value, 
    /// a height value, or both.It contains 43 characters, including two characters for the level type and 
    /// eight integer data values. The format is described below in terms of a Fortran 90/95 write statement, 
    /// including format specifications, followed by an explanation of each variable used in the statement.
    /// WRITE(udatafile,'(a2,i5,i6,6i5)') &
    /// cLvlTypes(i), iETimes(i), iPressures(i), iHeights(i), iTemps(i), &
    /// iRelHums(i), iDewDeps(i), iWDirs(i), iWSpeeds(i)
    /// [source: www1.ncdc.noaa.gov/pub/data/igra/igra2-dataset-description.docx]
    /// </summary>
    public interface IRadiosondeSoundingLevel
    {
        /// <summary>
        /// iETimes(i) is the time elapsed since the release of the sonde. Units are whole minutes and seconds (mmmss). 
        /// Missing value code is -9999.
        /// </summary>
        string ElapsedTime { get; set; }

        /// <summary>
        /// iPressures(i) is the pressure at level i. Units are Pa (mb * 100). Missing value code is -9999.
        /// </summary>
        string Pressure { get; set; }

        /// <summary>
        /// iHeights(i) is the geopotential height at level i. Units are whole meters. Missing value code is -9999.
        /// </summary>
        string GeopotentialHeight { get; set; }

        /// <summary>
        /// iTemps(i) is the temperature at level i. Units are deg C * 10. Missing value code is -9999.
        /// </summary>
        string Temperature { get; set; }

        /// <summary>
        /// iRelHums(i) is the relative humidity at level i. Units are %*10. Missing value code is -9999.
        /// </summary>
        string RelativeHumidity { get; set; }

        /// <summary>
        /// iDewDeps(i) is the dew-point depression at level i. Units are deg C * 10. Missing value code is -9999.
        /// </summary>
        string DewpointDepression { get; set; }

        /// <summary>
        /// iWDirs(i) is the wind direction at level i. Units are whole degrees from North (going clockwise). Missing value code is -9999.
        /// </summary>
        string WindDirection { get; set; }

        /// <summary>
        /// iWSpeeds(i) is the wind speed at level i. Units are m/s * 10. Missing value code is -9999.
        /// </summary>
        string WindSpeed { get; set; }
    }
}
