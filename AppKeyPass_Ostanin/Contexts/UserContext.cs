using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppKeyPass_Ostanin.Contexts
{
    public class UserContext
    {
        static string url = "https://localhost:7135/user/";

        public static async Task<string> Login(string login, string password)
        {
            using (HttpClient Client = new HttpClient())
            {
                using (HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Post, url + "login"))
                {
                    Dictionary<string, string> FormData = new Dictionary<string, string>
                    {
                        ["login"] = login,
                        ["password"] = password
                    };

                    FormUrlEncodedContent Content = new FormUrlEncodedContent(FormData);
                    Request.Content = Content;

                    var Response = await Client.SendAsync(Request);

                    if (Response.StatusCode == HttpStatusCode.OK)
                    {
                        string sResponse = await Response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(sResponse);
                        return json["token"].ToString();
                    }
                }
            }
            return null;
        }
    }
}