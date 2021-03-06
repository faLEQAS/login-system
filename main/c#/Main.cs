using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

namespace login_system
{
    public class main
    {
        public static string filename = "info.json";

        public static void Main(string[] args)
        {
            try
            {
                login();
            }
            catch (Exception ex)
            {
                if (ex is System.IO.FileNotFoundException || ex is System.NullReferenceException)
                {
                  register();  
                }
            }

            Console.ReadLine();
        }

        public static void WriteJson(Dictionary<string, string> contents)
        //writes a dictionary to a json file.
        {
            string json_contents = JsonConvert.SerializeObject(contents);
            File.WriteAllText(filename, json_contents);
        }

        public static Dictionary<string, string> ReadJson()
        //Returns json file contents as dictionary 
        {
            string file_string = File.ReadAllText(filename);
            var file_contents = JsonConvert.DeserializeObject<Dictionary<string, string>>(file_string);
            return file_contents;
        }

        public static Tuple<string, string> get_input()
        {
            Console.WriteLine("Enter a username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter a password");
            string password = Console.ReadLine();
            return Tuple.Create(username,password);
        }

        public static void register()
        {
            Tuple<string, string> credintals = get_input();
            Dictionary<string, string> contents = new Dictionary<string, string>();
            contents.Add("username",credintals.Item1);
            contents.Add("password",credintals.Item2);
            WriteJson(contents);
            Console.WriteLine(string.Format("Successfully registered with the username {0}.", credintals.Item1));
        }

        public static void login()
        {
            Dictionary<string, string> dict = ReadJson();
            string user_name = dict["username"];
            string user_password = dict["password"];
            Tuple<string, string> entered_credintals = get_input();

            if (user_name == entered_credintals.Item1 && user_password == entered_credintals.Item2)
            {
                Console.WriteLine("Access Granted!");
            }
            else
            {
                Console.WriteLine("Access Denied.");
            }
        }
    }
}
