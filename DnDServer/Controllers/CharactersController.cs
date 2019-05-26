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
        private static Dictionary<string, dynamic> lowCharacters = new Dictionary<string, dynamic>();

        // GET: api/Characters
        public string Get([FromBody]dynamic name)
        {
            if(name != null)
            {
                return JsonConvert.SerializeObject(characters[name.ToString()]);
            }

            return JsonConvert.SerializeObject(characters);
        }

        private dynamic LowCharacter(dynamic character)
        {

            return null;
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
                                lowCharacters.Remove(name);
                            }

                            characters.Add(name, value.Value);
                            lowCharacters.Add(name, LowCharacter(value.Value));

                            break;
                        }
                    case "Change":
                        {
                            string obj = value.ValueName;
                            var character = characters[name];
                            switch (obj)
                            {
                                case "XP":
                                    {
                                        character.XP = (int)value.Value;
                                        break;
                                    }
                                case "Current HP":
                                    {
                                        character.CurrentHP = (int)value.Value;
                                        break;
                                    }
                                case "Time HP":
                                    {
                                        character.TimeHP = (int)value.Value;
                                        break;
                                    }
                                case "CheckBox Bone HP":
                                    {
                                        character.IsCheckedBoneHP = Boolean.Parse(value.Value.ToString());
                                        break;
                                    }
                                case "CheckBox Alive One":
                                    {
                                        character.DeadAndAlive.Alives[0] = Boolean.Parse(value.Value.ToString());
                                        break;
                                    }
                                case "CheckBox Alive Two":
                                    {
                                        character.DeadAndAlive.Alives[1] = Boolean.Parse(value.Value.ToString());
                                        break;
                                    }
                                case "CheckBox Alive Three":
                                    {
                                        character.DeadAndAlive.Alives[2] = Boolean.Parse(value.Value.ToString());
                                        break;
                                    }
                                case "CheckBox Death One":
                                    {
                                        character.DeadAndAlive.Deathes[0] = Boolean.Parse(value.Value.ToString());
                                        break;
                                    }
                                case "CheckBox Death Two":
                                    {
                                        character.DeadAndAlive.Deathes[0] = Boolean.Parse(value.Value.ToString());
                                        break;
                                    }
                                case "CheckBox Death Three":
                                    {
                                        character.DeadAndAlive.Deathes[0] = Boolean.Parse(value.Value.ToString());
                                        break;
                                    }
                                case "Copper":
                                    {
                                        character.Copper = (int)value.Value;
                                        break;
                                    }
                                case "Silver":
                                    {
                                        character.Silver = (int)value.Value;
                                        break;
                                    }
                                case "Electro":
                                    {
                                        character.Electro = (int)value.Value;
                                        break;
                                    }
                                case "Gold":
                                    {
                                        character.Gold = (int)value.Value;
                                        break;
                                    }
                                case "Platinum":
                                    {
                                        character.Platinum = (int)value.Value;
                                        break;
                                    }
                                case "Inspiration":
                                    {
                                        character.Inspiration = Boolean.Parse(value.Value.ToString());
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
