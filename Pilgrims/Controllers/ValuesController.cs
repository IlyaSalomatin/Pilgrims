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
        public List<Human> Get()
        {
            List<Human> hm = new List<Human>();
            hm = DataBase.Read();
            //hm.Add(new Human { ID = 7, Name = "Lenar", SecondName = "Hoyt", Birthday = "13.01.2505", Planet = "Hyperion" });
            //DataBase.Write(hm);
            return (hm);
        }

        // GET api/values/5
        public Human Get(int id)
        {
            List<Human> hm = new List<Human>();
            Human pl = new Human();
            hm = DataBase.Read();
            foreach (var i in hm)
            {
                if (i.ID == id)
                {
                    pl = i;
                }
            }
            return (pl);
        }

        // POST api/values
        public string Post([FromBody]Human value)
        {
            List<Human> hm = new List<Human>();
            hm = DataBase.Read();
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
        public void Put(int id, [FromBody]string value)
        {
            List<Human> hm = new List<Human>();
            hm = DataBase.Read();
            Human pl = new Human();
            foreach (var i in hm)
            {
                if (i.ID==id)
                {
                    pl = i;
                }

            }
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
