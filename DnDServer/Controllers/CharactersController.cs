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
                                        a.XP = (int)value.Value;
                                        break;
                                    }
                                case "Current HP":
                                    {
                                        var a = characters[name];
                                        a.currentHP = (int)value.Value;
                                        break;
                                    }
                                case "Time HP":
                                    {
                                    var a = characters[name];
                                        a.timeHP = (int)value.Value;
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
                                    var a = characters[name];
                                        a.copper = (int)value.Value;
                                        break;
                                    }
                                case "Silver":
                                    {
                                    var a = characters[name];
                                        a.silver = (int)value.Value;
                                        break;
                                    }
                                case "Electro":
                                    {
                                    var a = characters[name];
                                        a.electro = (int)value.Value;
                                        break;
                                    }
                                case "Gold":
                                    {
                                    var a = characters[name];
                                        a.gold = (int)value.Value;
                                        break;
                                    }
                                case "Platinum":
                                    {
                                    var a = characters[name];
                                        a.platinum = (int)value.Value;
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
                                    var a = characters[name];
                                        a.inspiration = (bool)value.Value;
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
