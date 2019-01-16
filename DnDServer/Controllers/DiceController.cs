using Newtonsoft.Json;
using System.Web.Http;

namespace DnDServer.Controllers
{
    public class DiceController : ApiController
    {
        // POST: api/Dice
        public dynamic Post([FromBody]dynamic value)
        {
            if (value.Message == "hello")
            {
                return null;
            }

            string message;
            Dice.AdvantageAndInterference advantageAndInterference;

            if (value.AdvantageAndInterference == 0)
            {
                advantageAndInterference = Dice.AdvantageAndInterference.Normal;
                message = "Обычный бросок";
            }
            else if (value.AdvantageAndInterference == 1)
            {
                advantageAndInterference = Dice.AdvantageAndInterference.Advantage;
                message = "Бросок с преимуществом";
            }
            else
            {
                advantageAndInterference = Dice.AdvantageAndInterference.Interference;
                message = "Бросок с помехой";
            }

            var result = Dice.ThrowDice(int.Parse(value.CountDices.ToString()), int.Parse(value.Edges.ToString()), advantageAndInterference);

            return JsonConvert.SerializeObject(new Dice.Result((value.Edges == 20 && result == 20), result + int.Parse(value.Bonus.ToString()), message));
        }
    }
}