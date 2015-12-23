using ANURLShortener.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANURLShortener
{
    public class URLShortenerFactory
    {

        public static IURLShortener GetInstance(Hashtable shortenerAPISetting, URLShortenerType shortenerType)
        {
            IURLShortener urlShortenerInstance = null;
            switch (shortenerType)
            {
                case URLShortenerType.GoogleURLShortener:
                    if (!shortenerAPISetting.ContainsKey("APIKey"))
                        throw new NullReferenceException("APIKey setting should not be null for Google URL Shortener API");

                    string apiKey = shortenerAPISetting["APIKey"].ToString();

                    urlShortenerInstance = new GoogleURLShortener(apiKey);
                    break;
                default:
                    break;
            }//End Switch

            return urlShortenerInstance;

        }


    }
}
