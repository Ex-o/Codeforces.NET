using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using cfapi.HTTP;
using cfapi.Methods;
using cfapi.Methods.Request;
using cfapi.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace cfapiClient
{
    public class IOIEntry
    {
        public string Name { get; set; }
        public double P1 { get; set; }
        public double P2 { get; set; }
        public double P3 { get; set; }
        public double P4 { get; set; }
        public double P5 { get; set; }
        public double P6 { get; set; }

        public double Day1Total { get; set; }

        public double Day2Total { get; set; }

        public double Total { get; set; }
        public string CountryCode { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var req = new ProblemsRequest();
            var c = req.GetProblemSetAsync().Result;

            foreach(var p in c.Problems)
            {
                if(p.Name.ToLower().Contains("god"))
                {
                    Console.WriteLine(p.Name);
                }
            }
            Console.Read();
        }
        static void Main_Old(string[] args)
        {
            Dictionary<IOIEntry, int> scoreboard = new Dictionary<IOIEntry, int>();
            Dictionary<string, string> nameHandleLookup = new Dictionary<string, string>();
            Dictionary<string, string> nameCodeLookup = new Dictionary<string, string>();
            Dictionary<string, string> codeHandleLookup = new Dictionary<string, string>();

            var wc = new HttpClient();

            var scoresRaw = File.ReadAllText("scores.txt");
            var scoresJson = JsonConvert.DeserializeObject<dynamic>(scoresRaw);


            var usersRaw = File.ReadAllText("users.txt");
            var usersJson = JsonConvert.DeserializeObject<dynamic>(usersRaw);

            foreach(var entry in usersJson)
            {
                foreach(var data in entry)
                {
                    nameCodeLookup.Add(data["f_name"].ToString() + " " + data["l_name"].ToString(), entry.Name.ToString());
                    //Console.WriteLine(entry.Name + " " + data["f_name"] + " " + data["l_name"]);
                }
            }

            var ioiHandles = new StreamReader("handles.txt");
            string line;
            while((line = ioiHandles.ReadLine()) != null)
            {
                string name = "";
                var data = line.Split('\t');
                for (int i = 0; i < data.Length - 1; i++)
                    name += data[i] + " ";

                name = name.TrimEnd();
                if (data.Length < 3) continue;
                nameHandleLookup.Add(name, data.Last());
                scoreboard.Add(new IOIEntry() { Name = name, CountryCode = nameCodeLookup.FirstOrDefault(i => i.Key == name).Value}, 0);
            }

            foreach(var entry in nameHandleLookup)
            {
                var key = nameCodeLookup.FirstOrDefault(i => i.Key.ToLower() == entry.Key.ToLower()).Value;
                var val = nameHandleLookup.FirstOrDefault(i => i.Key.ToLower() == entry.Key.ToLower()).Value;
                codeHandleLookup.Add(key, val);
            }

            foreach (var entry in scoresJson)
            {
                foreach (var data in entry)
                {
                    //Console.WriteLine(entry.Name);
                    foreach (var prb in data)
                    {
                        var usr = scoreboard.FirstOrDefault(i => i.Key.CountryCode == entry.Name.ToString());
                        if (usr.Key == null) continue;
                        switch (prb.Name.ToString())
                        {
                            case "rect":
                                usr.Key.P1 = prb.Value;
                                break;
                            case "shoes":
                                usr.Key.P2 = prb.Value;
                                break;
                            case "split":
                                usr.Key.P3 = prb.Value;
                                break;
                            case "line":
                                usr.Key.P4 = prb.Value;
                                break;
                            case "vision":
                                usr.Key.P5 = prb.Value;
                                break;
                            case "walk":
                                usr.Key.P6 = prb.Value;
                                break;
                        }
                    }
                }
            }

            foreach(var entry in scoreboard)
            {
                entry.Key.Day1Total = entry.Key.P1 + entry.Key.P2 + entry.Key.P3;
                entry.Key.Day2Total = entry.Key.P4 + entry.Key.P5 + entry.Key.P6;
                entry.Key.Total = entry.Key.Day1Total + entry.Key.Day2Total;
            }

            foreach(var entry in scoreboard)
            {
                var handle = codeHandleLookup.FirstOrDefault(i => i.Key == entry.Key.CountryCode).Value;
                if (!String.IsNullOrEmpty(handle))
                {
                    var req = new UserInfoRequest();
                    var usr = req.GetUserInfo(handle);

                    if(usr.Rating != 0)
                        Console.WriteLine($"{usr.Rating}\t{entry.Key.Total}");
                    Thread.Sleep(250);
                }
            }
            //foreach(var entry in nameHandleLookup)
            //{
            //    var usr = nameCodeLookup.Count(i => i.Key.ToLower() == entry.Key.ToLower());

            //    if (usr == 0)
            //    {
            //        Console.WriteLine(entry.Key);
            //    }
            //}
            Console.Read();
        }
    }
}
