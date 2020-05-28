using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace syweb
{
    class executeRequest
    {
        public static string METHOD { get; set; }
        public static string URL { get; set; }
        public static string FORMAT { get; set; }
        public static string DATA { get; set; }

        public executeRequest(string url, string method, string format, string data)
        {
            URL = url;
            METHOD = method;
            FORMAT = format;
            DATA = data;
        }

        public void doRequest()
        {
            /*
            Console.WriteLine("I got the url: " + URL);
            Console.WriteLine("I got the method: " + METHOD);
            Console.WriteLine("I got the format: " + FORMAT);
            Console.WriteLine("I got the data: " + DATA);
            
            Console.ReadLine();
            */
            //Execute the holy request


            WebRequest request = WebRequest.Create(URL);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);

            if (response.StatusDescription == "OK")
            {
                Console.WriteLine("Server responded with OK..");
                Console.WriteLine("Logging data..\n\n");

                Stream dataStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(dataStream);

                string responseFromServer = sr.ReadToEnd();

                Console.WriteLine(responseFromServer);
                sr.Close();
                dataStream.Close();
                response.Close();
                Console.WriteLine("Request Done.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Server did not accept this request.");
                Console.ReadLine();
            }

        }
    }
}
