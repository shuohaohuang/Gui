using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gui
{
    public class Xml
    {
        const string Path = "Comarques.xml";


        public static void Create(Dictionary<int, string> counties)
        {
            if (!File.Exists(Path))
            {
                XDocument root = new XDocument(new XElement("Comarques"));
                foreach (var county in counties)
                {
                    XElement child = new XElement(
                        "Comarca",
                        new XAttribute("Codi", county.Key),
                        new XElement("Nom", county.Value)
                    );
                    root.Element("Comarques").Add(child);
                }
                using (var writer = File.CreateText(Path)) { }
                root.Save(Path);
            }
        }

        public static Dictionary<int, string> Read()
        {
            XDocument reader = XDocument.Load(Path);
            Dictionary<int, string> county = new Dictionary<int, string>();
            foreach (var countyEntry in reader.Descendants("Comarca"))
            {
                county[Convert.ToInt32(countyEntry.Attribute("Codi").Value)] = countyEntry.Value;
            }
            return county;
        }
    }
}
