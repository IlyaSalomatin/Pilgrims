using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;
using System.IO;
using Pilgrims.Models;

namespace Pilgrims.Controllers
{
    public class ValuesController : ApiController
    {
        public List<HumanT> Get()
        {           
            List<Human> hm = new List<Human>();
            hm = DataBase.Read();           
            List<HumanT> tm = new List<HumanT>();            
            foreach (var i in hm)
            {
                HumanT t = new HumanT();
                t.ID = i.ID;
                t.Name = i.Name;
                t.SecondName = i.SecondName;
                t.Birthday = i.Birthday;
                t.Planet = i.Planet;
                tm.Add(t);
            }
            //hm.Add(new Human { ID = 7, Name = "Lenar", SecondName = "Hoyt", Birthday = "13.01.2505", Planet = "Hyperion" });
            //DataBase.Write(hm);
            return (tm);
        }

        // GET api/values/5
        public HumanT Get(int id)
        {
            HumanT t = new HumanT();
            List<Human> hm = new List<Human>();
            Human pl = new Human();
            hm = DataBase.Read();
            foreach (var i in hm)
            {
                if (i.ID == id)
                {
                    t.ID = i.ID;
                    t.Name = i.Name;
                    t.SecondName = i.SecondName;
                    t.Planet = i.Planet;
                    t.Birthday = i.Birthday;                                        
                    break;
                }
            }
            return (t);
        }

        // POST api/values
        public string Post([FromBody]Human value)
        {
            List<Human> hm = new List<Human>();
            hm = DataBase.Read();
            if (value.Name == null && value.SecondName == null && value.Planet == null && value.Birthday == null)
            {
                return ("Fill in all the fields!");
            }
            foreach (var i in hm)
            {
                if (i.ID==value.ID)
                {
                    return ("Id is not available!");
                }                
            }
            hm.Add(value);
            DataBase.Write(hm);
            return ("Pilgrim is added.");
        }

        // PUT api/values/5
        public string Put([FromBody]Human value)
        {
            List<Human> hm = new List<Human>();
            hm = DataBase.Read();            
            foreach (var i in hm)
            {
                if (i.ID == value.ID)
                {
                    i.Name=value.Name;
                    i.SecondName = value.SecondName;
                    i.Birthday = value.Birthday;
                    i.Planet = value.Planet;
                    DataBase.Write(hm);
                    return ("Pilgrim is update.");
                }
            }
            return ("SOME ERROR!!!");
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            List<Human> hm = new List<Human>();            
            hm = DataBase.Read();
            foreach (Human i in hm)
            {
                if (i.ID == id)
                {
                    hm.Remove(i);
                    DataBase.Write(hm);
                    return ("- is DELETED!!!");
                }                
            }
            return ("SOME ERROR!!!");
        }
    }
}
