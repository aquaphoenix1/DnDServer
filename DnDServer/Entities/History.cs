using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DnDServer.Controllers
{
    public class History
    {
        private static int id = 0;
        private static Dictionary<int, string> messages = new Dictionary<int, string>();
        private static int MAX_HISTORY_SIZE = 20;

        public static dynamic GetMessages()
        {
            return JsonConvert.SerializeObject(messages);
        }

        public static void AddMessage(string message)
        {
            if (messages.Count > MAX_HISTORY_SIZE)
            {
                messages.Remove(messages.ElementAt(0).Key);
            }

            messages.Add(++id, message);
        }
    }
}