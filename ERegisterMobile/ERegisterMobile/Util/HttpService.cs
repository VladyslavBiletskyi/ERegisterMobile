using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ERegisterMobile.Util
{
    class HttpService
    {
        private static HttpClient client;

        private static HttpClient Client
        {
            get
            {
                if (client != null)
                {
                    return client;
                }
                else
                {
                    client = new HttpClient();
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Application.Current.Resources["token"].ToString());
                    return client;
                }
            }
        }

        public static async Task<object> GetAsync(string urlPart, Type castType =null)
        {
            HttpResponseMessage responce = await Client.GetAsync(""+urlPart);
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpRequestException();
            }
            object result = JsonConvert.DeserializeObject(await responce.Content.ReadAsStringAsync(), castType);
            return result;
        }
        public static async Task<object> PostAsync(string urlPart, object data, Type castType = null)
        {
            var myContent = JsonConvert.SerializeObject(data);
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            HttpResponseMessage responce = await Client.PostAsync(""+urlPart, byteContent);
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpRequestException();
            }
            object result = JsonConvert.DeserializeObject(await responce.Content.ReadAsStringAsync(), castType);
            return result;
        }
        public static async Task<object> Token(string userName, string password)
        {
            var list = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("UserName", userName),
                new KeyValuePair<string, string>("Password", password),
            };
            var myContent = new FormUrlEncodedContent(list);
            HttpResponseMessage responce = await Client.PostAsync("" + "token", myContent);
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpRequestException();
            }
            object result = JsonConvert.DeserializeObject(await responce.Content.ReadAsStringAsync(), typeof(Dictionary<string,string>));
            return result;
        }
    }
}
