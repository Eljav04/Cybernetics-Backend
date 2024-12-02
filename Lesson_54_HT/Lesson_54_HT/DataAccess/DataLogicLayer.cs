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
        // Connection String ===============================================
        private string ConnectionString = "Data Source=localhost;" +
                                          "Database=ContactDB_Lesson_54;" +
                                          "Integrated Security = false; " +
                                          "User ID = SA; " +
                                          "Password=CodeWithArjun123";
        // =================================================================


        // Profiles' Querries ==============================================

        private string CheckExsistingProfile =
            "SELECT Count(*) FROM Profile" +
            " WHERE email = @email" +
            " OR phone_number LIKE @number";

        private string InsertProfileQuerry =
                        "INSERT INTO Profile(name, surname, phone_number, email, password)" +
                        " VALUES (@name, @surname, @phone_number, @email, @password)";

        private string GetProfileQuerry =
            "SELECT * FROM Profile " +
            "WHERE phone_number = @number " +
            "OR email = @email";

        // Contacts' querries ================================================
       

        private string LastContactIDQuerry = "SELECT IDENT_CURRENT(@table_name)";

        private string InsertContactQuerry =
                        "INSERT INTO Contacts(name, surname, email, website, profile_id) " +
                        "VALUES(@name, @surname, @email, @website, @profile_id)";

        private string InsertNumbersQuerry =
                        "INSERT INTO Numbers(contact_id, number)" +
                        "VALUES (@contact_id, @number)";

        private string SelectContactQuerry = "SELECT * FROM Contacts WHERE profile_id = @profile_id";

        private string SelectNumbersByContactQuerry =
            "SELECT * FROM Numbers WHERE contact_id = @contact_id";

        private string DeleteContactsByIDQuerry =
            "DELETE FROM Contacts WHERE id = @delete_id";

        private string DeleteNubmersByIDQuerry =
            "DELETE FROM Numbers WHERE contact_id = @delete_id";

        private string UpdateContactQuerry =
            "UPDATE Contacts " +
            "SET name = @name, surname = @surname, email = @email, website = @website " +
            "WHERE id = @id";

        private string UpdateNumberByContactQuerry =
            "UPDATE Numbers " +
            "SET number = @new_number " +
            "WHERE contact_id = @contact_id AND number = @old_number";

        // ===================================================================

        // Profiles functions
        public int CheckIfExistProfile(string email, string phone_number)
        {
            int rows_count;

            if (phone_number.StartsWith("+994"))
            {
                phone_number = phone_number.Substring(4, phone_number.Length - 4);
            }
            else if (phone_number.StartsWith("0"))
            {
                phone_number = phone_number.Substring(1, phone_number.Length - 1);
            }

            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new(CheckExsistingProfile, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
                        sqlCommand.Parameters.Add("@number", System.Data.SqlDbType.NVarChar).Value = "%" + phone_number;

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            reader.Read();
                            rows_count = Convert.ToInt32(reader[0]);
                        }
                    }
                    return rows_count;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 200;
                }

            }
        }

        public int AddProfile(Profile profile)
        {
            int CheckExist_ErrorCode = CheckIfExistProfile(profile.Email, profile.PhoneNumber);

            if (CheckExist_ErrorCode.Equals(200))
            {
                return 200;
            }

            if (CheckExist_ErrorCode > 0)
            {
                return 500;
            }

            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new(InsertProfileQuerry, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = profile.Name;
                        sqlCommand.Parameters.Add("@surname", SqlDbType.NVarChar).Value = profile.Surname;
                        sqlCommand.Parameters.Add("@phone_number", SqlDbType.NVarChar).Value = profile.PhoneNumber;
                        sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = profile.Email;
                        sqlCommand.Parameters.Add("@password", SqlDbType.NVarChar).Value = profile.Password;

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

        public (Profile profile, int Error_Code) GetProfile(string login)
        {
            Profile profile;
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new(GetProfileQuerry, sqlConnection))
                    {
                        Contacts contact = new();
                        sqlCommand.Parameters.
                            Add("@number", SqlDbType.NVarChar).Value = login;

                        sqlCommand.Parameters.
                            Add("@email", SqlDbType.NVarChar).Value = login;

                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            reader.Read();
                            profile = new()
                            {
                                ID = Convert.ToInt32(reader["id"]),
                                Name = Convert.ToString(reader["name"]),
                                Surname = Convert.ToString(reader["surname"]),
                                Email = Convert.ToString(reader["email"]),
                                PhoneNumber = Convert.ToString(reader["phone_number"]),
                                Password = Convert.ToString(reader["password"])
                            };
                        }


                    }
                    return (profile, 0);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return (null, 200);
                }

            }
        }


        // Contacts Functions ================================================

        // Add functions --------------
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

        public int AddContact(Contacts contact, int profile_id)
        {
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new(InsertContactQuerry, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = contact.Name;
                        sqlCommand.Parameters.Add("@surname", SqlDbType.NVarChar).Value = contact.Surname;
                        sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = contact.Email;
                        sqlCommand.Parameters.Add("@website", SqlDbType.NVarChar).Value = contact.Website;
                        sqlCommand.Parameters.Add("@profile_id", SqlDbType.Int).Value = profile_id;

                        sqlCommand.ExecuteNonQuery();

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

        // Search functions -----------
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

        public List<Contacts>? GetAllContacts(int profile_id)
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

                        sqlCommand.Parameters.Add("@profile_id", SqlDbType.Int).Value = profile_id;

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

        public List<Contacts>? GetAllContactsBy(string contact_category, string search_parametr, int profile_id)
        {
            List<Contacts> contactsList;
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    
                    string SelectContactByQuerry =
                        SelectContactQuerry
                        + " AND "
                        + Patterns.ContactSearchPatterns[contact_category];

                    using (SqlCommand sqlCommand = new(SelectContactByQuerry, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@profile_id", SqlDbType.Int).Value = profile_id;

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

        // Delete functions -----------
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

        // Update functions -----------
        public int UpdateContact(Contacts contact)
        {
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new(UpdateContactQuerry, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = contact.Name;
                        sqlCommand.Parameters.Add("@surname", SqlDbType.NVarChar).Value = contact.Surname;
                        sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = contact.Email;
                        sqlCommand.Parameters.Add("@website", SqlDbType.NVarChar).Value = contact.Website;

                        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = contact.ID;

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

        public int UpdateNumber(int contact_id, string old_number, string new_number)
        {
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new(UpdateNumberByContactQuerry, sqlConnection))
                    {
                        sqlCommand.Parameters.Add("@contact_id", SqlDbType.Int).Value = contact_id;
                        sqlCommand.Parameters.Add("@new_number", SqlDbType.NVarChar).Value = new_number;
                        sqlCommand.Parameters.Add("@old_number", SqlDbType.NVarChar).Value = old_number;

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
