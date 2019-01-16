using DnDServer.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace DnDServer.Controllers
{
    public class CharactersController : ApiController
    {
        private Dictionary<string, Character> characters = new Dictionary<string, Character>();

        // GET: api/Characters
        public string Get()
        {
            return JsonConvert.SerializeObject(characters);
        }

        // POST: api/Characters
        public void Post([FromBody]dynamic value)
        {
            switch (value.Action)
            {
                case "Load":
                    {
                        if (characters.ContainsKey(value.UserName))
                        {
                            characters.Remove(value.UserName);
                        }

                        characters.Add(value.UserName, value.Value);

                        break;
                    }
                case "Change":
                    {
                        break;
                    }
            }
        }
    }
}