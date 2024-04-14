using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui
{
    public class County
    {
        public int Year { get; set; }
        public int CountyCode { get; set; }
        public string CountyName { get; set; }
        public int Population { get; set; }
        public int DomesticNetwork { get; set; }
        public int EconomicActivities { get; set; }
        public int Total { get; set; }
        public float DomesticConsumptionPerCapita { get; set; }

        public County(
            int year,
            int countyCode,
            string countyName,
            int population,
            int domesticNetwork,
            int economicActivities,
            int total,
            float domesticConsumptionPerCapita
        )
        {
            Year = year;
            CountyCode = countyCode;
            CountyName = countyName;
            Population = population;
            DomesticNetwork = domesticNetwork;
            EconomicActivities = economicActivities;
            Total = total;
            DomesticConsumptionPerCapita = domesticConsumptionPerCapita;
        }
    }
}
