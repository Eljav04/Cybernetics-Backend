using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Lesson_54_HT.Model;
using Lesson_54_HT;
using Lesson_54_HT.Services.Patterns;
using System.Data;

namespace Lesson_54_HT.DataAccess
{
    public class DataLogicLayer
    {
        private string ConnectionString = "Data Source=localhost;" +
                                           "Database=ContactDB_Lesson_54;" +
                                           "Integrated Security = false; " +
                                           "User ID = SA; " +
                                           "Password=CodeWithArjun123";

        private string LastContactIDQuerry = "SELECT IDENT_CURRENT(@table_name)";

        private string InsertContactQuerry =
                        "INSERT INTO Contacts(name, surname, email, website) " +
                        "VALUES(@name, @surname, @email, @website)";

        private string InsertNumbersQuerry =
                        "INSERT INTO Numbers(contact_id, number)" +
                        "VALUES (@contact_id, @number)";

        private string SelectContactQuerry = "SELECT * FROM Contacts";
        private string SelectNumbersByContactQuerry =
            "SELECT * FROM Numbers WHERE contact_id = @contact_id";

        private string DeleteContactsByIDQuerry =
            "DELETE FROM Contacts WHERE id = @delete_id";
        private string DeleteNubmersByIDQuerry =
            "DELETE FROM Numbers WHERE contact_id = @delete_id";



        // Add functions
        public int GetLastRowID(string table_name)
        {
            int last_id;
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new(LastContactIDQuerry, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@table_name", System.Data.SqlDbType.NVarChar).Value = table_name;

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            reader.Read();
                            last_id = Convert.ToInt32(reader[0]);
                        }
                    }
                    return last_id;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }

            }
        }

        private void AddNumberCommand(SqlConnection sqlConnection, int contact_id, string number)
        {
            using (SqlCommand sqlCommand_num = new(InsertNumbersQuerry, sqlConnection))
            {
                sqlCommand_num.Parameters.Add("@contact_id", SqlDbType.Int).Value = contact_id;
                sqlCommand_num.Parameters.Add("@number", SqlDbType.VarChar).Value = number;

                sqlCommand_num.ExecuteNonQuery();
            }
        }

        public int AddContact(Contacts contact)
        {
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new(InsertContactQuerry, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = contact.Name;
                        sqlCommand.Parameters.Add("@surname", System.Data.SqlDbType.NVarChar).Value = contact.Surname;
                        sqlCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = contact.Email;
                        sqlCommand.Parameters.Add("@website", System.Data.SqlDbType.NVarChar).Value = contact.Website;

                        sqlCommand.ExecuteNonQuery();
                        //return 0;

                    }

                    int contact_id = GetLastRowID("Contacts");
                    if (contact_id.Equals(0))
                    {
                        throw new Exception("Something went wrong with connection to data base");
                    }

                    foreach (string number in contact.PhoneNumbers)
                    {
                        AddNumberCommand(sqlConnection, contact_id, number);
                    }   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 200;
                }
                return 0;
            }

        }

        // Search functions
        public List<string> GetAllNumByContactCommand(SqlConnection sqlConnection, int contact_id)
        {
            List<string> NumbersList;

            using (SqlCommand sqlCommand = new(SelectNumbersByContactQuerry, sqlConnection))
            {
                sqlCommand.Parameters.Add(
                    "@contact_id", SqlDbType.Int).Value = contact_id;

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    NumbersList = new();

                    while (reader.Read())
                    {
                        NumbersList.Add
                            (
                                Convert.ToString(reader["number"])
                            );
                    }
                    return NumbersList;

                }
            }
        }

        public List<Contacts>? GetAllContacts()
        {
            List<Contacts> contactsList;
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new(SelectContactQuerry, sqlConnection))
                    {
                        Contacts contact = new();
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            contactsList = new();

                            while (reader.Read())
                            {
                                contact = new()
                                {
                                    ID = Convert.ToInt32(reader["id"]),
                                    Name = Convert.ToString(reader["name"]),
                                    Surname = Convert.ToString(reader["surname"]),
                                    Email = Convert.ToString(reader["email"]),
                                    Website = Convert.ToString(reader["website"]),

                                };
                                contactsList.Add(contact);
                            }
                        }

                        contactsList.ForEach(
                            c => c.PhoneNumbers = GetAllNumByContactCommand(sqlConnection, c.ID));

                    }
                    return contactsList;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }

        public List<Contacts>? GetAllContactsBy(string contact_category, string search_parametr)
        {
            List<Contacts> contactsList;
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();

                    // Where must be removed!!!!
                    string SelectContactByQuerry =
                        SelectContactQuerry + " WHERE id > 0"
                        + " AND "
                        + Patterns.ContactSearchPatterns[contact_category];

                    using (SqlCommand sqlCommand = new(SelectContactByQuerry, sqlConnection))
                    {
                        Contacts contact = new();
                        if (search_parametr.Equals("ID"))
                        {
                            sqlCommand.Parameters.Add("search_parametr",
                            SqlDbType.Int).Value = search_parametr;
                        }
                        else
                        {
                            sqlCommand.Parameters.Add("search_parametr",
                            SqlDbType.NVarChar).Value = search_parametr;
                        }


                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            contactsList = new();

                            while (reader.Read())
                            {
                                contact = new()
                                {
                                    ID = Convert.ToInt32(reader["id"]),
                                    Name = Convert.ToString(reader["name"]),
                                    Surname = Convert.ToString(reader["surname"]),
                                    Email = Convert.ToString(reader["email"]),
                                    Website = Convert.ToString(reader["website"]),

                                };
                                contactsList.Add(contact);
                            }
                        }

                        contactsList.ForEach(
                            c => c.PhoneNumbers = GetAllNumByContactCommand(sqlConnection, c.ID));

                    }
                    return contactsList;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }

        // Delete functions
        public int DeleteContact(int delete_id)
        {
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand_num = new(DeleteNubmersByIDQuerry, sqlConnection))
                    {
                        sqlCommand_num.Parameters.Add("@delete_id", SqlDbType.Int).Value = delete_id;
                        sqlCommand_num.ExecuteNonQuery();
                    }
                    using (SqlCommand sqlCommand = new(DeleteContactsByIDQuerry, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@delete_id", SqlDbType.Int).Value = delete_id;
                        sqlCommand.ExecuteNonQuery();
                    }
                    
  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 200;
                }

                return 0;
            }

        }
    }
}
