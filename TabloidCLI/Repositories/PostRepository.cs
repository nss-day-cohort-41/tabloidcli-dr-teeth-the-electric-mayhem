using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI
{
    public class PostRepository : DatabaseConnector, IRepository<Post>
    {
        public PostRepository(string connectionString) : base(connectionString) { }

        public List<Post> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id,
                                               Title,
                                               Url,
                                          FROM Post";

                    List<Post> posts = new List<Post>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Post post = new Post()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Url = reader.GetString(reader.GetOrdinal("Url")),
                        };
                        posts.Add(post);
                    }

                    reader.Close();

                    return posts;
                }
            }
        }

        public Post Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT p.Id AS PostId,
                                               p.Title,
                                               p.Url,
                                               
                                          FROM Post p 
                                              ";

                    cmd.Parameters.AddWithValue("@id", id);

                    Post post = null;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (post == null)
                        {
                            post = new Post()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("PostId")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Url = reader.GetString(reader.GetOrdinal("Url")),
                            };
                        }

                        
                    }

                    reader.Close();

                    return post;
                }
            }
        }

        public void Insert(Post post)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Post (Title, Url )
                                                     VALUES (@title, @url)";
                    cmd.Parameters.AddWithValue("@title", post.Title);
                    cmd.Parameters.AddWithValue("@url", post.Url);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Post post)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Post 
                                           SET Title = @title,
                                               Url = @url,
                                         WHERE id = @id";

                    cmd.Parameters.AddWithValue("@title", post.Title);
                    cmd.Parameters.AddWithValue("@url", post.Url);
                    cmd.Parameters.AddWithValue("@id", post.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Post WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        
    }
}
