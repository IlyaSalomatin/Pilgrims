using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Pilgrims.Models
{
    public static class DataBase
    {
        public static string path = @"E:\программирование\works3\mvc1\work11\Pilgrims\Pilgrims\bin\Pilgrims.xml";
        public static void Write(List<Human> h)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Human>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, h);
            }
        }

        public static List<Human> Read()
        {
            List<Human> h = new List<Human>();
            XmlSerializer xs = new XmlSerializer(typeof(List<Human>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                h = (List<Human>)xs.Deserialize(fs);
            }
            return h;
        }
    }
}