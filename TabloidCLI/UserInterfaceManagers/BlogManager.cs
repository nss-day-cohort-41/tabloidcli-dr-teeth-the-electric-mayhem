using System;
using System.Collections.Generic;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    public class BlogManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private BlogRepository _blogRepository;
        private string _connectionString;

        public BlogManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _blogRepository = new BlogRepository(connectionString);
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Blog Menu");
            Console.WriteLine(" 1) List All Blogs");
            Console.WriteLine(" 2) Blog Details");
            Console.WriteLine(" 3) Add a Blog");
            Console.WriteLine(" 4) Edit a Blog");
            Console.WriteLine(" 5) Remove a Blog");
            Console.WriteLine(" 0) Go Back");
            //bool repeat = false;

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
                case "2":
                    Blog blog = Choose();
                    if (blog == null)
                    {
                        return this;
                    }
                    else
                    {
                        return new BlogDetailManager(this, _connectionString, blog.Id);
                    }
                case "3":
                    Add();
                    return this;
                case "4":
                    Edit();
                    return this;
                case "5":
                    Remove();
                    return this;
                case "0":
                    return _parentUI;
                    
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }

        private void List()
        {
            Console.WriteLine("----------------------------YOUR LIST OF BLOGZ:---------------------------------------");
            List<Blog> blogs = _blogRepository.GetAll();
            foreach (Blog blog in blogs)
            {

                Console.WriteLine(blog);

                //Attempting Formatting of the lists output below:
                //Console.WriteLine("{0,-20} {1,5}\n", "Title", "Url");
                //for (int ctr = 0; ctr < blogs.Count; ctr++)
                //Console.WriteLine("{0,-20} {1,5:N1}", blog.Title[ctr], blog.Url[ctr]);
                //Another Attempt:
                //string str = "";
                //char pad = '.';
                //Console.WriteLine(str.PadLeft(2, pad), (blog));
            }
            Console.WriteLine("------------------------------:END BLOG LIST------------------------------------------");
        }

        private Blog Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose a Blog:";
            }

            Console.WriteLine(prompt);

            List<Blog> blogs = _blogRepository.GetAll();

            for (int i = 0; i < blogs.Count; i++)
            {
                Blog blog = blogs[i];
                
                Console.WriteLine($" {i + 1}) {blog.Title}");
                
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return blogs[choice - 1];
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        private void Add()
        {
            Console.WriteLine("new blog");
            Blog blog = new Blog();

            //After declaring the type of object and creating a new one, we can read the user input and set it to our objects parameters 
            Console.Write("Title for the Blog: ");
            blog.Title = Console.ReadLine();

            Console.Write("Insert the URL: ");
            blog.Url = Console.ReadLine();
            
            //CRUD insert method called and shown
            _blogRepository.Insert(blog);

            Console.WriteLine("Looks like youve succesfully added a blog post, take a look at your list to double check!");
            Console.WriteLine("----------------------------DR.Tooth did his thang---------------------------------------");
            Console.WriteLine("----------------------------...please continue---------------------------------------");
        }

        private void Edit()
        {
            //Similar process to insert....accept it relies heavily on the identification of a specific ID parameter...
            Blog blogToEdit = Choose("Which blog would you like to edit?");
            if (blogToEdit == null)
            {
                return;
            }

            Console.WriteLine();
            Console.Write("New Title for the Blog...(blank to leave unchanged: ");
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                blogToEdit.Title = title;
            }
            Console.Write("New Url to link with the Blog...(blank to leave unchanged: ");
            string Url = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(Url))
            {
                blogToEdit.Url = Url;
            }
            _blogRepository.Update(blogToEdit);
            Console.WriteLine("You just edited your blog post, great WORK!");
            Console.WriteLine("----------------------------DR.Tooth did his thang---------------------------------------");
            Console.WriteLine("----------------------------...please continue---------------------------------------");
        }

        private void Remove()
            //ID parameter is key here as well
        {
            Blog blogToDelete = Choose("Which Blog Entry would you like to remove?");
            if (blogToDelete != null)
            {
                _blogRepository.Delete(blogToDelete.Id);
                Console.WriteLine("Looks like ya deleted your blog post.....we dont have to tell nobodi");
                Console.WriteLine("----------------------------DR.Tooth did his thang---------------------------------------");
                Console.WriteLine("----------------------------...please continue---------------------------------------");
            }
        }
    }
}
