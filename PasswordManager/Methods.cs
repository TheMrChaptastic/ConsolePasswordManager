using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace PasswordManager
{
    public static class Methods
    {
        const string csvPath = "passwords.csv";

        public static void StartUp()
        {
            var lines = LoadData();
            var parser = new Parser();
            Services.List = lines.Select(parser.Parse).ToList();
        }

        public static string[] LoadData()
        {
            return File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Data\", csvPath));
        }

        public static void SaveData()
        {
            var wList = new List<string>();
            foreach(var s in Services.List)
            {
                wList.Add($"{s.Service},{s.Email},{s.Password},{s.SChar},{s.UCase},{s.PassLength}");
            }
            File.WriteAllLines(Path.Combine(Environment.CurrentDirectory, @"Data\", csvPath), wList);
        }

        public static void AddData()
        {
            var cont = false;
            var nData = new TrackData();
            var sc = false;
            var uc = false;
            var length = 0;

            Console.WriteLine("Enter service name: "); 
            nData.Service = Console.ReadLine().Trim();

            Console.WriteLine("Enter Email: ");
            nData.Email = Console.ReadLine().Trim();

            while (!cont)
            {
                Console.WriteLine("Special Char? (true/false)");
                cont = bool.TryParse(Console.ReadLine().ToLower(), out sc);
                nData.SChar = sc;

                Console.WriteLine("Upper case? (true/false)");
                cont = bool.TryParse(Console.ReadLine().ToLower(), out uc);
                nData.UCase = uc;

                Console.WriteLine("Password Max Length? ");
                cont = int.TryParse(Console.ReadLine(), out length);
                if(length > 15) 
                { 
                    length = 15;
                }
                nData.PassLength = length;
            }

            var pass = PasswordGenerator.MakePassword(length, uc, sc);
            nData.Password = pass;

            Services.List.Add(nData);
            SaveData();
        }

        public static void EditData()
        {
            var cont = false;
            var error = false;
            var index = 0;
            var exit = 0;
            do
            {
                Modules.ShowMenu();
                if (error)
                {
                    Console.WriteLine("ID Doesn't Exist.");
                    error = false;
                }
                Console.WriteLine("Enter ID To Enter Password Manually: ");
                var bCheck = Console.ReadLine().ToLower();
                if (bCheck == "back" || bCheck == "exit")
                {
                    exit = 1;
                    break;
                }
                cont = int.TryParse(bCheck, out index);
                if (index > Services.List.Count() || index <= 0)
                {
                    cont = false;
                    error = true;
                }
            } while (!cont);

            if (exit == 0)
            {
                Console.WriteLine("Enter Password CAREFULLY! ");
                var manualInput = Console.ReadLine();
                Services.List[index - 1].Password = manualInput;
                SaveData();
            }
        }

        public static void DeleteData()
        {
            var cont = false;
            var error = false;
            var index = 0;
            var exit = 0;
            do
            {
                Modules.ShowMenu();
                if (error)
                {
                    Console.WriteLine("ID Doesn't Exist.");
                    error = false;
                }
                Console.WriteLine("Enter ID To Get Password: ");
                var bCheck = Console.ReadLine().ToLower();
                if (bCheck == "back" || bCheck == "exit")
                {
                    exit = 1;
                    break;
                }
                cont = int.TryParse(bCheck, out index);
                if (index > Services.List.Count() || index <= 0)
                {
                    cont = false;
                    error = true;
                }
            } while (!cont);

            if(exit == 0)
            {
                Services.List.RemoveAt(index - 1);
                SaveData();
            }
        }

        public static void ResetPasswordData()
        {
            var cont = false;
            var error = false;
            var index = 0;
            var exit = 0;
            do
            {
                Modules.ShowMenu();
                if (error)
                {
                    Console.WriteLine("ID Doesn't Exist.");
                    error = false;
                }
                Console.WriteLine("Enter ID To Get Password: ");
                var bCheck = Console.ReadLine().ToLower();
                if (bCheck == "back" || bCheck == "exit")
                {
                    exit = 1;
                    break;
                }
                cont = int.TryParse(bCheck, out index);
                if (index > Services.List.Count() || index <= 0)
                {
                    cont = false;
                    error = true;
                }
                else
                {
                    Console.WriteLine($"Confirm reset to Password for {Services.List[index - 1].Service}? (yes/no)");
                    cont = Console.ReadLine().ToLower() == "yes" ? true : false;
                }
            } while (!cont);
            if (exit == 0)
            {
                Services.List[index - 1].Password = PasswordGenerator.MakePassword(Services.List[index - 1].PassLength, 
                    Services.List[index - 1].SChar, 
                    Services.List[index - 1].UCase);
                SaveData();
            }
        }

        public static void ShowPassword()
        {
            var cont = false;
            var error = false;
            var index = 0;
            var exit = 0;
            do
            {
                Modules.ShowMenu();
                if (error)
                {
                    Console.WriteLine("ID Doesn't Exist.");
                    error = false;
                }
                Console.WriteLine("Enter ID To Get Password: ");
                var bCheck = Console.ReadLine().ToLower();
                if (bCheck == "back" || bCheck == "exit")
                {
                    exit = 1;
                    break;
                }
                cont = int.TryParse(bCheck, out index);
                if (index > Services.List.Count() || index <= 0)
                {
                    cont = false;
                    error = true;
                }
            } while (!cont);
            if(exit == 0)
            {
                Console.WriteLine($"Password: {Services.List[index - 1].Password}");
                Console.WriteLine("Hit Enter To Return To Menu.");
                Console.ReadLine();
            }
        }

    }
}
