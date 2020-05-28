using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syweb
{
    class Program
    {
        public static bool SyntaxCorrect = false;

        static void ShowCorrectSyntax()
        {
            Console.WriteLine("Available Commands:\n");
            Console.WriteLine("syweb get <URL <parameters(optional)>> <format>");
            Console.WriteLine("syweb post <URL <parameters(optional)>> <format> <data>");
            Console.WriteLine("syweb patch <URL <parameters(optional)>> <format> <data>");
            Console.WriteLine("syweb put <URL <parameters(optional)>> <format> <data>");
            Console.WriteLine("Allowed formats are: 'raw' 'json' 'multiencode' leave format empty for using the raw format");
        }


        static void checksyntax(string[] args, string method)
        {

            if (args[1] == null)
            {
                SyntaxCorrect = false;
                return;
            }

  


            if (method == "POST" || method == "PUT" || method == "patch")
            {
                    string format = "";
                    string data = "";
                    executeRequest exec = new executeRequest(args[1], method, format, null);
                    exec.doRequest();
            }
            else if(method == "GET")
            {
                string format = "";
                    executeRequest exec = new executeRequest(args[1], method, format, null);
                    exec.doRequest();
            }
            else
            {
                Console.WriteLine("The entered method is invalid.");
                ShowCorrectSyntax();
            }

        }

        static void Main(string[] args)
        {
            string method = "";
            try
            {
                switch (args[0])
                {
                    case "get":
                        method = "GET";
                        checksyntax(args, method);
                        break;
                    case "post":
                        method = "POST";
                        checksyntax(args, method);
                        break;
                    case "patch":
                        method = "PATCH";
                        checksyntax(args, method);
                        break;
                    case "put":
                        method = "PUT";
                        checksyntax(args, method);
                        break;
                    // End Main Commands
                    // Start Help Commands
                    case "--help":
                        ShowCorrectSyntax();
                        break;
                    case "help":
                        ShowCorrectSyntax();
                        break;
                    case "-help":
                        ShowCorrectSyntax();
                        break;
                    default:
                        Console.WriteLine("NOPE: Please enter the correct syntax.\n");
                        ShowCorrectSyntax();
                        break;
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("\nError: None or too much parameters given.\n");
                ShowCorrectSyntax();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
