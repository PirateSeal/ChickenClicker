using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChickenFarmer.Model
{
    public static class Serialization
    {
        public static void Save(string path, Farm farm)
        {
            XElement xElement =  farm.ToXml();
            xElement.Save(path);
        }

        public static Farm Load(string path)
        {
            XElement xElement = XElement.Load(path);
            Farm loadedFarm = new Farm(xElement);
            return loadedFarm;
        }
    }
}
