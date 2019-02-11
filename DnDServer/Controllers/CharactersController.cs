using DnDServer.Entities;
using Newtonsoft.Json;
using System;
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
                string name = value.UserName;

                string action = value.Action;
                switch (action)
                {
                    case "Load":
                        {
                            if (characters.ContainsKey(name))
                            {
                                characters.Remove(name);
                            }

                            characters.Add(name, value.Value);

                            break;
                        }
                    case "Change":
                        {
                            string obj = value.ValueName;
                            switch (obj)
                            {
                                case "XP":
                                    {
                                        var a = characters[name];
                                        var b = a.XP;
                                        b = (int)value.Value;
                                        break;
                                    }
                                case "Current HP":
                                    {
                                        break;
                                    }
                                case "Time HP":
                                    {
                                        break;
                                    }
                                case "CheckBox Bone HP":
                                    {
                                        break;
                                    }
                                case "CheckBox Alive One":
                                    {
                                        break;
                                    }
                                case "CheckBox Alive Two":
                                    {
                                        break;
                                    }
                                case "CheckBox Alive Three":
                                    {
                                        break;
                                    }
                                case "CheckBox Death One":
                                    {
                                        break;
                                    }
                                case "CheckBox Death Two":
                                    {
                                        break;
                                    }
                                case "CheckBox Death Three":
                                    {
                                        break;

                                    }
                                case "Copper":
                                    {
                                        break;
                                    }
                                case "Silver":
                                    {
                                        break;
                                    }
                                case "Electro":
                                    {
                                        break;
                                    }
                                case "Gold":
                                    {
                                        break;
                                    }
                                case "Platinum":
                                    {
                                        break;
                                    }
                                case "d1":
                                    {
                                        //TODO
                                        break;
                                    }
                                case "d2":
                                    {
                                        //TODO
                                        break;
                                    }
                                case "d3":
                                    {
                                        //TODO
                                        break;
                                    }
                                case "Inspiration":
                                    {
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
            catch (Exception e){
            }
        }
    }
}
