using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Lesson_54_HT.Model;
using Lesson_54_HT;
using System.Data;

namespace Lesson_54_HT.DataAccess
{
	public class DataLogicLayer
    {
        private string ConnectionString = "Data Source=localhost;" +
											"Database=Task_6_;" +
										"Integrated Security = false; " +
										"User ID = SA; " +
										"Password=CodeWithArjun123";

        private string InsertQuerry =
						"INSERT INTO Contacts(name, surname, phone_number, email, website) " +
						"VALUES(@name, @surname, @phone_number, @email, @website)";
        public DataLogicLayer()
        {
        }

        public int AddContact(Contacts contact)
        {
            using (SqlConnection sqlConnection = new(ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
					using (SqlCommand sqlCommand = new(InsertQuerry, sqlConnection))
					{
						sqlCommand.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = contact.Name;
                        sqlCommand.Parameters.Add("@surname", System.Data.SqlDbType.NVarChar).Value = contact.Surname;
                        //sqlCommand.Parameters.Add("@phone_number", System.Data.SqlDbType.NVarChar).Value = contact.PhoneNumber;
                        sqlCommand.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value =  contact.Email;
                        sqlCommand.Parameters.Add("@website", System.Data.SqlDbType.NVarChar).Value = contact.Website;


                        sqlCommand.ExecuteNonQuery();
                        return 0;

                    }
                }
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
                    return 200;
				}
			}

		}
	}
}

