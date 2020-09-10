using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

namespace TabloidCLI
{
    
    public class BlogRepository : DatabaseConnector, IRepository<Blog>
    {
        public BlogRepository(string connectionString) : base(connectionString) { }

        public List<Blog> GetAll()
        {
            {
                using (SqlConnection conn = Connection)
                {
                    // Note, we must Open() the connection, the "using" block doesn't do that for us.
                    conn.Open();

                    // We must "use" commands too.
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        // Here we setup the command with the SQL we want to execute before we execute it.
                        cmd.CommandText = @"SELECT id, Title, URL FROM Blog";

                        // A list to hold the rooms we retrieve from the database.
                        List<Blog> blogs = new List<Blog>();

                        // Execute the SQL in the database and get a "reader" that will give us access to the data.
                        SqlDataReader reader = cmd.ExecuteReader();
                        // Read() will return true if there's more data to read
                        while (reader.Read())
                        {

                            
                                Blog blog = new Blog()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Title = reader.GetString(reader.GetOrdinal("Title")),
                                    Url = reader.GetString(reader.GetOrdinal("Url"))
                                    
                                };
                            // ...and add that room object to our list.
                            blogs.Add(blog);
                        }
                            // The "ordinal" is the numeric position of the column in the query results.
                            //  For our query, "Id" has an ordinal value of 0 and "Name" is 1.
           
                        // We should Close() the reader. Unfortunately, a "using" block won't work here.
                        reader.Close();

                        // Return the list of rooms who whomever called this method.
                        return blogs;
                    }
                }
            }
            /// <summary>
            ///  Returns a single room with the given id.
            /// </summary>
        }

        ///BEGINING OF GET BY ID_---------------------------------------------------------------------------------------------------------
        public Blog Get(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT b.Id AS BlogId,
                                               b.Title,
                                               b.Url,
                                               t.Id AS TagId,
                                               t.Name
                                          FROM Blog b 
                                               LEFT JOIN BlogTag bt on b.Id = bt.BlogId
                                               LEFT JOIN Tag t on t.Id = bt.TagId
                                         WHERE b.id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    Blog blog = null;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (blog == null)
                        {
                            blog = new Blog()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("blog.Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Url = reader.GetString(reader.GetOrdinal("Url"))
                            };
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("TagId")))
                        {
                            blog.Tags.Add(new Tag()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("TagId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                            });
                        }
                    }

                    reader.Close();

                    return blog;
                }
            }
        }

        public void Insert(Blog blog)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Blog (Title, Url )
                                                     VALUES (@title, @url)";
                    cmd.Parameters.AddWithValue("@title", blog.Title);
                    cmd.Parameters.AddWithValue("@url", blog.Url);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Blog blog)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Blog 
                                           SET Title = @title,
                                               Url = @url
                                              
                                         WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", blog.Id);
                    cmd.Parameters.AddWithValue("@title", blog.Title);
                    cmd.Parameters.AddWithValue("@url", blog.Url);

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
                    cmd.CommandText = @"DELETE FROM Blog WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertTag(Blog blog, Tag tag)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO BlogTag (BlogId, TagId)
                                                       VALUES (@Id, @tagId)";
                    cmd.Parameters.AddWithValue("@blogId", blog.Id);
                    cmd.Parameters.AddWithValue("@tagId", tag.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteTag(int blogId, int tagId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM BlogTag 
                                         WHERE BlogId = @blogid AND 
                                               TagId = @tagId";
                    cmd.Parameters.AddWithValue("@blogId", blogId);
                    cmd.Parameters.AddWithValue("@tagId", tagId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
