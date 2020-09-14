﻿using System;


namespace TabloidCLI.UserInterfaceManagers
{
    public class MainMenuManager : IUserInterfaceManager
    {
        private const string CONNECTION_STRING =
            @"Data Source=localhost\SQLEXPRESS;Database=TabloidCLI;Integrated Security=True";

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Welcome...Press any Key to contine");
            Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine(@"
██╗  ██╗███████╗██╗     ██╗      ██████╗ ██╗                                                                                                                
██║  ██║██╔════╝██║     ██║     ██╔═══██╗██║                                                                                                                
███████║█████╗  ██║     ██║     ██║   ██║██║                                                                                                                
██╔══██║██╔══╝  ██║     ██║     ██║   ██║╚═╝                                                                                                                
██║  ██║███████╗███████╗███████╗╚██████╔╝██╗                                                                                                                
╚═╝  ╚═╝╚══════╝╚══════╝╚══════╝ ╚═════╝ ╚═╝                                                                                                                
                                                                                                                                                            
██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗    ████████╗ ██████╗                                                                         
██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ╚══██╔══╝██╔═══██╗                                                                        
██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗         ██║   ██║   ██║                                                                        
██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝         ██║   ██║   ██║                                                                        
╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗       ██║   ╚██████╔╝██╗██╗██╗                                                               
 ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝       ╚═╝    ╚═════╝ ╚═╝╚═╝╚═╝                                                               
                                                                                                                                                            
██████╗ ██████╗    ████████╗███████╗███████╗████████╗██╗  ██╗                                                                                               
██╔══██╗██╔══██╗   ╚══██╔══╝██╔════╝██╔════╝╚══██╔══╝██║  ██║                                                                                               
██║  ██║██████╔╝      ██║   █████╗  █████╗     ██║   ███████║                                                                                               
██║  ██║██╔══██╗      ██║   ██╔══╝  ██╔══╝     ██║   ██╔══██║                                                                                               
██████╔╝██║  ██║██╗   ██║   ███████╗███████╗   ██║   ██║  ██║                                                                                               
╚═════╝ ╚═╝  ╚═╝╚═╝   ╚═╝   ╚══════╝╚══════╝   ╚═╝   ╚═╝  ╚═╝                                                                                               
                                                                                                                                                            
 █████╗ ███╗   ██╗██████╗                                                                                                                                   
██╔══██╗████╗  ██║██╔══██╗                                                                                                                                  
███████║██╔██╗ ██║██║  ██║                                                                                                                                  
██╔══██║██║╚██╗██║██║  ██║                                                                                                                                  
██║  ██║██║ ╚████║██████╔╝                                                                                                                                  
╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝                                                                                                                                   
                                                                                                                                                            
████████╗██╗  ██╗███████╗    ███████╗██╗     ███████╗ ██████╗████████╗██████╗ ██╗ ██████╗    ███╗   ███╗ █████╗ ██╗   ██╗██╗  ██╗███████╗███╗   ███╗███████╗
╚══██╔══╝██║  ██║██╔════╝    ██╔════╝██║     ██╔════╝██╔════╝╚══██╔══╝██╔══██╗██║██╔════╝    ████╗ ████║██╔══██╗╚██╗ ██╔╝██║  ██║██╔════╝████╗ ████║██╔════╝
   ██║   ███████║█████╗      █████╗  ██║     █████╗  ██║        ██║   ██████╔╝██║██║         ██╔████╔██║███████║ ╚████╔╝ ███████║█████╗  ██╔████╔██║███████╗
   ██║   ██╔══██║██╔══╝      ██╔══╝  ██║     ██╔══╝  ██║        ██║   ██╔══██╗██║██║         ██║╚██╔╝██║██╔══██║  ╚██╔╝  ██╔══██║██╔══╝  ██║╚██╔╝██║╚════██║
   ██║   ██║  ██║███████╗    ███████╗███████╗███████╗╚██████╗   ██║   ██║  ██║██║╚██████╗    ██║ ╚═╝ ██║██║  ██║   ██║   ██║  ██║███████╗██║ ╚═╝ ██║███████║
   ╚═╝   ╚═╝  ╚═╝╚══════╝    ╚══════╝╚══════╝╚══════╝ ╚═════╝   ╚═╝   ╚═╝  ╚═╝╚═╝ ╚═════╝    ╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝  ╚═╝╚══════╝╚═╝     ╚═╝╚══════╝
                                                                                                                                                            
 ██████╗ ██████╗ ███╗   ██╗███████╗ ██████╗ ██╗     ███████╗     █████╗ ██████╗ ██████╗ ██╗                                                                 
██╔════╝██╔═══██╗████╗  ██║██╔════╝██╔═══██╗██║     ██╔════╝    ██╔══██╗██╔══██╗██╔══██╗██║                                                                 
██║     ██║   ██║██╔██╗ ██║███████╗██║   ██║██║     █████╗      ███████║██████╔╝██████╔╝██║                                                                 
██║     ██║   ██║██║╚██╗██║╚════██║██║   ██║██║     ██╔══╝      ██╔══██║██╔═══╝ ██╔═══╝ ╚═╝                                                                 
╚██████╗╚██████╔╝██║ ╚████║███████║╚██████╔╝███████╗███████╗    ██║  ██║██║     ██║     ██╗                                                                 
 ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝ ╚═════╝ ╚══════╝╚══════╝    ╚═╝  ╚═╝╚═╝     ╚═╝     ╚═╝                                                                 
                                                                                                                                                            
");
<<<<<<< HEAD
            Console.WriteLine("What a performance. What a dang show. Wow, lets...begin:");
            Console.WriteLine("Oh wait....Choose your preffered color:");
            Console.Write("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine("Console Color Selection:");
            Console.WriteLine(" 1) Cyanz me Crazy");
            Console.WriteLine(" 2) Blue Boi");
            Console.WriteLine(" 3) Dark Yellow Gorilla ");
            Console.WriteLine(" 4) Allll I see is Red");
            Console.WriteLine(" 0) Keeps whats mines, original ");
            //Console.Write("> ");
            string colorchoicez = Console.ReadLine();
            switch (colorchoicez)
            {

                case "1":
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Clear();
                    }
                    break;
                case "2":
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                    }
                    break;
                case "3":
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Clear();
                    }
                    break;
                case "4":
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                    }
                    break;
                case "0":
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Clear();
                    }
                    break;
                default:
                    Console.WriteLine("Cmon now, pick a color");
                    Console.WriteLine("Invalid Selection");
                    return this;
            };
            Console.WriteLine(@"
██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗     █████╗  ██████╗  █████╗ ██╗███╗   ██╗                                                    
██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ██╔══██╗██╔════╝ ██╔══██╗██║████╗  ██║                                                    
██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗      ███████║██║  ███╗███████║██║██╔██╗ ██║                                                    
██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝      ██╔══██║██║   ██║██╔══██║██║██║╚██╗██║                                                    
╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗    ██║  ██║╚██████╔╝██║  ██║██║██║ ╚████║██╗██╗██╗                                           
 ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝    ╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝╚═╝╚═╝╚═╝                                                                                                                                                                                                      
");
            Console.WriteLine("Alrighty..... now that we figured that out............................................");
=======

            
>>>>>>> 6dd3cc67816df5d66324c1343feda27955dc474d
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("Main Menu");
            Console.WriteLine(" 1) Pick Tha Mood via a Color Scheme");
            Console.WriteLine(" 2) Journal Management");
            Console.WriteLine(" 3) Blog Management");
            Console.WriteLine(" 4) Author Management");
            Console.WriteLine(" 5) Post Management");
            Console.WriteLine(" 6) Tag Management");
            Console.WriteLine(" 7) Search by Tag");
            Console.WriteLine(" 0) Exit");
            Console.WriteLine("--------------------------------------------------------------------------------------");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": return new ColorOFConsoleManager(this, CONNECTION_STRING);
                case "2": return new JournalManager(this, CONNECTION_STRING);
                case "3": return new BlogManager(this, CONNECTION_STRING);
                case "4": return new AuthorManager(this, CONNECTION_STRING);
                case "5": throw new NotImplementedException();
                case "6": return new TagManager(this, CONNECTION_STRING);
                case "7": return new SearchManager(this, CONNECTION_STRING);
                case "0":
                    Console.WriteLine("Good bye, feel free to come visit us anytime!");
                    Console.WriteLine(@"
............................................________........................
....................................,.-‘”...................``~.,..................
.............................,.-”...................................“-.,............
.........................,/...............................................”:,........
.....................,?......................................................\,.....
.................../...........................................................,}....
................./......................................................,:`^`..}....
.............../...................................................,:”........./.....
..............?.....__.........................................:`.........../.....
............./__.(.....“~-,_..............................,:`........../........
.........../(_....”~,_........“~,_....................,:`........_/...........
..........{.._$;_......”=,_.......“-,_.......,.-~-,},.~”;/....}...........
...........((.....*~_.......”=-._......“;,,./`..../”............../............
...,,,___.\`~,......“~.,....................`.....}............../.............
............(....`=-,,.......`........................(......;_,,-”...............
............/.`~,......`-...............................\....../\...................
.............\`~.*-,.....................................|,./.....\,__...........
,,_..........}.>-._\...................................|..............`=~-,....
.....`=~-,_\_......`\,.................................\........................
...................`=~-,,.\,...............................\.......................
................................`:,,...........................`\..............__..
.....................................`=-,...................,%`>--==``.......
........................................_\..........._,-%.......`\...............
...................................,<`.._|_,-&``................`\..............
");
                    return null;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}