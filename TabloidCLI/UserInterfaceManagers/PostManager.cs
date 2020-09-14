using System;
using System.Collections.Generic;
using System.Xml.Schema;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI.UserInterfaceManagers
{
    public class PostManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private PostRepository _postRepository;
        private string _connectionString;
        private AuthorRepository _authorRepository;
        private BlogRepository _blogRepository;

        public PostManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _postRepository = new PostRepository(connectionString);
            _connectionString = connectionString;
            _authorRepository = new AuthorRepository(connectionString);
            _blogRepository = new BlogRepository(connectionString);
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Post Menu");
            Console.WriteLine(" 1) List Posts");
            Console.WriteLine(" 2) Add Post");
            Console.WriteLine(" 3) Edit Post");
            Console.WriteLine(" 4) Remove Post");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    List();
                    return this;
<<<<<<< HEAD

=======
                
>>>>>>> f333ccc2878ed18ecf17268b1538b9828be249f4
                case "2":
                    Add();
                    return this;
                case "3":
                    Edit();
                    return this;
                case "4":
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
            List<Post> posts = _postRepository.GetAll();
            foreach (Post post in posts)
            {
                Console.WriteLine("Beeps, Boops & Blogs");
                Console.WriteLine("----------------------");
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"URL: {post.Url}");
                Console.WriteLine();
            }
        }

<<<<<<< HEAD

=======
        
>>>>>>> f333ccc2878ed18ecf17268b1538b9828be249f4

        private void Add()
        {
            Console.WriteLine("New Post");
            Post post = new Post();

            Console.Write("Title: ");
            post.Title = Console.ReadLine();

            Console.Write("URL: ");
            post.Url = Console.ReadLine();

            Console.Write("PublishDateTime: ");
            post.PublishDateTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Choose a Author to associate: ");
            List<Author> authors = _authorRepository.GetAll();
            foreach (Author author in authors)
            {
                Console.WriteLine($"{author.Id}) {author.FullName}");
            }
            post.Author = authors[int.Parse(Console.ReadLine()) - 1];
            Console.WriteLine("Choose a Blog to associate: ");
            List<Blog> blogs = _blogRepository.GetAll();
            foreach (Blog blog in blogs)
            {
                Console.WriteLine($"{blog.Id}) {blog.Title}");
            }
            post.Blog = blogs[int.Parse(Console.ReadLine()) - 1];

            _postRepository.Insert(post);


        }
        private Post Choose(string prompt = null)
        {
            if (prompt == null)
            {
                prompt = "Please choose a Post:";
            }

            Console.WriteLine(prompt);

            List<Post> posts = _postRepository.GetAll();

            for (int i = 0; i < posts.Count; i++)
            {
                Post post = posts[i];
                Console.WriteLine($" {i + 1}) {post.Title}");
            }
            Console.Write("> ");

            string input = Console.ReadLine();
            try
            {
                int choice = int.Parse(input);
                return posts[choice - 1];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
                return null;
            }
        }

        private void Edit()
        {
            Post postToEdit = Choose("Which post would you like to edit?");
            if (postToEdit == null)
            {
                return;
            }

            Console.WriteLine();
            Console.Write("New Title (blank to leave unchanged: ");
            string title = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(title))
            {
                postToEdit.Title = title;
            }
            Console.Write("New URL (blank to leave unchanged: ");
            string URL = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(URL))
            {
                postToEdit.Url = URL;
            }
            Console.Write("New Publish Date and Time (blank to leave unchanged: ");
            string publishDateTime = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(publishDateTime))
            {
                postToEdit.PublishDateTime = DateTime.Parse(publishDateTime);
            }
            Console.WriteLine("Choose a new Author to associate (blank to leave unchanged: ");
            List<Author> authors = _authorRepository.GetAll();

            foreach (Author author in authors)
            {
                Console.WriteLine($"{author.Id}) {author.FullName}");
            }
            string authorValue = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(authorValue))
            {

                postToEdit.Author = authors[int.Parse(authorValue) - 1];
            }
            Console.WriteLine("Choose a new Blog to associate (blank to leave unchanged:");
            List<Blog> blogs = _blogRepository.GetAll();
            foreach (Blog blog in blogs)
            {
                Console.WriteLine($"{blog.Id}) {blog.Title}");
            }
            string blogValue = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(blogValue))
            {

                postToEdit.Blog = blogs[int.Parse(blogValue) - 1];
            }


            _postRepository.Update(postToEdit);
        }

        private void Remove()
        {


            Post postToDelete = Choose("Which post would you like to remove?");
            if (postToDelete != null)
            {
                _postRepository.Delete(postToDelete.Id);
            }
        }
    }
}