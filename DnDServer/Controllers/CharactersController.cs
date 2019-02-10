using DnDServer.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace DnDServer.Controllers
{
    public class CharactersController : ApiController
    {
        private static Dictionary<string, dynamic> characters = new Dictionary<string, dynamic>();

        // GET: api/Characters
        public string Get()
        {
            return JsonConvert.SerializeObject(characters);
        }

        // POST: api/Characters
        public void Post([FromBody]dynamic value)
        {
            try
            {
                string action = value.Action;
                switch (action)
                {
                    case "Load":
                        {
                            string name = value.UserName;
                            if (characters.ContainsKey(name))
                            {
                                characters.Remove(name);
                            }

                            characters.Add(name, value.Value);

                            break;
                        }
                    case "Change":
                        {

                            break;
                        }
                }
            }
            catch {
            }
        }
    }
}