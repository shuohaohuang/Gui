using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace Gui
{
    public class Csv
    {
        const string Path = "Consum_d_aigua_a_Catalunya_per_comarques_20240402.csv";

        public static List<County> ReadCounties()
        {
            List<County> counties = new List<County>();

            using var reader = new StreamReader(Path);

            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                Console.WriteLine(csv.GetField("Any"));

                counties.Add(
                    new(
                        csv.GetField<int>("Any"),
                        csv.GetField<int>("Codi comarca"),
                        csv.GetField<string>("Comarca"),
                        csv.GetField<int>("Població"),
                        csv.GetField<int>("Domèstic xarxa"),
                        csv.GetField<int>("Activitats econòmiques i fonts pròpies"),
                        csv.GetField<int>("Total"),
                        csv.GetField<float>("Consum domèstic per càpita")
                    )
                );
            }

            return counties;
        }
    }
}
