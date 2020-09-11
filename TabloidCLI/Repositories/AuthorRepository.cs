using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using TabloidCLI.Models;
using TabloidCLI.Repositories;

// Repository is like our API


namespace TabloidCLI
{
    public class AuthorRepository : DatabaseConnector, IRepository<Author>
    {
        // connectionString links us to SQL, like an address to the database
        public AuthorRepository(string connectionString) : base(connectionString) { }

        // Method that is going to be listing "Author", getting all the info available
        public List<Author> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                // Open the communication tunnel to gain accessibility (it's a gated community)
                conn.Open();
                // setting up the connection to sql, "Connection" prompt comes from the BaseRepository which is the common code being applied through the application (This is the "communication tunnel")
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // this is the content of the command (the cargo) 
                    // **PRO-TIP: check your SQL query here*
                    // this is selecting the content from author
                    cmd.CommandText = @"SELECT id,
                                               FirstName,
                                               LastName,
                                               Bio
                                          FROM Author";

                    List<Author> authors = new List<Author>();

                    // if you don't execute the command it won't do anything ( cmd.ExecuteReader(); )
                    SqlDataReader reader = cmd.ExecuteReader();
                    // test read method, if reader.read returns false there are no results. 
                    // if true, hopefully only one result returns. more than one, conflicting ID numbers.
                    while (reader.Read())
                    {
                        Author author = new Author()
                        {
                            // Setting values of author properties. 
                            // PRO-TIP: try "reader." to see what comes up.
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Bio = reader.GetString(reader.GetOrdinal("Bio")),
                        };
                        authors.Add(author);
                    }

                    // Closing connection, database is not infinant resource. If not closed, we will run out of connections. (TURN OFF THE LIGHTS IF YOU ARENT IN THE ROOM)
                    reader.Close();
                    // returning authors variable
                    return authors;
                }
            }
        }

        // Method that is going to be returning "Author", searching by id number
        public Author Get(int id)
        {
            // setting up the connection to sql, "Connection" prompt comes from the BaseRepository which is the common code being applied through the application (This is the "communication tunnel")
            using (SqlConnection conn = Connection)
            {
                
                conn.Open();
                //  sending the command through the communication tunnel (like a train, or coal mine workers)
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // this is the content of the command (the cargo) 
                    // **PRO-TIP: check your SQL query here**
                    cmd.CommandText = @"SELECT a.Id AS AuthorId,
                                               a.FirstName,
                                               a.LastName,
                                               a.Bio,
                                               t.Id AS TagId,
                                               t.Name
                                          FROM Author a 
                                               LEFT JOIN AuthorTag at on a.Id = at.AuthorId
                                               LEFT JOIN Tag t on t.Id = at.TagId
                                         WHERE a.id = @id";
                    // Check your ID number here, set "@id" to a 1. See what it returns and that it's correct before continueing.

                    // Add the parameter definition to the command, the name of this parameter is "@id" 
                    cmd.Parameters.AddWithValue("@id", id);
                    
                    // the author currently is nothing
                    Author author = null;

                    // if you don't execute the command it won't do anything ( cmd.ExecuteReader(); )
                    SqlDataReader reader = cmd.ExecuteReader();
                    // test read method, if reader.read returns false there are no results. 
                    // if true, hopefully only one result returns. more than one, conflicting ID numbers.
                    while (reader.Read())
                    {
                        if (author == null)
                        { 
                            //author: name of variable "taco"
                            //Author: new type of variable/class
                            author = new Author()
                            {
                                // Setting values of author properties. 
                                // PRO-TIP: try "reader." to see what comes up.
                                // Ordinal: Being of a specified position in a numbered series. Remember, counting starts at zero.
                                Id = reader.GetInt32(reader.GetOrdinal("AuthorId")),
                                // int is alias for type of 32. there are different kinds of ints (like Int16)
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                // could also do "int firstnameOrdinal = reader.GetOrdinal("FirstName");" , but it would have to be above "author = new Author()"
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                Bio = reader.GetString(reader.GetOrdinal("Bio")),
                            };
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("TagId")))
                        {
                            author.Tags.Add(new Tag()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("TagId")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                            });
                        }
                    }
                    // Closing connection, database is not infinant resource. If not closed, we will run out of connections. (TURN OFF THE LIGHTS IF YOU ARENT IN THE ROOM)
                    reader.Close();
                    // returning author variable
                    return author;
                }
            }
        }

        // Method that is going to be inserting/adding/Creating "Author".
        // Author is the type of class, author is the name of variable
        public void Insert(Author author)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Author (FirstName, LastName, Bio )
                                                     VALUES (@firstName, @lastName, @bio)";
                    cmd.Parameters.AddWithValue("@firstName", author.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", author.LastName);
                    cmd.Parameters.AddWithValue("@bio", author.Bio);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Method that is going to be Updating "Author".
        public void Update(Author author)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Author 
                                           SET FirstName = @firstName,
                                               LastName = @lastName,
                                               bio = @bio
                                         WHERE id = @id";

                    cmd.Parameters.AddWithValue("@firstName", author.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", author.LastName);
                    cmd.Parameters.AddWithValue("@bio", author.Bio);
                    cmd.Parameters.AddWithValue("@id", author.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Method that is going to be Deleting "Author".
        public void Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Author WHERE id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Method that is going to be inserting/creating a tag for "Author".
        public void InsertTag(Author author, Tag tag)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO AuthorTag (AuthorId, TagId)
                                                       VALUES (@authorId, @tagId)";
                    cmd.Parameters.AddWithValue("@authorId", author.Id);
                    cmd.Parameters.AddWithValue("@tagId", tag.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // Method that is going to be deleting a tag for "Author".
        public void DeleteTag(int authorId, int tagId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM AuthorTAg 
                                         WHERE AuthorId = @authorid AND 
                                               TagId = @tagId";
                    cmd.Parameters.AddWithValue("@authorId", authorId);
                    cmd.Parameters.AddWithValue("@tagId", tagId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
     }
}
