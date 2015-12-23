using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace ANURLShortener
{
    public class GoogleURLShortener : IURLShortener
    {
        private string _googleDeveloperApiKey = string.Empty;

        public GoogleURLShortener(string apiKey)
        {
            this._googleDeveloperApiKey = apiKey;
        }

        public string getShortUrl(string longURL)
        {
            string shortUrl = string.Empty;

            string urlAuth = "https://www.googleapis.com/urlshortener/v1/url?key=" + this._googleDeveloperApiKey;


            var httpWebRequest = (HttpWebRequest)WebRequest.Create(urlAuth);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"longUrl\":\"" + longURL + "\"}";
                streamWriter.Write(json);
            }//End Using

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                shortUrl = JsonConvert.DeserializeObject<dynamic>(streamReader.ReadToEnd()).id;
            }//End Using

            return shortUrl;
        }//End Method
    

    }//End Class

}//End Namespace
