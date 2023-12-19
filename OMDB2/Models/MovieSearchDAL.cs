using Newtonsoft.Json;
using System.Net;

namespace OMDB2.Models
{
    public class MovieSearchDAL
    {
        public static Movie GetMovie(string title) //Adjust here
        {
            //Adjust
            //Setup
            string apiKey = Secret.apiKey;
            string url = $"https://www.omdbapi.com/?t={title}&apikey={apiKey}";

            //Request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Converting to json
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Convert to c#
            Movie result = JsonConvert.DeserializeObject<Movie>(JSON);
            return result;
        }
    }
}
