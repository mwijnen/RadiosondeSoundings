using System;
using System.Collections.Generic;
using System.Text;
using RadiosondeDataDefinitions.Interfaces;

namespace RadiosondeDataCollector.Models
{
    public class RadiosondeCountryCode : BaseRecord, IRadiosondeCountryCode
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
