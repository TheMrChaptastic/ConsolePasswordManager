using System;
using System.IO;

namespace PasswordManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Methods.StartUp();
            var cont = true;
            var choice = "";
            Modules.Welcome();
            do
            {
                Modules.ShowMenu();
                Console.WriteLine("Add -> Adds New Service. \nEdit -> Manually Change Password. \nDelete -> Delete Service. \nReset -> Reset Password. \nShow -> Show Password. \nEnd -> Ends Program");
                Console.Write("\nChoose an option: ");
                choice = Console.ReadLine();
                Console.Clear();
                switch (choice.ToLower())
                {
                    case "add":
                        Methods.AddData();
                        break;
                    case "edit":
                        Methods.EditData();
                        break;
                    case "delete":
                        Methods.DeleteData();
                        break;
                    case "reset":
                        Methods.ResetPasswordData();
                        break;
                    case "show":
                        Methods.ShowPassword();
                        break;
                    case "end":
                        cont = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid option.");
                        break;
                }
            } while (cont);
            Methods.SaveData();
        }
    }
}
