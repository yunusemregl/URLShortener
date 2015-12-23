using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ANURLShortener.Test
{
    class Program
    {

        private const string googleURLShortnerAPIKey = "Google Developer API Key should be set";

        static void Main(string[] args)
        {


            Console.WriteLine("Welcome the Google URL Shortener Test.");

            Console.WriteLine();
            Console.Write("Please enter the url: ");
            string longURL = Console.ReadLine();

            IURLShortener urlShortener = GetGoogleURLShortenerInstance();


            string shortURL = urlShortener.getShortUrl(longURL);

            Console.WriteLine("Short URL: " + shortURL);

            Console.ReadLine();


        }


        public static IURLShortener GetGoogleURLShortenerInstance()
        {
            Hashtable htSetting = new Hashtable();
            htSetting.Add("APIKey", googleURLShortnerAPIKey);
            return URLShortenerFactory.GetInstance(htSetting, Enum.URLShortenerType.GoogleURLShortener);
        }//End Method


    }
}
