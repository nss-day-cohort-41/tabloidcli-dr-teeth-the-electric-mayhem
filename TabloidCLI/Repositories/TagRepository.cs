using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;
using TabloidCLI.UserInterfaceManagers;

namespace TabloidCLI
{
    public class TagRepository : DatabaseConnector, IRepository<Tag>
    {
        public TagRepository(string connectionString) : base(connectionString) { }

        public List<Tag> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT id, Name FROM Tag";
                    List<Tag> tags = new List<Tag>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Tag tag = new Tag()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                        };
                        tags.Add(tag);
                    }

                    reader.Close();

                    return tags;
                }
            }
        }

        public Tag Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Tag tag)
        {
            {
                // connectionString links us to SQL, like an address to the database
                using (SqlConnection conn = Connection)
                {
                    // Open the communication tunnel to gain accessibility
                    conn.Open();
                    //  sending the command through the communication tunnel
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        // this is the content of the command (the cargo) 
                        // **PRO-TIP: check your SQL query here**
                        cmd.CommandText = @"INSERT INTO Tag (AuthorId, TagId)
                                                       VALUES (@authorId, @tagId)";
                        cmd.Parameters.AddWithValue("@authorId", author.Id);
                        cmd.Parameters.AddWithValue("@tagId", tag.Id);
                        //ExecuteNonQuery used for executing queries that does not return any data. 
                        //It is used to execute the sql statements like update, insert, delete etc. ExecuteNonQuery executes the command and returns the number of rows affected.
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void Update(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            public void DeleteTag(int authorId, int tagId)
            {
                // connectionString links us to SQL, like an address to the database
                using (SqlConnection conn = Connection)
                {
                    // Open the communication tunnel to gain accessibility
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        // this is the content of the command (the cargo) 
                        // **PRO-TIP: check your SQL query here**
                        cmd.CommandText = @"DELETE FROM AuthorTAg 
                                         WHERE AuthorId = @authorid AND 
                                               TagId = @tagId";
                        cmd.Parameters.AddWithValue("@authorId", authorId);
                        cmd.Parameters.AddWithValue("@tagId", tagId);
                        //ExecuteNonQuery used for executing queries that does not return any data. 
                        //It is used to execute the sql statements like update, insert, delete etc. ExecuteNonQuery executes the command and returns the number of rows affected.
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }




        
    }



    public SearchResults<Author> SearchAuthors(string tagName)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT a.id,
                                               a.FirstName,
                                               a.LastName,
                                               a.Bio
                                          FROM Author a
                                               LEFT JOIN AuthorTag at on a.Id = at.AuthorId
                                               LEFT JOIN Tag t on t.Id = at.TagId
                                         WHERE t.Name LIKE @name";
                    cmd.Parameters.AddWithValue("@name", $"%{tagName}%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    SearchResults<Author> results = new SearchResults<Author>();
                    while (reader.Read())
                    {
                        Author author = new Author()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Bio = reader.GetString(reader.GetOrdinal("Bio")),
                        };
                        results.Add(author);
                    }

                    reader.Close();

                    return results;
                }
            }
        }
    }
}
