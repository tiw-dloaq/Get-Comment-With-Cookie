using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using xNet;
namespace apigetcmt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            HttpRequest http = new HttpRequest();

            http.AddHeader("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            http.AddHeader("accept-language", "en-US,en;q=0.9");
            http.AddHeader("cache-control", "max-age=0");
         //   http.AddHeader("cookie", "sb=ARUoZu0Sjpps73PAQ7gMGT7t; dpr=1.25; datr=ARUoZnyr9P2CRIz1hoSc1YaI; ps_n=1; ps_l=1; locale=vi_VN; c_user=100061096937094; m_page_voice=100061096937094; xs=2%3A6ep1o1d0rBXapQ%3A2%3A1713902885%3A-1%3A14108%3A%3AAcVQYNIf2B_JKXMbCffYdtg0B49vpsgbaMUZD8NqsV8; cppo=1; wd=1536x730; fr=1lAUogD557obbSkE4.AWXB4add3mGGipa83pJ9KWdcmOI.BmMS8y..AAA.0.0.BmMTaz.AWVltCldQ4I; usida=eyJ2ZXIiOjEsImlkIjoiQXNjcm82b2Z6bWFlaiIsInRpbWUiOjE3MTQ1MDE1Njl9; presence=EDvF3EtimeF1714501573EuserFA21B61096937094A2EstateFDutF0CEchF_7bCC; c_user=100061096937094; fr=1W8sfNLcGUeS47PiN.AWU1G5smPEhzKzRWOTFiaH8IeM0.BmIVog..AAA.0.0.BmIVog.AWVXUAF-_Pk; xs=21%3AZsJpsDBU3niSUA%3A2%3A1712422133%3A-1%3A14108%3A%3AAcXgXSUD1gIqXOv3QI-XH3yhOCzo2F1Ry7f4P2HlyTk");
            http.AddHeader("priority", "u=0, i");
            http.AddHeader("sec-ch-ua", "\"Chromium\";v=\"124\", \"Google Chrome\";v=\"124\", \"Not-A.Brand\";v=\"99\"");
            http.AddHeader("sec-ch-ua-mobile", "?0");
            http.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            http.AddHeader("sec-fetch-dest", "document");
            http.AddHeader("sec-fetch-mode", "navigate");
            http.AddHeader("sec-fetch-site", "none");
            http.AddHeader("sec-fetch-user", "?1");
            http.AddHeader("upgrade-insecure-requests", "1");
            http.AddHeader("Referer", "https://graph.facebook.com");
            http.AddHeader("Origin", "https://graph.facebook.com");
            http.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124.0.0.0 Safari/537.36";
            string cookie = "sb=vdIMZm0jQwdBfnVCn02arK0f; datr=vdIMZhNYGkiFw8BAvyjbEYjW; dpr=1.25; oo=v1; locale=vi_VN; c_user=100061096937094; ps_n=0; ps_l=0; wd=1536x730; presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1712829912563%2C%22v%22%3A1%7D; usida=eyJ2ZXIiOjEsImlkIjoiQXNicnZpYXQ4MXQ4cyIsInRpbWUiOjE3MTI4MzA2NzV9; xs=21%3AZsJpsDBU3niSUA%3A2%3A1712422133%3A-1%3A14108%3A%3AAcXSspd5ZP7SCkl-RHLNDOXxPqLlgw2iauipDOpUtRg; fr=1tKYSOhUYPLOe5NOy.AWVz9duOvBIv87QV4R_XfpNITu4.BmF7jX..AAA.0.0.BmF7ji.AWVv52ttDvw";
            // can khoi tao cookie trc moi gan 
            http.Cookies = new CookieDictionary();
            // gán cookie 
            for (int c = 0; c < cookie.Split(':').Length; c++)
            {
                try
                {
                    string name = cookie.Split(';')[c].Split('=')[0].Trim();
                    string value = cookie.Split(';')[c].Substring(cookie.Split(';')[c].IndexOf('=') + 1).Trim();
                    if (http.Cookies.ContainsKey(name))
                        http.Cookies.Remove(name);
                    http.Cookies.Add(name, value);
                }
                catch (Exception) { }
            }
            string response = http.Get("https://graph.facebook.com/122137646372152573/comments?limit=10&access_token=EAAD6V7os0gcBOxDZBBjnZAo4ONbhPZBoQ7jD0J8CctsBvvsQpQNq30jGAv2puSJvYSAPSb2AK7HNftZAEdMMq7VaU1VYeP89BXSlQXUiPKZCquWnojYgzYZAm02ZBOjkmI8ZAxVh84k7X3Bp5UltqqnQAC05CDMXGc9jvYklHUN5SVdhUniSkun8G3wZD").ToString();
            // Parse JSON
            JObject jsonObject = JObject.Parse(response);
            JArray comments = (JArray)jsonObject["data"];

            // Extract data
            foreach (var comment in comments)
            {
                string name = (string)comment["from"]["name"];
                string id = (string)comment["from"]["id"];
                string message = (string)comment["message"];

                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"Message: {message}");
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
    
}
