using System.Web.Http;

namespace DnDServer.Controllers
{
    public class ChatController : ApiController
    {
        // GET: api/Chat
        public string Get()
        {
            return History.GetMessages();
        }

        // POST: api/Chat
        public void Post([FromBody]dynamic value)
        {
            if (value.Message == "hello")
            {
                History.AddMessage(string.Format("{0} присоединился(ась)", value.Name));

            }
            else if (value.Message == "goodbye")
            {
                History.AddMessage(string.Format("{0} отключился(ась)", value.Name));
            }
            else
            {
                History.AddMessage(string.Format("{0}: {1}", value.Name, value.Message));
            }
        }
    }
}