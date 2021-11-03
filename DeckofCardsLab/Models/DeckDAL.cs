using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeckofCardsLab.Models
{
    public class DeckDAL
    {
        public DeckModel GetDeck()
        {
            string url = $"https://deckofcardsapi.com/api/deck/new/";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd();

            DeckModel result = JsonConvert.DeserializeObject<DeckModel>(JSON);

            return result;
        }

        public void ShuffleDeck(string id)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{id}/shuffle//";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        }

        public HandModel GetHand(string id)
        {
            string url = $"https://deckofcardsapi.com/api/deck/{id}/draw/?count=5";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string JSON = reader.ReadToEnd();

            HandModel result = JsonConvert.DeserializeObject<HandModel>(JSON);

            return result;
        }
    }

}
