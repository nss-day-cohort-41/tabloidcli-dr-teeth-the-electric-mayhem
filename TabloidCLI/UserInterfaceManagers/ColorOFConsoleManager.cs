using System;
using System.Collections.Generic;
using System.Text;


namespace TabloidCLI.UserInterfaceManagers
{
    public class ColorOFConsoleManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        
        public ColorOFConsoleManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("What a performance. What a dang show. Wow, lets get a mood set:");

            Console.WriteLine("Console Color Selection:");
            Console.WriteLine(" 1) AQUABERRY AQUARIUS Themez");
            Console.WriteLine(" 2) HOLOGRAM PANDA Themez");
            Console.WriteLine(" 3) TANGERINE TIGER Themez");
            Console.WriteLine(" 4) CRANBERRY VAMPIRE Themez");
            Console.WriteLine(" 5) Blurp'EARL'Berry PANTHER Themez");
            Console.WriteLine(" 0) LETS GO BACK TO THE MENU TO SEE SOME REAL FEATURES, RIGHT NOW!");
            Console.Write("> ");
            string colorchoicez = Console.ReadLine();
            switch (colorchoicez)
            {

                case "1":
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Clear();
                    }
                    return this;
                case "2":
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                    }
                    return this;
                case "3":
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Clear();
                    }
                    return this;
                case "4":
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                    }
                    return this;
                case "5":
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Clear();
                    }
                    return this;
                case "0":
                    {
                        Console.WriteLine("Alrighty..... now that we figured that out.......");
                        return _parentUI;
                    }
                   
                default:
                    Console.WriteLine("Cmon now, pick a color");
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}