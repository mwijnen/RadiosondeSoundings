using System;

namespace RadiosondeDataDefinitions.Interfaces
{
    public interface IRadiosondeCountryCode
    {
        string RecordId { get; set; }

        DateTime CreatedDateTimeStamp { get; set; }

        string Code { get; set; }

        string Name { get; set; }
    }
}
