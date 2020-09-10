using System;

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
//   __ __    ___  _      _       ___   __      __    __    ___  _         __   ___   ___ ___    ___      ______   ___       ___    ____       ______    ___    ___  ______  __ __          ______  __ __    ___        ___  _        ___     __  ______  ____   ____     __      ___ ___   ____  __ __  __ __    ___  ___ ___  __   _____        __   ___   ____    _____  ___   _        ___       ____  ____   ____   __ 
//  |  |  |  /  _]| |    | |     /   \ |  |    |  |__|  |  /  _]| |       /  ] /   \ |   |   |  /  _]    |      | /   \     |   \  |    \     |      |  /  _]  /  _]|      ||  |  |        |      ||  |  |  /  _]      /  _]| |      /  _]   /  ]|      ||    \ |    |   /  ]    |   |   | /    ||  |  ||  |  |  /  _]|   |   ||  | / ___/       /  ] /   \ |    \  / ___/ /   \ | |      /  _]     /    ||    \ |    \ |  |
//  |  |  | /  [_ | |    | |    |     ||  |    |  |  |  | /  [_ | |      /  / |     || _   _ | /  [_     |      ||     |    |    \ |  D  )    |      | /  [_  /  [_ |      ||  |  |        |      ||  |  | /  [_      /  [_ | |     /  [_   /  / |      ||  D  ) |  |   /  /     | _   _ ||  o  ||  |  ||  |  | /  [_ | _   _ ||_ |(   \_       /  / |     ||  _  |(   \_ |     || |     /  [_     |  o  ||  o  )|  o  )|  |
//  |  _  ||    _]| |___ | |___ |  O  ||__|    |  |  |  ||    _]| |___  /  /  |  O  ||  \_/  ||    _]    |_|  |_||  O  |    |  D  ||    /     |_|  |_||    _]|    _]|_|  |_||  _  |        |_|  |_||  _  ||    _]    |    _]| |___ |    _] /  /  |_|  |_||    /  |  |  /  /      |  \_/  ||     ||  ~  ||  _  ||    _]|  \_/  |  \| \__  |     /  /  |  O  ||  |  | \__  ||  O  || |___ |    _]    |     ||   _/ |   _/ |__|
//  |  |  ||   [_ |     ||     ||     | __     |  `  '  ||   [_ |     |/   \_ |     ||   |   ||   [_       |  |  |     |    |     ||    \  __   |  |  |   [_ |   [_   |  |  |  |  |          |  |  |  |  ||   [_     |   [_ |     ||   [_ /   \_   |  |  |    \  |  | /   \_     |   |   ||  _  ||___, ||  |  ||   [_ |   |   |     /  \ |    /   \_ |     ||  |  | /  \ ||     ||     ||   [_     |  _  ||  |   |  |    __ 
//  |  |  ||     ||     ||     ||     ||  |     \      / |     ||     |\     ||     ||   |   ||     |      |  |  |     |    |     ||  .  \|  |  |  |  |     ||     |  |  |  |  |  |          |  |  |  |  ||     |    |     ||     ||     |\     |  |  |  |  .  \ |  | \     |    |   |   ||  |  ||     ||  |  ||     ||   |   |     \    |    \     ||     ||  |  | \    ||     ||     ||     |    |  |  ||  |   |  |   |  |
//  |__|__||_____||_____||_____| \___/ |__|      \_/\_/  |_____||_____| \____| \___/ |___|___||_____|      |__|   \___/     |_____||__|\_||__|  |__|  |_____||_____|  |__|  |__|__|          |__|  |__|__||_____|    |_____||_____||_____| \____|  |__|  |__|\_||____| \____|    |___|___||__|__||____/ |__|__||_____||___|___|      \___|     \____| \___/ |__|__|  \___| \___/ |_____||_____|    |__|__||__|   |__|   |__|
//                                                                                                                                                                                                                                                                                                                                                                                                                          
");
            Console.WriteLine("Main Menu");
            Console.WriteLine(" 1) Journal Management");
            Console.WriteLine(" 2) Blog Management");
            Console.WriteLine(" 3) Author Management");
            Console.WriteLine(" 4) Post Management");
            Console.WriteLine(" 5) Tag Management");
            Console.WriteLine(" 6) Search by Tag");
            Console.WriteLine(" 0) Exit");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": throw new NotImplementedException();
                case "2": return new BlogManager(this, CONNECTION_STRING);
                case "3": return new AuthorManager(this, CONNECTION_STRING);
                case "4": throw new NotImplementedException();
                case "5": return new TagManager(this, CONNECTION_STRING);
                case "6": return new SearchManager(this, CONNECTION_STRING);
                case "0":
                    Console.WriteLine("Good bye");
                    return null;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}
