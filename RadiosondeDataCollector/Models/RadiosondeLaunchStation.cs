using RadiosondeDataDefinitions.Interfaces;

namespace RadiosondeDataCollector.Models
{
    public class RadiosondeLaunchStation : BaseRecord, IRadiosondeLaunchStation
    {
        public string Id { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public decimal Elevation { get; set; }

        public string State { get; set; }

        public string Name { get; set; }

        public int FirstYear { get; set; }

        public int LastYear { get; set; }

        public int Nobs { get; set; }
    }
}
